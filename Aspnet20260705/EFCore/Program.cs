// See https://aka.ms/new-console-template for more information
using EFCore.HrModels;

Console.WriteLine("Hello, World!");

var db = new HrContext();

var numOfEmps = db.Employees.Count();

var empKing = db.Employees.Where(e => e.LastName == "King").First();

Console.WriteLine($"#Employees: {numOfEmps}");
Console.WriteLine(empKing.Salary);
