using System;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        CourseRepository _courseRepository;

        public CourseService()
        {
            _courseRepository = new CourseRepository();
        }

        public void AddCourse()
        {
            Courses c = new Courses();
            Console.Write("Enter name of course: ");
            c.courses = Console.ReadLine();
       
            if (_courseRepository.Insert(c) > 0) //Reflects the number of records impacted
            {
                Console.WriteLine("Successfully Inserted");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void DeleteCourse()
        {
            Console.Write("Enter Id number to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            _courseRepository.DeletebyId(id);
        }

        public void GetAllCourse()
        {
            IEnumerable<Courses> courses = _courseRepository.GetAll();
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.classId} \t {course.courses}");
            }
        }
    }
}
