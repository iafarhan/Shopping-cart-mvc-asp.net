using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Login
    {
        /// <summary>
        /// username is basically the email later on we can do the check on both the username and email
        /// </summary>
//        [Required(ErrorMessage = "Please enter your username")]
        public string username { set; get; }

//        [Required(ErrorMessage = "PLease enter your password.")]
        public string password { set; get; }


        public static Boolean CheckLogin(Login login)
        {
            bool sucess = false;
            var path = System.Web.HttpContext.Current.Server.MapPath(@"~/neutronstore.mdb");

            var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                   @"Data Source=" + path + ";Persist Security Info=False";


            OleDbConnection dbConn = new OleDbConnection(connectionString);

            // Open connection
            dbConn.Open();
            using (dbConn)
            {
                var email = login.username;
                var pass = login.password;

                OleDbCommand cmd =
                    new OleDbCommand(
                        "Select * FROM users WHERE UserEmail='" + email + "' && UserPassword='" + pass + "'", dbConn);


                // Execute command
                try
                {
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.Read() == true)
                    {
                        var username = reader.GetString(1).ToString();
                        var pss = reader.GetString(1).ToString();
                        if (username == email && pss == pass)
                            sucess = true;
                    }
                    sucess = true;

                    //  Console.WriteLine("Row inserted successfully.");
                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("SQL Error Occured: " + exception);
                }
            }
            return sucess;
        }
    }
}