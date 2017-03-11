using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Customer
    {
        string name;
        string gender;
        int age;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Gender
        {
            set { gender = value; }
            get { return gender; }
        }

        public int Age
        {
            set { age = value; }
            get { return age; }
        }
    }
}