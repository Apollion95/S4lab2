using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace S4lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var polaczenie = new Polaczenie(@"Data Source=DESKTOP-BR95J8J\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;MultipleActiveResultSets=True");
            foreach (Employees employees in polaczenie.GetEmployees())
            {
                Console.WriteLine($"{employees.EmployeeID} - {employees.LastName}, {employees.FirstName}");
            }
            Console.ReadKey();
            polaczenie.Dodaj(new Employees() { LastName = "Szybalski", FirstName = "Jan" });
            Console.WriteLine("Dodanie");
            Console.ReadKey();
            foreach (Employees employees in polaczenie.GetEmployees())
            {
                Console.WriteLine($"{employees.EmployeeID} - {employees.LastName}, {employees.FirstName}");
            }
            Console.ReadKey();
            Console.WriteLine("Zmiana");
            polaczenie.Zmiana("13", "Lee", "Tomasz");
            foreach (Employees employees in polaczenie.GetEmployees())
            {
                Console.WriteLine($"{employees.EmployeeID} - {employees.LastName}, {employees.FirstName}");
            }
            Console.ReadKey();
            Console.WriteLine("Usuniecie");
            polaczenie.usun("13");
            foreach (Employees employees in polaczenie.GetEmployees())
            {
                Console.WriteLine($"{employees.EmployeeID} - {employees.LastName}, {employees.FirstName}");
            }
            Console.ReadKey();
        }
    }
}
