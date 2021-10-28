using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Northwind_SQLite_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NonQuerySample();

            Console.ReadKey();
        }

        private static void ExecuteReaderSample()
        {
            var _list = new List<Employees>();
            var cmd = new SQLiteCommand()
            {
                CommandText = "Select EmployeeID, FirstName, LastName From Employees"
            };
            var ds = DMS.SQLiteExecuteReader(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                _list.Add(new Employees()
                {
                    EmployeeID = int.Parse(item[0].ToString()),
                    FirstName = item[1].ToString(),
                    LastName = item[2].ToString()
                });
                //Console.WriteLine(item[0].ToString() + " "+ item[1].ToString() + " " + item[2].ToString());
            }

            _list.ForEach(e => Console.WriteLine(e));
            Console.WriteLine("Number of record: {0}", _list.Count);
        }

        private static void NonQuerySample()
        {
            var cmd = new SQLiteCommand()
            {
                CommandText = "INSERT INTO Employees(FirstName, LastName) Values(@FirstName , @LastName)"
            };
            cmd.Parameters.AddWithValue("FirstName", "Burcu");
            cmd.Parameters.AddWithValue("LastName", "Ekşi");

            var result = DMS.SQLiteExecuteNonQuery(cmd);
            Console.WriteLine("{0}", result == 1 ? "Successed." : "Failed!");
        }
    }
}
