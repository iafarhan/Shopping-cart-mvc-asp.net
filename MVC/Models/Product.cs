using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Product
    {
        string brandName;

        public Product(string brandName)
        {
            this.brandName = brandName;
        }

        public string ID { set; get; }

        public string Name { set; get; }

        public string BarCodeNumber { set; get; }

        public string Price { set; get; }
    }
}