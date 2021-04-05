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
    class Polaczenie
    {
        private IDbConnection _connection;
        public Polaczenie(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        public IEnumerable<Employees> GetEmployees()
        {
            return _connection.Query<Employees>("SELECT * FROM Employees");
        }
        public Employees GetEmployeesByID(string id)
        {
            return _connection.QuerySingleOrDefault<Employees>("SELECT  * FROM  Employees WHERE EmployeeID = @ID", new { ID = id });
        }
        public bool Dodaj(Employees employees)
        {
            var result = _connection.Execute("INSERT INTO Employees(LastName, FirstName) VALUES(@Last, @First)", 
                new { Last = employees.LastName, First = employees.FirstName });
            return result == 1;
        }
        public Employees Zmiana(string id, string last, string first)
        {
            return _connection.QuerySingleOrDefault<Employees>("UPDATE Employees SET LastName = @LastName Where EmployeeID = @ID", new { ID = id, LastName = last, FirstName = first });
        }
        public Employees usun(string id)
        {
            return _connection.QuerySingleOrDefault<Employees>("DELETE Employees where EmployeeID=@ID", new { ID = id });
        }
    }
    
}
