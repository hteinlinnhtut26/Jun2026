using June2026ConsoleApp3;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

AdoDotNetService service = new AdoDotNetService();
service.Read();
service.Create();
service.Update();
service.Delete();
Console.ReadLine();
