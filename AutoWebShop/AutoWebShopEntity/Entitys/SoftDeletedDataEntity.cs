using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Entitys
{
    public class SoftDeletedDataEntity
    {
        public int AdvertisementId { get; set; }
        public string AdvertisementCategory { get; set; }
        public DateTime TimeDeleted { get; set; }
        public string Description { get; set; }
    }
}
