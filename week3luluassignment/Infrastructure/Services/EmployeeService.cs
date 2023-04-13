using System;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
	{
        EmployeeRepository employeeRepository;
        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }

        public void AddEmployee()
        {
            Employees e = new Employees();
            Console.Write("Enter first name of an employee: ");
            e.FirstName = Console.ReadLine();
            Console.Write("Enter last name of an employee: ");
            e.LastName = Console.ReadLine();
            Console.Write("Enter salary of an employee: ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter department id of an employee: ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());

            if (employeeRepository.Insert(e) > 0) //Reflects the number of records impacted
            {
                Console.WriteLine("Successfully Inserted");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Id number to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            employeeRepository.DeleteById(id);
        }

        public void GetAllEmployee()
        {
            IEnumerable<Employees> employees = employeeRepository.GetAll();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Id} \t {emp.FirstName} \t {emp.LastName} \t {emp.Salary} \t {emp.DeptId} ");
            }
        }

        public Employees GetEmployeeById()
        {
            Console.Write("Enter Employee Id number: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employees employee = employeeRepository.GetById(id);
            Console.WriteLine($"{employee.Id} \t {employee.FirstName} \t {employee.LastName} \t {employee.Salary} \t {employee.DeptId}");
            return employee;
        }

        public void UpdateEmployee()
        {
            var eu = GetEmployeeById();
            Console.Write("Enter New First Name: ");
            eu.FirstName = Console.ReadLine();
            Console.Write("Enter New Last Name: ");
            eu.LastName = Console.ReadLine();
            Console.Write("Enter New Salary: ");
            eu.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter New department id: ");
            eu.DeptId = Convert.ToInt32(Console.ReadLine());
            employeeRepository.Update(eu);
        }
    }
}

