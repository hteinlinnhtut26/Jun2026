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
    internal class DapperService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "June2026Db",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true

        };
        public void Read() {

            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                List<Student> lst = db.Query<Student>("SELECT * FROM [dbo].[Tbl_Student];").ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine($"id: {item.StudentId}, name: {item.StudentName}");
                }
                int result = db.Execute("Delete From Tbl_Student where StudentId = 12");
                Console.WriteLine($"Row affected {result}");
            }
        }
        public void Create() {
            
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute(@"INSERT INTO [dbo].[Tbl_Student]
    ([StudentName],
     [FatherName],
     [StudentNo],
     [Email],
     [DateOfBirth],
     [MoobileNo],
     [IsDelete])
VALUES
('Du Du', 'U KO KO', 'STU006', 'myamya@gmail.com', '2002-11-08', '09765432109', 0),
('Bu Bu', 'U Aung Myo', 'STU0010', 'kyawkyaw@gmail.com', '2001-07-30', '09811223344', 0)");
                Console.WriteLine("Create Successful");
            }
        }
        public void Update() {

            using(IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute(@"UPDATE Tbl_Student
SET
    StudentName = 'Du Du Lay',
    FatherName = 'U Hla Win',
    Email = 'kokoaung@gmail.com',
    DateOfBirth = '2003-04-15',
    MoobileNo = '09999888777'
WHERE StudentNo = 'STU006'");
                Console.WriteLine("Update Successful");
            }
        
        }
        public void Delete() {

            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute("Delete From Tbl_Student where StudentId = 12");
                Console.WriteLine($"Row affected {result}");
            }
        }

    }
}
