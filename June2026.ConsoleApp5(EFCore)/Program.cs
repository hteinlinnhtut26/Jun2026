// See https://aka.ms/new-console-template for more information
using June2026.ConsoleApp5_EFCore_;
using June2026.Database.AppDbContextModels;
using System.Collections.Specialized;

Console.WriteLine("Hello, World!");

June2026AppDbContext db = new June2026AppDbContext();
//CRUD
//Read

//LINQ
List<StaffEntity> lst = db.Staffs.ToList();

foreach (var item in lst)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Name);
    Console.WriteLine("================");
}

//var staff2 = db.Staffs.Where(x => x.Id == 5).FirstOrDefault();

//StaffEntity staffEntity = new StaffEntity()
//{
//    Name = "Htut Htut"
//};

//db.Staffs.Add(staffEntity);

var staff = db.Staffs.Where(x => x.Id == 1).FirstOrDefault();

//if(staff is null)
//{
//    Console.WriteLine("Staff Not Found");
//}
//else
//{
//    staff.Name = "Ko Maung";
//    int result = db.SaveChanges();
//}

var staff2 = db.Staffs.Where(x =>x.Id == 2).FirstOrDefault();
if(staff is null)
{
    Console.WriteLine("Staff Not Found");
    return;
}
db.Staffs.Remove(staff2);
db.SaveChanges();

AppDbContext db2 = new AppDbContext();
var lst2 = db2.TblStaffs.ToList();
var lst3 = db2.TblStudents.ToList();

db2.TblStaffs
    .OrderBy(x => x.StaffName);
db2.TblStudents
    .Where(x => x.IsDelete == false)
    .OrderBy(x => x.StudentName);

Console.ReadLine();