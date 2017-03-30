using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Product
    {
        

        public string Name { set; get; }
        public string Quantity{ set; get; }
        
        public string Price { set; get; }

        public string Description{ set; get; }
        public byte[] Image { get; set; }

    }
}