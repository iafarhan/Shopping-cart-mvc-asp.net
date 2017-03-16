using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class User
    {
//        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

//        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

//        [Required(ErrorMessage = "*")]
//        [EmailAddress(ErrorMessage = "Please enter valid email address!")]
        public string Email { get; set; }

//        [Required(ErrorMessage = "*")]
        public string Gender { get; set; }

//        [Required(ErrorMessage = "10-100")]
//        [Range(10, 100)]
        public int Age { get; set; }

        public static void InsertUser(User user)
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
                    "INSERT INTO users ([UserEmail], [UserName], [UserPassword] ,[UserGender], [UserAge]) VALUES (@email, @name, @pass, @gender, @age)",
                    dbConn);

                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@pass", user.Password);
                cmd.Parameters.AddWithValue("@gender", user.Gender);
                cmd.Parameters.AddWithValue("@age", user.Age);

                // Execute command
                try
                {
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