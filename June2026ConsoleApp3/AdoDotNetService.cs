using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026ConsoleApp3;

internal class AdoDotNetService
{
    private readonly SqlConnectionStringBuilder sb;

    public AdoDotNetService()
    {
        sb = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "June2026DB",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
    }
    public void Read()
    {
        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        
        connection.Open();       
        String query = @"SELECT [StudentId]
      ,[StudentName]
      ,[FatherName]
      ,[StudentNo]
      ,[Email]
      ,[DateOfBirth]
      ,[MoobileNo]
      ,[IsDelete]
  FROM [dbo].[Tbl_Student]
";

        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        //DataSet
        //DataTable
        //DataRow
        //DataColumn

        List<Student> lst = new List<Student>();

        foreach (DataRow row in dt.Rows)
        {
            Student student = new Student
            {
                StudentId = Convert.ToInt32(row["StudentId"]),
                StudentName = Convert.ToString(row["StudentName"]),
                FatherName = Convert.ToString(row["FatherName"]),
                StudentNo = Convert.ToString(row["StudentNo"]),
                Email = Convert.ToString(row["Email"]),
                DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                MoobileNo = Convert.ToString(row["MobileNo"]),
                IsDelete = Convert.ToBoolean(row["IsDelete"]),
            };
            lst.Add(student);
            
        }
        
    }
    public void Create()
    {

        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        connection.Open();

        String query = @"INSERT INTO [dbo].[Tbl_Student]
    ([StudentName],
     [FatherName],
     [StudentNo],
     [Email],
     [DateOfBirth],
     [MoobileNo],
     [IsDelete])
VALUES
('Aung Aung', 'U Kyaw Win', 'STU001', 'aungaung@gmail.com', '2002-01-15', '09123456789', 0),
('Su Su', 'U Than Lwin', 'STU002', 'susu@gmail.com', '2001-05-22', '09987654321', 0),
('Ko Ko', 'U Hla Myint', 'STU003', 'koko@gmail.com', '2003-03-10', '09456781234', 0),
('Mya Mya', 'U Win Naing', 'STU004', 'myamya@gmail.com', '2002-11-08', '09765432109', 0),
('Kyaw Kyaw', 'U Aung Moe', 'STU005', 'kyawkyaw@gmail.com', '2001-07-30', '09811223344', 0)";

        SqlCommand cmd = new SqlCommand(query,connection);
        cmd.ExecuteNonQuery();
    }
    public void Update()
    {

        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        connection.Open();
       

        String query = @"UPDATE Tbl_Student
SET
    StudentName = 'Ko Ko Aung',
    FatherName = 'U Hla Win',
    Email = 'kokoaung@gmail.com',
    DateOfBirth = '2003-04-15',
    MoobileNo = '09999888777'
WHERE StudentNo = 'STU004'";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.ExecuteNonQuery();
    }
    public void Delete()
    {
        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        connection.Open();

        String query = @"DELETE FROM Tbl_Student
WHERE StudentNo = 'STU003'";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.ExecuteNonQuery();
    }
  public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string StudentNo { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MoobileNo { get; set; }
        public Boolean IsDelete { get; set; }

    }
}
