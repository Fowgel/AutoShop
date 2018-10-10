using AutoWebShop.Models;
using AutoWebShopEntity.Entitys;
using AutoWebShopEntity.Repositorys;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoWebShop.Helper
{
    public class SelectListHelper
    {

        private AdvertiseCategorySystem _advertiseCategorySystem;
        private CarShopSystem _carShopSystem;
        private static readonly ILog log = LogManager.GetLogger(typeof(SelectListHelper));
        public SelectListHelper()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _advertiseCategorySystem = new AdvertiseCategorySystem(
                new AdvertiseCategoryRepository(connectionString)
            );
        }
        public IEnumerable<SelectListItem> GetAllParentCategory()
        {
            var parentCategory = _advertiseCategorySystem.GetParentCategory();
            return parentCategory.Select(x => new SelectListItem
            {
                Value = x.ParentCategoryId.ToString(),
                Text = x.ParentCategoryName.ToString()
            }).ToList();

        }
        public IEnumerable<SelectListItem> GetAllParentCategories()
        {
            var parent = _advertiseCategorySystem.GetParentCategory();
            return parent.Select(x => new SelectListItem
            {
                Value = x.ParentCategoryId.ToString(),
                Text = x.ParentCategoryName
            });
        }
        //CarShopModel carShopModel = new CarShopModel();
        //var parentCategory = _advertiseCategorySystem.GetParentCategory();
        //return carShopModel.Categorys = parentCategory.Select(x => new SelectListItem
        //{
        //    Value = x.ParentCategoryId.ToString(),
        //    Text = x.ParentCategoryName.ToString()
        //}).ToList();
        //public IEnumerable<SelectListItem> GetParent()
        //{
        //    var parent = _advertiseCategorySystem.GetSingleParentCategoy();
        //}
        //public IEnumerable<SelectListItem> GetAllChildCategorys(int id)
        //{
        //    var childCategory = _advertiseCategorySystem.GetChildCategorysById(id);
        //    return childCategory.Select(x => new SelectListItem
        //    {
        //        Text = x.ChildCategoryName.ToString(),
        //        Value = x.ChildCategoryId.ToString()

        //    }).ToList();

        //}
    }
}