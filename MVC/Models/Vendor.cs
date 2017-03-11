using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Vendor
    {
        string ownerName, password, companyName, email, address;

        public string OwnerName
        {
            set { ownerName = value; }
            get { return ownerName; }
        }


        public string Password
        {
            set { password = value; }
            get { return password; }
        }


        public string CompanyName
        {
            set { companyName = value; }
            get { return companyName; }
        }

        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        public string Address
        {
            set { address = value; }
            get { return address; }
        }


        public static void InsertVendor(Vendor vendor)
        {
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

                cmd.Parameters.AddWithValue("@owner", vendor.ownerName);
                cmd.Parameters.AddWithValue("@pass", vendor.password);
                cmd.Parameters.AddWithValue("@cn", vendor.companyName);
                cmd.Parameters.AddWithValue("@email", vendor.email);
                cmd.Parameters.AddWithValue("@address", vendor.address);

                // Execute command
                try
                {
                    //cmd.Parameters["@user"].Value = "tooooooooooooooooooooooooooooooooooo long user name";
                    cmd.ExecuteNonQuery();

                    //  Console.WriteLine("Row inserted successfully.");
                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("SQL Error occured: " + exception);
                }
            }
        }
    }
}