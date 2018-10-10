using AutoWebShopEntity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoWebShop.Models
{
    public class CarShopModel
    {
        

        public int AdvertisementId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string ModelYear { get; set; }
        public string GearBox { get; set; }
        public int Mileage { get; set; }
        public DateTime ManufacturingYear { get; set; }
        public string Fuel { get; set; }
        public string CarModel { get; set; }
        public string Description { get; set; }
        public string PostalNumber { get; set; }
        public DateTime AdvertisementDay { get; set; }
        public int ParentCategoryId { get; set; }
        public string AdvertisementCategory { get; set; }
        public bool IsFeatured { get; set; } = true;
        public bool IsSold { get; set; }
        public string File { get; set; }
        public List<HttpPostedFileBase> Files { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<SelectListItem> Categorys { get; set; }
        public string ChildCategoryName { get; set; }
        public IEnumerable<SelectListItem> ChildCategorys { get; set; }
        public List<string> Fileings { get; set; }
        public CarShopModel()
        {
            ChildCategorys = new List<SelectListItem>();
        }
    }
}