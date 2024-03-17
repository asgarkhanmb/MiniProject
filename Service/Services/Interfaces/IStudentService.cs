using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(int groupId, Student student);

        Student Update(int id, Student student);

        Student GetById(int id);

        List<Student> GetAll();
        void Delete(int id);
        List<Student> GetStudentsByAge(int age);

        List<Student> Search(string search);

        List<Student> GetAllStudentByGrupId(int id);
    }
}
