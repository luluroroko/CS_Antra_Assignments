using System;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class StudentService : IStudentService
{
    StudentRepository _studentRepository;

    public StudentService()
    {
        _studentRepository = new StudentRepository();
    }

    public void AddStudent()
    {
        Students s = new Students();
        Console.Write("Enter first name of the student: ");
        s.FirstName = Console.ReadLine();
        Console.Write("Enter last name of the student: ");
        s.LastName = Console.ReadLine();
        Console.Write("Enter salary of the student: ");
        s.Grade = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter department id of an employee: ");
        s.courses = Convert.ToInt32(Console.ReadLine());

        if (_studentRepository.Insert(s) > 0) //Reflects the number of records impacted
        {
            Console.WriteLine("Successfully Inserted");
        }
        else
        {
            Console.WriteLine("Error");
        }

    }

    public void DeleteStudent()
    {
        Console.Write("Enter Student Id number to Delete: ");
        int id = Convert.ToInt32(Console.ReadLine());
        _studentRepository.DeletebyId(id);

    }

    public void GetAllStudent()
    {
        IEnumerable<Students> students = _studentRepository.GetAll();
        foreach (var stu in students)
        {
            Console.WriteLine($"{stu.Id} \t {stu.FirstName} \t {stu.LastName} \t {stu.Grade} \t {stu.courses} ");
        }

    }
}

