using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTutorialMarch.Menu
{
    public class MenuSelection
    {
        DepartmentService e;
        EmployeeService d;

        public MenuSelection()
        {
            e = new DepartmentService();
            d = new EmployeeService();
        }
        public void Run()
        {
            e.AddDepartment();
            e.DeleteDepartment();
            e.GetAllDepartments();
            e.UpdateDepartment();
            e.GetDepartmentById();

            d.AddEmployee();
            d.DeleteEmployee();
            d.GetAllEmployee();
            d.UpdateEmployee();
            d.GetEmployeeById();
        }

        public int InputChoice()
        {
            var choice = 0;
            return choice;
        }
    }
}
