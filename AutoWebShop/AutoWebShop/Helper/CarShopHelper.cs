using AutoWebShop.Models;
using AutoWebShopEntity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWebShop.Helper
{
    public class CarShopHelper
    {

        public static CarShopModel ModelToEntity(CarShopEntity carEntity)
        {
            var model = new CarShopModel();
            model.AdvertisementId = carEntity.AdvertisementId;
            model.CarModel = carEntity.CarModel;
            model.City = carEntity.City;
            model.Description = carEntity.Description;
            model.Fuel = carEntity.Fuel;
            model.GearBox = carEntity.GearBox;
            model.ManufacturingYear = DateTime.Now;
            model.Mileage = carEntity.Mileage;
            model.ModelYear = carEntity.ModelYear;
            model.PostalNumber = carEntity.PostalNumber;
            model.Price = carEntity.Price;
            model.Title = carEntity.Title;
            model.AdvertisementDay = carEntity.AdvertisementDay;
            model.ChildCategoryName = carEntity.ChildCategory;
            model.Fileings = carEntity.Files?.Select(p => p.PictureGuidName).ToList();
            

            return model;
        }
        public static CarShopEntity EntityToModel(CarShopModel carEntity)
        {
            var model = new CarShopEntity();
            model.AdvertisementId = carEntity.AdvertisementId;
            model.CarModel = carEntity.CarModel;
            model.City = carEntity.City;
            model.Description = carEntity.Description;
            model.Fuel = carEntity.Fuel;
            model.GearBox = carEntity.GearBox;
            model.ManufacturingYear = DateTime.Now;
            model.Mileage = carEntity.Mileage;
            model.ModelYear = carEntity.ModelYear;
            model.PostalNumber = carEntity.PostalNumber;
            model.Price = carEntity.Price;
            model.Title = carEntity.Title;
            model.AdvertisementDay = carEntity.AdvertisementDay;
            model.ChildCategory = carEntity.ChildCategoryName;
            return model;
        }

        public static List<CarShopModel> Transform(IEnumerable<CarShopEntity> carEntity)
        {
            return carEntity?.Select(x => new CarShopModel
            {
                AdvertisementId = x.AdvertisementId,
                CarModel = x.CarModel,
                City = x.City,
                Description = x.Description,
                Fuel = x.Fuel,
                GearBox = x.GearBox,
                Mileage = x.Mileage,
                ModelYear = x.ModelYear,
                ManufacturingYear = x.ManufacturingYear,
                PostalNumber = x.PostalNumber,
                Price = x.Price,
                Title = x.Title,
                AdvertisementDay = x.AdvertisementDay,
                IsFeatured = x.IsFeatured,
                Fileings = x.Files?.Select(p => p.PictureGuidName).ToList(),
        }).ToList();
        }
    }
}