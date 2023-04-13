using ApplicationCore.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        DepartmentRepository departmentRepository;
        public DepartmentService()
        {
            departmentRepository = new DepartmentRepository();
        }


        public void AddDepartment()
        {
            Departments d = new Departments();
            Console.Write("Enter name of Department: ");
            d.DeptName = Console.ReadLine();
            Console.Write("Enter Location: ");
            d.Location = Console.ReadLine();

            if (departmentRepository.Insert(d) > 0) //Reflects the number of records impacted
            {
                Console.WriteLine("Successfully Inserted");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public void DeleteDepartment()
        {
            Console.Write("Enter Id number to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            departmentRepository.DeleteById(id);
        }

        public void UpdateDepartment()
        {
            var dC = GetDepartmentById();
            Console.Write("Enter New Dept Name: ");
            dC.DeptName = Console.ReadLine();
            Console.Write("Enter New Location: ");
            dC.Location = Console.ReadLine();
            departmentRepository.Update(dC);
        }

        public Departments GetDepartmentById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Departments department = departmentRepository.GetById(id);
            Console.WriteLine($"{department.Id} \t {department.DeptName} \t {department.Location}");
            return department;
        }

        public void GetAllDepartments()
        {
            IEnumerable<Departments> departments = departmentRepository.GetAll();
            foreach(var dept in departments)
            {
                Console.WriteLine($"{dept.Id} \t {dept.DeptName} \t {dept.Location}");
            }
        }
    }
}
