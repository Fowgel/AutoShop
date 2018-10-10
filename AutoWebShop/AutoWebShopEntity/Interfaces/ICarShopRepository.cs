using AutoWebShopEntity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Interfaces
{
    public interface ICarShopRepository
    {
        IEnumerable<CarShopEntity> ListExistingCars();
        IEnumerable<CarShopEntity> GetFeaturedCars(bool isFeatured);
        void CreateNewCar(CarShopEntity createCarEntity);
        void EditCar(CarShopEntity carShopEntity);
        void DeleteCar(int advertisementId);
        CarShopEntity AdvertismentInformation(int advertisementId);
        void UploadePictures(PictureEntity pictureFile);
        IEnumerable<PictureEntity> GetPictures(int advertisementId);
        IEnumerable<CarShopEntity> SearchItem(string seachItem);
        IEnumerable<PictureEntity> GetFeaturedPictures(List<int> advertisementId);

    }
}
