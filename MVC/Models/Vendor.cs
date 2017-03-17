using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Vendor
    {
        [Required(ErrorMessage = "*")]
        public string OwnerName { set; get; }

        [Required(ErrorMessage = "*")]
        [PasswordPropertyText]
        public string Password { set; get; }

        [Required(ErrorMessage = "*")]
        public string CompanyName { set; get; }

        [Required(ErrorMessage = "*")]
        [EmailAddress()]
        public string Email { set; get; }

        [Required(ErrorMessage = "*")]
        public string Address { set; get; }


        public static bool InsertVendor(Vendor vendor)
        {
            bool sucess = false;
            var path = System.Web.HttpContext.Current.Server.MapPath(@"~/neutronstore.mdb");

            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                      @"Data Source=" + path + ";Persist Security Info=False";


            OleDbConnection dbConn = new OleDbConnection(connectionString);

            // Open connection
            dbConn.Open();
            using (dbConn)
            {
                OleDbCommand cmd = new OleDbCommand(
                    "INSERT INTO vendors ([OwnerName], [VendorPassword], [CompanyName] ,[VendorEmail], [VendorAddress]) VALUES (@owner, @pass, @cn, @email, @address)",
                    dbConn);

                cmd.Parameters.AddWithValue("@owner", vendor.OwnerName);
                cmd.Parameters.AddWithValue("@pass", vendor.Password);
                cmd.Parameters.AddWithValue("@cn", vendor.CompanyName);
                cmd.Parameters.AddWithValue("@email", vendor.Email);
                cmd.Parameters.AddWithValue("@address", vendor.Address);

                // Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    sucess = true;

                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("SQL Error occured: " + exception);
                }
            }
            return sucess;
        }
    }
}