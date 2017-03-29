using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Product
    {
        
        public string ID { set; get; }

        public string ProductName { set; get; }

        
        public string DefaultPrice { set; get; }

        public string Price { set; get; }

        public byte[] Image { get; set; }

    }
}