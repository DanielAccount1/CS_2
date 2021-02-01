using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Employees_
{
    class Program
    {
        static void EmployeesInputInConsole(Employee[] employees)
        {
            ArrayEmployees arrayEmployees = new ArrayEmployees(employees);
            foreach (Employee employee in arrayEmployees)
                Console.WriteLine("Name: {0}| Date of birth: {1}", employee.Name, employee.DateOfBirth.ToShortDateString());
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[4] 
            {
                new HourlyEmployee("Ben", new DateTime(1985, 01, 01)),
                new MonthlyEmployee("Arnold", new DateTime(1985, 02, 01)),
                new MonthlyEmployee("Dan", new DateTime(1990, 09, 04)),
                new HourlyEmployee("Ethan", new DateTime(1983, 04, 03)) 
            };
            Console.WriteLine("Initial array");
            EmployeesInputInConsole(employees);

            Array.Sort(employees);
            Console.WriteLine("Internal sort (ByDate)");
            EmployeesInputInConsole(employees);

            Array.Sort(employees, new SortByName());
            Console.WriteLine(new SortByName().ToString());
            EmployeesInputInConsole(employees);

            Array.Sort(employees, new SortByDate());
            Console.WriteLine(new SortByDate().ToString());
            EmployeesInputInConsole(employees);

            Console.WriteLine("Internal foreach with List collection");
            ListEmployees listEmployees = new ListEmployees(employees);
            foreach (Employee employee in listEmployees)
                Console.WriteLine("Name: {0}| Date of birth: {1}", employee.Name, employee.DateOfBirth.ToShortDateString());

            Console.ReadKey();
        }
    }
}
