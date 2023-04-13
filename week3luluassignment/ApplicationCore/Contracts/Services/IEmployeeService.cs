using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
	public interface IEmployeeService
	{
        void AddEmployee();
        void DeleteEmployee();
        void GetAllEmployee();
        Departments GetEmployeeById();
        void UpdateEmployee();
    }
}

