using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Employees_
{
    abstract class Employee : IComparable
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        abstract public double AverageMonthlySalary(double rate);

        public int CompareTo(object obj)
        {
            Employee employee = obj as Employee;
            if (employee == null) return -1;
            if (DateOfBirth > employee.DateOfBirth) return 1;
            if (DateOfBirth == employee.DateOfBirth) return 0;
            return -1;
        }

        public Employee(string name, DateTime dateOfBirth)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }
    }

    class HourlyEmployee : Employee
    {
        public HourlyEmployee(string name, DateTime dateOfBirth) : base(name, dateOfBirth)
        {

        }
        public override double AverageMonthlySalary(double rate) => 20.8 * 8.0 * rate;
    }

    class MonthlyEmployee : Employee
    {
        public MonthlyEmployee(string name, DateTime dateOfBirth) : base(name, dateOfBirth)
        {

        }
        public override double AverageMonthlySalary(double rate) => rate;
    }

    class ArrayEmployees : IEnumerable, IEnumerator
    {
        Employee[] Employees;
        int i = -1;
        public ArrayEmployees(Employee[] employees)
        {
            this.Employees = employees;
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public bool MoveNext()
        {
            if (i == Employees.Length - 1)
            {
                Reset();
                return false;
            }
            i++;
            return true;
        }
        public void Reset()
        {
            i = -1;
        }
        public object Current
        {
            get
            {
                return Employees[i];
            }
        }
    }

    class ListEmployees : IEnumerable
    {
        List<Employee> Employees;
        public ListEmployees(Employee[] employees)
        {
            Employees = employees.ToList();
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Employees.Count; i++)
                yield return Employees.ElementAt(i);
        }
    }

    class SortByName : IComparer
    {
        public int Compare(object x, object y)
        {
            return string.Compare((x as Employee).Name, (y as Employee).Name);
        }
    }

    class SortByDate : IComparer
    {
        public int Compare(object x, object y)
        {
            Employee employee1 = x as Employee;
            Employee employee2 = y as Employee;
            if (employee1.DateOfBirth > employee2.DateOfBirth)
                return 1;
            if (employee1.DateOfBirth < employee2.DateOfBirth)
                return -1;
            return 0;
        }
    }
}
