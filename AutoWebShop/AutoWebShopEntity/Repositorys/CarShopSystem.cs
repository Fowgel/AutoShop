using AutoWebShopEntity.Entitys;
using AutoWebShopEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AutoWebShopEntity.Repositorys
{
    public class CarShopSystem : ICarShopSystem
    {
        public ICarShopRepository _carRepository;
        private ISoftDataDeleteRepository _dataDeleteRepository;
        private IAdvertiseCategoryRepository _advertiseCategoryRepository;
        public CarShopSystem(ICarShopRepository carRepository, ISoftDataDeleteRepository dataDeleteRepository, IAdvertiseCategoryRepository advertiseCategoryRepository)
        {
            _carRepository = carRepository;
            _dataDeleteRepository = dataDeleteRepository;
            _advertiseCategoryRepository = advertiseCategoryRepository;
        }

        public CarShopEntity AdvertismentInformation(int advertisementId)
        {
            return _carRepository.AdvertismentInformation(advertisementId);
        }

        public void CreateNewCar(CarShopEntity createCarEntity)
        {
            if (createCarEntity.Title == null)
            {
                throw new ArgumentNullException("Some Parameters in the Advertisment cant be null", "Title");
            }
            using (var transaction = new TransactionScope())
            {
                AdvetisementDay(createCarEntity);
                _carRepository.CreateNewCar(createCarEntity);
                
                if (createCarEntity.Files != null)
                {
                    foreach (var picture in createCarEntity.Files)
                    {
                        picture.AdvertisementId = createCarEntity.AdvertisementId; 
                        _carRepository.UploadePictures(picture);
                    }
                }
                transaction.Complete();
            }
        }

        public void DeleteCar(int advertisementId, string advertisementCategory)
        {
            using (var transaction = new TransactionScope())
            {
                var dataObj = new SoftDeletedDataEntity
                {
                    AdvertisementId = advertisementId,
                    AdvertisementCategory = advertisementCategory,
                    TimeDeleted = DateTime.UtcNow.AddHours(2),
                    Description = $"The id this connects To is {advertisementId}, This item was deleted at: {DateTime.UtcNow.AddHours(2)}",
                };
                _carRepository.DeleteCar(advertisementId);
                DeletedDataObj(dataObj);
                transaction.Complete();
            }
        }

        public void EditCar(CarShopEntity carShopEntity)
        {
            _carRepository.EditCar(carShopEntity);
        }

        public IEnumerable<CarShopEntity> ListExistingCars()
        {
            return _carRepository.ListExistingCars();
        }
        public DateTime AdvetisementDay(CarShopEntity account)
        {
            var advertisementDay = DateTime.UtcNow.AddHours(2);
            account.AdvertisementDay = advertisementDay;
            return advertisementDay;
        }
        public void DeletedDataObj(SoftDeletedDataEntity obj)
        {
            _dataDeleteRepository.InsertObj(obj);
        }
        public IEnumerable<AdvertisementCategoryEntity> GetParentCategorys()
        {
            return _advertiseCategoryRepository.GetParentCategory();
        }
        public IEnumerable<ChildCategoryEntity> GetChildCategorysById(int id)
        {
            return _advertiseCategoryRepository.GetChildCategorysById(id);
        }

        public IEnumerable<CarShopEntity> GetFeaturedCars(bool isFeatured)
        {
            var FeaturedCars = _carRepository.GetFeaturedCars(isFeatured);
            return FeaturedCars;

        }

        public void UploadePictures(PictureEntity pictureFile)
        {
            _carRepository.UploadePictures(pictureFile);
        }

        public IEnumerable<PictureEntity> GetPictures(int advertisementId)
        {
            return _carRepository.GetPictures(advertisementId);
        }

        public IEnumerable<CarShopEntity> SearchItem(string seachItem)
        {
            return _carRepository.SearchItem(seachItem);
        }

        public IEnumerable<PictureEntity> GetFeaturedPictures(List<int> advertisementId)
        {
            return _carRepository.GetFeaturedPictures(advertisementId);
        }
    }
}
