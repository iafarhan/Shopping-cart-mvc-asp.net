using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Product
    {
        string id, name, barcode, brandName, price;
        public string ID { 
       set{ id = value; }
        get{ return id; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string BarCodeNumber
        {
            set { barcode = value; }
            get { return barcode; }
        }
        public string Price
        {
            set { price = value; }
            get { return price; }
        }
    }
}