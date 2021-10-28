namespace Northwind_SQLite_ConsoleApp
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{EmployeeID, 5} {FirstName, -10}  {LastName,-13}";
        }
    }
}
