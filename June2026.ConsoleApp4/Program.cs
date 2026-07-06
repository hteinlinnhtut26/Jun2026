
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using June2026.ConsoleApp4;

Console.WriteLine("---Login----");
Console.Write("Pls enter your username: ");
string username = Console.ReadLine();
Console.Write("Enter your password: ");
string password =Console.ReadLine();
LoginService loginService = new LoginService();
loginService.Login(username, password);
Console.ReadLine();
DapperService dapservice = new DapperService();
/*dapservice.Read();
dapservice.Create();
dapservice.Update();
dapservice.Delete();*/
public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string FatherName { get; set; }
    public string StudentNo {  get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string MoobileNo { get; set; }
    public Boolean IsDelete { get; set; }

}