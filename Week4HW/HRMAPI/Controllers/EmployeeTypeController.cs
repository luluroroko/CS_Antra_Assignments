using System;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMAPI.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("[employeetype_controller]")]

public class EmployeeTypeController : ControllerBase
{
    private readonly IEmployeeTypeService _Es;
    public EmployeeTypeController(IEmployeeTypeService employeetypeservice)
    {
        _Es = employeetypeservice;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<EmployeeType> employeetypes = _Es.GetAllEmployeeType().ToList();
        return Ok(employeetypes);
    }

    [HttpPost]
    public IActionResult Insert(string typeName)
    {

        var employeeType = new EmployeeType { TypeName = typeName};
        _Es.InsertEmployeeType(employeeType);
        return Ok(employeeType);
    }
}


