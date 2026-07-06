using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp4
{ 
    internal class LoginService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "June2026Db",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,

        };
        public void Login(string username, string password)
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                string qurery = $"select * from Table_Acc where Username = @usernameVar and Password = @passwordVar";
                var user = db.Query(qurery, new 
                {   usernameVar = username,
                    passwordVar = password}).FirstOrDefault();
                if (user != null)
                {
                    Console.WriteLine("Login Successful");

                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
        }
 }
}
