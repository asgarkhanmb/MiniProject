using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    public class StudentController
    {
        StudentService studentService = new StudentService();
        GroupService groupService = new GroupService();

        public void Create()
        {
            ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add group id: ");
        GroupId: string groupId = Console.ReadLine();
            int selectedGroupId;

            if (string.IsNullOrWhiteSpace(groupId))
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Id cant be empty: ");
                goto GroupId;
            }

            bool isSelectedId = int.TryParse(groupId, out selectedGroupId);

            var datas = groupService.GetById(selectedGroupId);
            if (datas != null)
            {
                if (isSelectedId)
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add student name: ");

                Crname: string studentName = Console.ReadLine();
                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentName.Contains(i.ToString()))
                        {
                            ConsoleExtension.WriteConsole(ConsoleColor.Red, "Please correct name: ");
                            goto Crname;
                        }
                        else if (string.IsNullOrWhiteSpace(studentName))
                        {
                            ConsoleExtension.WriteConsole(ConsoleColor.Red, "Name cant be empty: ");
                            goto Crname;
                        }

                    }
                    ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add student surname: ");

                Creatsneme: string studentSurName = Console.ReadLine();
                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentSurName.Contains(i.ToString()))
                        {
                            ConsoleExtension.WriteConsole(ConsoleColor.Red, "Please correct  surname: ");
                            goto Creatsneme;
                        }
                        else if (string.IsNullOrWhiteSpace(studentSurName))
                        {
                            ConsoleExtension.WriteConsole(ConsoleColor.Red, "Surname cant be empty: ");
                            goto Creatsneme;
                        }

                    }
                    ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add student age: ");

                Age: string studentAge = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(studentAge))
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Red, "Student age cant be empty: ");
                        goto Age;
                    }

                    int age;
                    bool isAge = int.TryParse(studentAge, out age);

                    if (isAge)
                    {
                        Student student = new Student()
                        {
                            Name = studentName,
                            Surname = studentSurName,
                            Age = age,
                        };
                        var result = studentService.Create(selectedGroupId, student);
                        if (result != null)
                        {
                            ConsoleExtension.WriteConsole(ConsoleColor.Green, $" Student id : {result.Id}, Student name : {result.Name},Student surname : {result.Surname}, Student age : {result.Age}, Student group : {result.Group.Name}");
                        }
                        else
                        {
                            ConsoleExtension.WriteConsole(ConsoleColor.Red, "Add correct student age: ");
                            goto Age;
                        }
                    }
                    else
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Red, "Add correct student age type: ");
                        goto Age;
                    }

                }
                else
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Add correct group id type: ");
                    goto GroupId;
                }

            }
            else
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Add correct group id: ");
                goto GroupId;
            }
        }
        public void Update()
        {
            ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add student id: ");
        StudentId: string updateStudentId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(updateStudentId))
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Id cant be empty: ");
                goto StudentId;
            }
            int studentId;

            bool isStudentId = int.TryParse(updateStudentId, out studentId);

            if (isStudentId)
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add student new name: ");
            NewStudentName: string studentNewName = Console.ReadLine();


                ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add student new surname: ");
            NewStudentSurname: string studentNewsurname = Console.ReadLine();
                for (int i = 0; i <= 9; i++)
                {
                    if (studentNewName.Contains(i.ToString()))
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Red, "Student name is not correct: ");
                        goto NewStudentName;
                    }
                }
                for (int i = 0; i <= 9; i++)
                {
                    if (studentNewsurname.Contains(i.ToString()))
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Red, "Student surname is not correct: ");
                        goto NewStudentSurname;
                    }

                }

                ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add student new age: ");
            StNewAge: string studentNewAge = Console.ReadLine();

                int ageCount;
                bool isAge = int.TryParse(studentNewAge, out ageCount);

                if (isAge || studentNewAge == "")
                {
                    bool isAgeEmpty = string.IsNullOrEmpty(studentNewAge);

                    int? count = null;

                    if (isAgeEmpty)
                    {
                        count = null;
                    }
                    else
                    {
                        count = ageCount;
                    }
                    Student student = new Student()
                    {
                        Name = studentNewName,
                        Surname = studentNewsurname,
                        Age = ageCount,
                    };

                    var resultStudent = studentService.Update(studentId, student);

                    if (resultStudent == null)
                    {

                        ConsoleExtension.WriteConsole(ConsoleColor.Red, "Age have to number:");
                        goto StNewAge;
                    }

                    else
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Cyan, "updated student:");
                        ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Studen id : {resultStudent.Id}, Student name : {resultStudent.Name},  Surname : {resultStudent.Surname},  Student age : {resultStudent.Age}");

                    }

                }

            }
            else
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, " Student not found, please try again:");
                goto StudentId;
            }


        }
        public void GetById()
        {
            ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add student id : ");
        StudentId: string studentId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(studentId))
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Student id cant be empty: ");
                goto StudentId;
            }
            int id;

            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                Student student = studentService.GetById(id);
                if (student != null)
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Student id : {student.Id}, Student name : {student.Name}, Student surname : {student.Surname}, Student age : {student.Age}");
                }

                else
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Student not found : ");
                    goto StudentId;
                }

            }
            else
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Select correct id type: ");
                goto StudentId;
            }


        }
        public void Delete()
        {
            ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add student id : ");
        StudentId: string studentId = Console.ReadLine();

            int id;
            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                studentService.Delete(id);

            }
            else if (string.IsNullOrWhiteSpace(studentId))
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Student id cant be empty: ");
                goto StudentId;
            }

            else
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Select correct id type: ");
                goto StudentId;
            }


        }
        public void GetStudentsByAge()
        {
            ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Search student age : ");
        StudentAge: string stAge = Console.ReadLine();
            int age;
            bool isAge = int.TryParse(stAge, out age);

            List<Student> resultstudent = studentService.GetStudentsByAge(age);
            if (resultstudent.Count != 0)
            {
                foreach (var item in resultstudent)
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Student id : {item.Id}, Student name : {item.Name}, Student surname : {item.Surname},Student group : {item.Group.Name}, Student age : {item.Age} ");
                }
            }
            else if (string.IsNullOrWhiteSpace(stAge))
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Search age cant be empty: ");
                goto StudentAge;
            }
            else
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Not found, please correct age : ");
                goto StudentAge;
            }


        }
        public void Search()
        {

            ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add student search text : ");

        Searchtxt: string search = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(search))
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Search text cant be empty: ");
                goto Searchtxt;
            }

            List<Student> resultStudent = studentService.Search(search);

            if (resultStudent.Count != 0)
            {
                foreach (var item in resultStudent)
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Student id : {item.Id}, Student name : {item.Name}, Student surname : {item.Surname}, Student age : {item.Age}");
                }

            }

            else
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Student name or surname not found: ");

            }
        }
        public void GetAllStudentByGrupId()
        {
            ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add group id :");
        GrupId: string groupId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(groupId))
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Id cant be empty: ");
                goto GrupId;
            }
            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                List<Student> students = studentService.GetAllStudentByGrupId(id);

                if (students.Count != 0)
                {
                    foreach (var item in students)
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Studen id : {item.Id}, Student name : {item.Name},  Surname : {item.Surname},  Student age : {item.Age}");
                    }
                }
                else
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Group not found :");
                    goto GrupId;
                }
            }
            else
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Add correct group id :");
                goto GrupId;
            }
        }


    }
}
