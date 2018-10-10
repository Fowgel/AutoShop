using AutoWebShopEntity.Entitys;
using AutoWebShopEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Repositorys
{
    public class CarShopRepository : BaseRepository<CarShopEntity>, ICarShopRepository
    {
        public CarShopRepository(string connectionString) : base(connectionString)
        {
        }

        public void CreateNewCar(CarShopEntity createCarEntity)
        {
            using (var connection = base.Connection())
            {
                createCarEntity.AdvertisementId = connection.ExecuteScalar<int>(SqlQueries.AdvertiseNewCar,
                    new
                    {
                        Title = createCarEntity.Title,
                        Price = createCarEntity.Price,
                        City = createCarEntity.City,
                        ModelYear = createCarEntity.ModelYear,
                        GearBox = createCarEntity.GearBox,
                        Mileage = createCarEntity.Mileage,
                        ManufacturingYear = createCarEntity.ManufacturingYear,
                        Fuel = createCarEntity.Fuel,
                        CarModel = createCarEntity.CarModel,
                        Description = createCarEntity.Description,
                        PostalNumber = createCarEntity.PostalNumber,
                        AdvertisementDay = createCarEntity.AdvertisementDay,
                        ChildCategory = createCarEntity.ChildCategory
                    });
            }
        }

        public void DeleteCar(int advertisementId)
        {
            using (var connection = base.Connection())
            {
                connection.Query<CarShopEntity>(SqlQueries.IsSoftDeleted,
                    new
                    {
                        AdvertisementId = advertisementId
                    });
            }
        }

        public void EditCar(CarShopEntity carShopEntity)
        {
            using (var connection = base.Connection())
            {
                connection.Execute(SqlQueries.EditCarAdvertisement,
                    new
                    {
                        AdvertisementId = carShopEntity.AdvertisementId,
                        Title = carShopEntity.Title,
                        Price = carShopEntity.Price,
                        City = carShopEntity.City,
                        ModelYear = carShopEntity.ModelYear,
                        GearBox = carShopEntity.GearBox,
                        Mileage = carShopEntity.Mileage,
                        ManufacturingYear = carShopEntity.ManufacturingYear,
                        Fuel = carShopEntity.Fuel,
                        CarModel = carShopEntity.CarModel,
                        Description = carShopEntity.Description,
                        PostalNumber = carShopEntity.PostalNumber
                    });
            }
        }

        public IEnumerable<CarShopEntity> ListExistingCars()
        {
            using (var connection = base.Connection())
            {
                return connection.Query<CarShopEntity>(SqlQueries.GetExistingCars);
            }
        }

        public CarShopEntity AdvertismentInformation(int advertisementId)
        {
            using (var connection = base.Connection())
            {
                return connection.Query<CarShopEntity>(SqlQueries.GetCarByAdvertismentId,
                    new
                    {
                        AdvertisementId = advertisementId
                    }).FirstOrDefault();
            }
        }

        public IEnumerable<CarShopEntity> GetFeaturedCars(bool isFeatured)
        {
            using (var connection = base.Connection())
            {
                return connection.Query<CarShopEntity>(SqlQueries.GetFeaturedCars, new {IsFeatured  = isFeatured});
            }
        }

       
        public void UploadePictures(PictureEntity pictureFile)
        {
            using (var connection = base.Connection())
            {
                connection.Query<PictureEntity>(SqlQueries.InsertPicture, new
                {
                    PictureGuid = pictureFile.PictureGuid,
                    PictureGuidName = pictureFile.PictureGuidName,
                    PictureName = pictureFile.PictureName,
                    AdvertisementId = pictureFile.AdvertisementId
                });
            }
        }

        public IEnumerable<PictureEntity> GetPictures(int advertisementId)
        {
            using (var connection = base.Connection())
            {
                return connection.Query<PictureEntity>(SqlQueries.GetAdvertisementPic, new
                {
                    AdvertisementId = advertisementId
                });
            }
        }

        public IEnumerable<CarShopEntity> SearchItem(string seachItem)
        {
            using (var connection = base.Connection())
            {
                return connection.Query<CarShopEntity>(SqlQueries.GetSearchItem, new { SearchItem = seachItem });
            }
        }

        public IEnumerable<PictureEntity> GetFeaturedPictures(List<int> advertisementId)
        {
            using (var connection = base.Connection())
            {
                return connection.Query<PictureEntity>(SqlQueries.GetAdvertisementPic, new
                {
                    AdvertisementId = advertisementId
                });
            }
        }

        public static class SqlQueries
        {
            public static string GetExistingCars =>
                @"SELECT * From [dbo].[tCarShopAdvertisement] ";
            public static string AdvertiseNewCar =>
                @"INSERT INTO dbo.[tCarShopAdvertisement]
                (Title, Price, City, ModelYear, GearBox, Mileage, ManufacturingYear,Fuel, CarModel, Description, PostalNumber, AdvertisementDay, ChildCategory)
                OUTPUT INSERTED.AdvertisementId VALUES 
                (@Title, @Price, @City, @ModelYear, @GearBox, @Mileage, @ManufacturingYear, @Fuel, @CarModel, @Description, @PostalNumber, @AdvertisementDay, @ChildCategory)";
            public static string GetCarByAdvertismentId =>
                @"Select * from dbo.tCarShopAdvertisement where AdvertisementId = @AdvertisementId";
            public static string DeleteAdvertisement =>
                @"Delete FROM dbo.tCarShopAdvertisement where AdvertisementId = @AdvertisementId";
            public static string EditCarAdvertisement =>
                @"UPDATE [dbo].[tCarShopAdvertisement] SET Title = @Title, Price =  @Price, City = @City,
				    ModelYear = @ModelYear, GearBox = @GearBox, Mileage = @Mileage, ManufacturingYear = @ManufacturingYear,
				    Fuel = @Fuel, CarModel = @CarModel, Description = @Description, PostalNumber = @PostalNumber
                WHERE [AdvertisementId] = @AdvertisementId";
            public static string IsSoftDeleted =>
                @"UPDATE [dbo].[tCarShopAdvertisement] SET [IsSoftDeleted] = 1
                    WHERE [AdvertisementId] = @AdvertisementId";
            public static string GetFeaturedCars =>
                @"SELECT c.*, tp.PictureGuidName From [dbo].[tCarShopAdvertisement] as c 
                    Inner Join tPictureDataTable as tp on c.AdvertisementId = tp.AdvertisementId
                    WHERE c.IsFeatured = @IsFeatured";
            public static string InsertPicture =>
                @"Insert Into [dbo].[tPictureDataTable]
                    (PictureGuid, PictureGuidName,PictureName, AdvertisementId) 
                    VALUES 
                    (@PictureGuid, @PictureGuidName, @PictureName, @AdvertisementId)";
            public static string GetAdvertisementPic =>
                @"SELECT p.* from dbo.tPictureDataTable as p
                    WHERE p.AdvertisementId = @AdvertisementId";
            public static string GetAdvertisementPics =>
                @"SELECT p.* from dbo.tPictureDataTable as p
                    WHERE p.AdvertisementId = @AdvertisementId";
            public static string GetSearchItem =>
                @"Select c.* from tCarShopAdvertisement as c 
                    where c.Title LIKE '%' +  @SearchItem + '%' ";
        }

    }
}
