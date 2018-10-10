using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWebShop.Models
{
    public class SearchModel
    {
        public string SearchName { get; set; }
        public List<CarShopModel> CarItems { get; set; }

    }
}