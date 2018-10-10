using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AutoWebShopEntity.Entitys
{
   public class CarShopEntity
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
        public string AdvertisementCategory { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSold { get; set; }
        public string ChildCategory { get; set; }
        public List<PictureEntity> Files { get; set; }
        public List<HttpPostedFileBase> Picture { get; set; }
    }
}
