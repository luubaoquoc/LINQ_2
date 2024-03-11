    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_2
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public DateTime Birthday { get; set; }
        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee {ID=1, Name="A", DepartmentID=1, Age=18, Salary=400, Birthday=new DateTime(2005,10,15)},
                new Employee {ID=2, Name="B", DepartmentID=2, Age=19, Salary=300, Birthday=new DateTime(2004,10,15)},
                new Employee {ID=3, Name="C", DepartmentID=3, Age=20, Salary=500, Birthday=new DateTime(2003,10,15)},
                new Employee {ID=4, Name="D", DepartmentID=1, Age=18, Salary=300, Birthday=new DateTime(2005,10,15)},
                new Employee {ID=5, Name="E", DepartmentID=2, Age=22, Salary=700, Birthday=new DateTime(2002,10,15)},
            };
        }
    }
}
