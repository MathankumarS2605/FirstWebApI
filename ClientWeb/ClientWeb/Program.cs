// See https://aka.ms/new-console-template for more information
using ClientWeb;

Console.WriteLine("Hello, World!");
EmployeeAPIClient.CallGetEmployee().Wait();
EmployeeAPIClient.CallGetEmployeeObj().Wait();
Console.ReadLine();