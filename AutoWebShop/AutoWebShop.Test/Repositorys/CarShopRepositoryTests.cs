using Autofac.Extras.Moq;
using AutoWebShopEntity.Entitys;
using AutoWebShopEntity.Interfaces;
using AutoWebShopEntity.Repositorys;
using Moq;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShop.Test.Repositorys
{
    [TestFixture]
    public class CarShopRepositoryTests
    {
        private ICarShopSystem carShopSystem;
        private CarShopEntity carShopEntity;

        [SetUp]
        public void Setup()
        {
            carShopSystem = Substitute.For<ICarShopSystem>();
            carShopEntity = new CarShopEntity();
        }
        [Test]
        public void ListExtistingData_ValidCall()
        {
            
            var cars = carShopSystem.ListExistingCars();

            Assert.True(cars != null);
            Assert.False(cars == null);
            Assert.True(cars.Count() > 0);
            
        }
        [Test]
        public void CanCreateNewAdvertisement()
        {
            CarShopEntity carShopEntity = new CarShopEntity
            {
                AdvertisementId = 555,
                City = "Helsingborg",
                CarModel = "Sedan",
                Fuel = "Diesel",
                GearBox = "Manuell",
                Mileage = 24525,
                ModelYear = "2018-04-08",
                ManufacturingYear = DateTime.Today,
                Price = 24000,
                Description = "Wonderful car",
                Title = "Volvo",
                PostalNumber = "2545",
                AdvertisementDay = DateTime.Today
                
            };
            carShopSystem.CreateNewCar(carShopEntity);

            Assert.True(carShopEntity != null);
            Assert.AreSame("Sedan", carShopEntity.CarModel);
            
            //var result = carShopSystem.AdvertismentInformation(carShopEntity.AdvertisementId);
            //Assert.AreEqual(carShopEntity.AdvertisementId, 555);
        }
        [Test]
        [TestCase("", "")]
        public void CanCreateCar_WillFailIfEmpty(string title, string param)
        {
            CarShopEntity carShopEntity = new CarShopEntity()
            {
                AdvertisementId = 0,
                City = "",
                CarModel = "",
                Fuel = "",
                GearBox = "",
                Mileage = 24525,
                ModelYear = "",
                ManufacturingYear = DateTime.Today,
                Price = 24000,
                Description = "",
                Title = title,
                PostalNumber = "",
                AdvertisementDay = DateTime.Today
            };
            carShopSystem.CreateNewCar(carShopEntity);
            //Assert.Throws<ArgumentNullException>(() =>  carShopSystem.CreateNewCar(carShopEntity));
            //Assert.That(ex.Message, Is.EqualTo("Some Parameters in the Advertisment cant be null"));
        }
        [Test]
        public void CanEditCar_ReturnNewValue()
        {
            carShopEntity = new CarShopEntity
            {
                AdvertisementId = 555,
                City = "Helsingborg",
                CarModel = "Sedan",
                Fuel = "Diesel",
                GearBox = "Manuell",
                Mileage = 24525,
                ModelYear = "2018-04-08",
                ManufacturingYear = DateTime.Today,
                Price = 24000,
                Description = "Wonderful car",
                Title = "Volvo",
                PostalNumber = "2545",
                AdvertisementDay = DateTime.Today

            };
            carShopSystem.EditCar(carShopEntity);
            var result = carShopSystem.AdvertismentInformation(carShopEntity.AdvertisementId );
            Assert.AreEqual(carShopEntity.AdvertisementId, 555);
            Assert.That(carShopEntity != null);
        }
        //[Test]
        //public void ListExtistingData_ValidCall()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        mock.Mock<ICarShopSystem>().Setup(x => x.ListExistingCars())
        //            .Returns(ListOfCars());
        //        var cls = mock.Create<CarShopSystem>();
        //        var expected = ListOfCars();

        //        var actual = cls.ListExistingCars();

        //        Assert.True(actual != null);
        //        Assert.AreEqual(expected.Count(), 2);
        //        Assert.False(actual == null);

        //    }
        //}
        //[Test]
        //public void CreateNewCar_ValidCall()
        //{

        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        CarShopEntity car = new CarShopEntity
        //        {
        //            AdvertisementId = 1,
        //            City = "Helsingborg",
        //            CarModel = "Sedan",
        //            Fuel = "Diesel",
        //            GearBox = "Manuell",
        //            Mileage = 24525,
        //            ModelYear = "2018-04-08",
        //            ManufacturingYear = DateTime.Today,
        //            Price = 24000,
        //            Description = "Wonderful car",
        //            Title = "Volvo",
        //            PostalNumber = "2545",
        //            AdvertisementDay = DateTime.Today
        //        };
        //        mock.Mock<ICarShopSystem>().Setup(x => x.CreateNewCar(car));
        //        var cls = mock.Create<CarShopSystem>();
        //        cls.CreateNewCar(car);
        //    }
        //}
        //[Test]
        //public void CantCreateCar_ThowExeption()
        //{

        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        CarShopEntity car = new CarShopEntity
        //        {
        //            AdvertisementId = 1,
        //            City = "Helsingborg",
        //            CarModel = "Sedan",
        //            Fuel = "Diesel",
        //            GearBox = "Manuell",
        //            Mileage = 24525,
        //            ModelYear = "2018-04-08",
        //            ManufacturingYear = DateTime.Today,
        //            Price = 24000,
        //            Description = "Wonderful car",
        //            Title = "Volvo",
        //            PostalNumber = "2545",
        //            AdvertisementDay = DateTime.Today
        //        };
        //        mock.Mock<ICarShopSystem>().Setup(x => x.CreateNewCar(car));
        //        var cls = mock.Create<CarShopSystem>();
        //        cls.CreateNewCar(car);


        //    }
        //}
        public IEnumerable<CarShopEntity> ListOfCars()
        {
            List<CarShopEntity> dataObj = new List<CarShopEntity>
            {
                new CarShopEntity
                {
                    AdvertisementId = 1,
                    City = "Helsingborg",
                    CarModel = "Sedan",
                    Fuel = "Diesel",
                    GearBox = "Manuell",
                    Mileage = 24525,
                    ModelYear = "2018-04-08",
                    ManufacturingYear = DateTime.Today,
                    Price = 24000,
                    Description = "Wonderful car",
                    Title = "Volvo",
                    PostalNumber = "2545",
                    AdvertisementDay = DateTime.Today
                },
                new CarShopEntity
                {
                    AdvertisementId = 1,
                    City = "Malmö",
                    CarModel = "Kombi",
                    Fuel = "Bensin",
                    GearBox = "Automat",
                    Mileage = 14525,
                    ModelYear = "2018-04-06",
                    ManufacturingYear = DateTime.Today,
                    Price = 42000,
                    Description = "Wonderful car",
                    Title = "Volvo",
                    PostalNumber = "2545",
                    AdvertisementDay = DateTime.Today
                },
            };
            return dataObj;
        }
    }
}
