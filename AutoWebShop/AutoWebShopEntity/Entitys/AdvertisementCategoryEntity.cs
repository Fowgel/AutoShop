using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Entitys
{
    public class AdvertisementCategoryEntity
    {
        public int ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        
    }
    public class ChildCategoryEntity
    {
        public int ChildCategoryId { get; set; }
        public string ChildCategoryName { get; set; }
    }
}
