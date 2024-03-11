using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_2
{
    class Program
    {
        

        static void Main(string[] args)
        {


            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\n");
                Console.WriteLine("----------Menu---------------");
                Console.WriteLine("1. Max min average salary của Employee trong list đã nhập.");
                Console.WriteLine("2. Viết Join group, left, right");
                Console.WriteLine("3. In max, min tuổi của Employee trong list.");
                Console.WriteLine("\n");
                Console.Write("Nhập lựa chọn:");
                int chose = int.Parse(Console.ReadLine());
                Console.WriteLine("----------------------------");
                switch (chose)
                {
                    case 1:
                        MAXMINAVGofSalary();
                        break;
                    case 2:
                        Join();
                        break;
                    case 3:
                        MAXMINofBirthday();
                        break;
                }
            }
            }

            static void MAXMINAVGofSalary()
            {
                List<Employee> employees = Employee.GetEmployees();

                double maxSalary = employees.Max(emp => emp.Salary);

                double minSalary = employees.Min(emp => emp.Salary);

                double avgSalary = employees.Average(emp => emp.Salary);

                Console.WriteLine($"MaxSalary: {maxSalary}");
                Console.WriteLine($"MinSalary: {minSalary}");
                Console.WriteLine($"avgSalary: {avgSalary}");
            }    
            

            static void Join()
            {
            // Join group
            List<Departmant> departments = Departmant.getDepartmants();
            List<Employee> employees = Employee.GetEmployees();
            /*var results = employees.GroupJoin(departments,
                                emp => emp.DepartmentID,
                                dept => dept.ID,
                                (emp, dept) => new
                                {
                                    Employee = emp,
                                    Departments = dept
                                });

            foreach (var item in results)
            {
                Console.WriteLine($"Employee: {item.Employee.Name}");
                foreach (var dept in item.Departments)
                {
                    Console.WriteLine($" - Department: {dept.Name}");
                }
            };*/

            // Sử dụng method syntax để thực hiện left join giữa danh sách nhân viên và phòng ban
            var result = employees.GroupJoin(departments,
                            emp => emp.DepartmentID,
                            dept => dept.ID,
                            (emp, deptGroup) => new
                            {
                                EmployeeName = emp.Name,
                                DepartmentName = deptGroup.Select(d => d.Name).DefaultIfEmpty("Unknown").First(),
                                Salary = emp.Salary
                            });

            // Hiển thị kết quả
            foreach (var item in result)
            {
                Console.WriteLine($"Employee: {item.EmployeeName}, Department: {item.DepartmentName}, Salary: {item.Salary}");
            }

            /*// join right
            var resultt = departments.GroupJoin(employees,
                                dept => dept.ID,
                                emp => emp.DepartmentID,
                                (dept, empGroup) => new
                                {
                                    Department = dept,
                                    Employees = empGroup
                                })
                                .SelectMany(
                                    deptEmpGroup => deptEmpGroup.Employees.DefaultIfEmpty(),
                                    (deptEmpGroup, emp) => new
                                    {
                                        DepartmentID = deptEmpGroup.Department.ID,
                                        DepartmentName = deptEmpGroup.Department.Name,
                                        EmployeeName = emp != null ? emp.Name : "No Employee"
                                    });

            foreach (var item in resultt)
            {
                Console.WriteLine($"Department ID: {item.DepartmentID}, Department Name: {item.DepartmentName}, Employee Name: {item.EmployeeName}");
            }*/
        }

        static void MAXMINofBirthday()
        {

            List<Employee> employees = Employee.GetEmployees();
            // Lấy ngày tháng năm hiện tại
            DateTime currentDate = DateTime.Now;

            // Tính toán tuổi của từng nhân viên
            var ages = employees.Select(emp => currentDate.Year - emp.Birthday.Year - (currentDate.DayOfYear < emp.Birthday.DayOfYear ? 1 : 0));

            // Tìm tuổi nhỏ nhất và lớn nhất
            int minAge = ages.Min();
            int maxAge = ages.Max();

            Console.WriteLine($"Min Age: {minAge}");
            Console.WriteLine($"Max Age: {maxAge}");

            Console.ReadLine();
        }
           
            
        }
    }

