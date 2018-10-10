using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWebShop.Models
{
    public class AdvertisementCategoryModel
    {
        public int ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        
    }
    public class ChildClass
    {
        public int ChildCategoryId { get; set; }
        public string ChildName { get; set; }
    }
}