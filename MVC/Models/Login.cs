using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.OleDb; 
using System.Linq;
using System.Web;
 //starting work
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

        /// <summary>
        /// It will login the customer when he/she enters the correct login details
        /// </summary>
        /// <param name="login">The object from the view</param>
        /// <returns>If the login is sucessful it will return true other wise false</returns>
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
                string query = "SELECT * FROM users WHERE UserEmail= '" + email + "' and UserPassword= '" + pass + "';";
                OleDbCommand cmd =new OleDbCommand(query, dbConn);


                // Execute command
                try
                {
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.Read() == true)
                    {
                        var username = reader.GetString(1).ToString();
                        var pss = reader.GetString(2).ToString();
                        if (username == email && pss == pass)
                            sucess = true;
                    }

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