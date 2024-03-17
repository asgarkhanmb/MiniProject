﻿using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using SendGrid.Helpers.Errors.Model;
using Service.Helpers.Costants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StudentRepository : IBaseRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException(ResponseMesagges.DataNotFound);
                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student data)
        {
            AppDbContext<Student>.datas.Remove(data);
        }

        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;

        }

        public List<Student> GetAll(Predicate<Student> predicate = null)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

        public void Update(Student data)
        {
            Student student = Get(m => m.Id == data.Id);
            if (!string.IsNullOrEmpty(data.Name))
                student.Name = data.Name;

            if (!string.IsNullOrEmpty(data.Surname))
                student.Surname = data.Surname;

            if (data.Age != null)
                student.Age = data.Age;




        }
    }
}