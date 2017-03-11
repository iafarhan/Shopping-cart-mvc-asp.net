using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class User
    {
        string name, password, email, gender;
        int age;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public string Email
        {
            set { email = value; }
            get { return email; }
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

                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@name", user.name);
                cmd.Parameters.AddWithValue("@pass", user.password);
                cmd.Parameters.AddWithValue("@gender", user.gender);
                cmd.Parameters.AddWithValue("@age", user.age);

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