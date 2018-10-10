using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Entitys
{
    public class PictureEntity
    {
        public Guid PictureGuid { get; set; }
        public string PictureGuidName { get; set; }
        public string PictureName { get; set; }
        public int AdvertisementId { get; set; }
    }
}
