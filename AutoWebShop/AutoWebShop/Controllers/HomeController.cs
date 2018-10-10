using AutoWebShop.Helper;
using AutoWebShop.Models;
using AutoWebShopEntity.Entitys;
using AutoWebShopEntity.Repositorys;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoWebShop.Controllers
{
    public class HomeController : Controller
    {
        //mvcpostaction4 skapar upp en postAction
        //mvcaction4 skapar en vanlig getAction
        private CarShopSystem _carShopSystem;
        private SelectListHelper _selectListHelper;
        SelectListHelper slh = new SelectListHelper();
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));
        public HomeController()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _carShopSystem = new CarShopSystem(
                new CarShopRepository(connectionString),
                new SoftDataDeleteRepository(connectionString),
                new AdvertiseCategoryRepository(connectionString)
            );
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CarView()
        {
            var transformed = CarShopHelper.Transform(_carShopSystem.ListExistingCars());
            return View(transformed);
        }
        [HttpGet]
        public ActionResult AdvertiseCar()
        {
            _selectListHelper = new SelectListHelper();
            var newCar = new CarShopModel();
            newCar.Categorys = slh.GetAllParentCategory();
            return View(newCar);
        }
        [HttpPost]
        public ActionResult AdvertiseCar(CarShopModel carShopModel)
        {
            try
            {
                carShopModel.Categorys = slh.GetAllParentCategories();
                var childCategories = _carShopSystem.GetChildCategorysById(carShopModel.ParentCategoryId);
                carShopModel.ChildCategorys = childCategories.Select(x => new SelectListItem
                {
                    Value = x.ChildCategoryId.ToString(),
                    Text = x.ChildCategoryName
                }).ToList();
                if (carShopModel != null)
                {
                    var newCar = CarShopHelper.EntityToModel(carShopModel);
                    if (carShopModel.Files != null && carShopModel.Files.Any(x => x != null))
                    {
                        newCar.Files = UploadPictures(carShopModel).ToList();
                    }
                    _carShopSystem.CreateNewCar(newCar);
                    return RedirectToAction("CarView");
                }
            }
            catch (Exception e)
            {
                log.Error(e.ToString());
                throw;
            }
            return View(carShopModel);
        }
        public ActionResult CarInformation(int id)
        {
            try
            {
                var details = _carShopSystem.AdvertismentInformation(id);
                details.Files = _carShopSystem.GetPictures(details.AdvertisementId).ToList();
                var transformation = CarShopHelper.ModelToEntity(details);
                if (transformation == null)
                {
                    return View();
                }
                return View(transformation);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        //Method for showing the image
        public ActionResult ShowImage(string fileName)
        {
            var fileDirectory = ConfigurationManager.AppSettings["Path"].ToString();
            var filePath = Path.Combine(fileDirectory, fileName);
            var imageByte = System.IO.File.ReadAllBytes(filePath);
            return File(imageByte, "image/jpeg");
        }
        [HttpGet]
        public ActionResult DeleteCarAdvertisement(int id)
        {
            var deleteInformation = _carShopSystem.AdvertismentInformation(id);
            var transformation = CarShopHelper.ModelToEntity(deleteInformation);
            return View(transformation);
        }
        [HttpPost]
        public ActionResult DeleteCarAdvertisement(int id, CarShopModel carShopModel)
        {
            try
            {
                var advetisementCategory = carShopModel.Title;
                _carShopSystem.DeleteCar(id, advetisementCategory);
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }
        public ActionResult EditCarAdvertisement(int id)
        {
            var EditCarInformation = _carShopSystem.AdvertismentInformation(id);
            var transformation = CarShopHelper.ModelToEntity(EditCarInformation);
            return View(transformation);
        }
        [HttpPost]
        public ActionResult EditCarAdvertisement(CarShopModel carShopModel)
        {
            try
            {
                if (carShopModel != null)
                {
                    _carShopSystem.EditCar(CarShopHelper.EntityToModel(carShopModel));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("CarView");
        }
        
        public ActionResult ChildCategorysFromParen(int id)
        {
            var advertise = new CarShopModel();
            var childCategory= _carShopSystem.GetChildCategorysById(id);
            advertise.ChildCategorys = childCategory.Select(x => new SelectListItem
                {
                    Text = x.ChildCategoryName.ToString(),
                    Value = x.ChildCategoryId.ToString()

                }).ToList();
            //JsonResultHelper är en custom json camelcase helper, som serializes data via Json gör om och följer camelCase varianten.
            return new JsonResultHelper(advertise.ChildCategorys, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FeaturedCars(CarShopModel carModel, string Id)
        {
            try
            {
                //var carModel = new CarShopModel();
                var carList = _carShopSystem.ListExistingCars();
                //var carsToBeFeatured = _carShopSystem.GetFeaturedCars(carModel.IsFeatured);
                var advertisementId = carList.Select(x => x.AdvertisementId).ToList();
                var pictures = _carShopSystem.GetFeaturedPictures(advertisementId);
                //carsToBeFeatured.Select(x => x.Files == pictures);
                carList.Where(x => x.Files == pictures);
                
                var transformed = CarShopHelper.Transform(carList);
                return PartialView(transformed);
            }
            catch (Exception e)
            {
                log.Error(e.ToString());
                throw;
            }
          
            
        }
        private IEnumerable<PictureEntity> UploadPictures(CarShopModel carShopModel)
        {
            var fileDirectory = ConfigurationManager.AppSettings["Path"].ToString();
            foreach (var file in carShopModel.Files)
            {
                var guid = Guid.NewGuid();
                var fileType = Path.GetExtension(file.FileName);
                var fileName = $"{guid}{fileType}";
                var originalFileName = file.FileName;
                var filePath = Path.Combine(fileDirectory, fileName);

                file.SaveAs(filePath);

                yield return new PictureEntity
                {
                    AdvertisementId = 0,
                    PictureGuid = guid,
                    PictureGuidName = fileName,
                    PictureName = originalFileName

                };
            }

        }
        public ActionResult SearchResult(string searchItem)
        {
            if (!string.IsNullOrEmpty(searchItem))
            {
                var search = _carShopSystem.SearchItem(searchItem);
                var Transformed = CarShopHelper.Transform(search);
                return View("SearchResult", Transformed);
            }
            else
            {
                return View("CarView");
            }

        }
        public ActionResult GetAllParentCategories()
        {
            CarShopModel carShopModel = new CarShopModel();
            carShopModel.Categorys = slh.GetAllParentCategories();
            return new JsonResultHelper(carShopModel.Categorys, JsonRequestBehavior.AllowGet);
        }
        //public string SearchResult(string searchItem)
        //{
        //    if (!string.IsNullOrEmpty(searchItem))
        //    {
        //        _carShopSystem.SearchItem(searchItem);
        //    }
        //    return searchItem;
        //}
        //public IEnumerable<CarShopEntity> GetFeaturedPictures()
        //{
        //    var carModel = new CarShopModel();
        //    var featured = carModel.IsFeatured;
        //    var carsToBeFeatured = _carShopSystem.GetFeaturedCars(featured);
        //    var AdvertisementId = carsToBeFeatured.Select(x => x.AdvertisementId).ToList();
        //   var newTransformed =  _carShopSystem.GetFeaturedPictures(AdvertisementId);
        //    return newTransformed;
        //}
    }
}