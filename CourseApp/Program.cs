using CourseApp.Controllers;
using Domain.Models;
using Service.Enums;
using Service.Helpers;
using Service.Helpers.Extensions;
using Service.Services;
using System;
using System.Collections.Generic;


GroupController groupController = new GroupController();

StudentController studentController = new StudentController();
ConsoleExtension.WriteConsole(ConsoleColor.Yellow, "WELCOME COURSE ");

ConsoleExtension.WriteConsole(ConsoleColor.Green, "Select one option: ");

while (true)
{
  GetMenues();
SelectOption: string selectOption = Console.ReadLine();
    int selectTrueOption;
    bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

    if (isSelectOption)
    {
        switch (selectTrueOption)
        {
            case (int)OperationType.CreateGroup:
                groupController.Create();
                break;

            case (int)OperationType.GetGroupById:
                groupController.GetById();
                break;


            case (int)OperationType.UpdateGroup:
                groupController.Update();
                break;


            case (int)OperationType.DeleteGroup:
                groupController.Delete();
                break;

            case (int)OperationType.GetAllGroups:
                groupController.GetAll();
                break;

            case (int)OperationType.GetAllGroupsByTeacher:
                groupController.SearchByTeacherName();
                break;

            case (int)OperationType.GetAllGroupsByRoom:
                groupController.GetAllByRoom();
                break;

            case (int)OperationType.SearchForGroupsByName:
                groupController.SearchByName();
                break;


            // Students 

            case (int)OperationType.CreateStudent:
                studentController.Create();
                break;

            case (int)OperationType.UpdateStudent:
                studentController.Update();
                break;

            case (int)OperationType.GetStudentById:
                studentController.GetById();
                break;

            case (int)OperationType.DeleteStudent:
                studentController.Delete();
                break;


            case (int)OperationType.GetStudentsByAge:
                studentController.GetStudentsByAge();
                break;

            case (int)OperationType.GetAllStudentsByGroupId:
                studentController.GetAllStudentByGrupId();
                break;


            case (int)OperationType.SearchForStudentsByNameOrSurname:
                studentController.Search();
                break;



            default:
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Select correct option number: ");
                break;
        }
    }
    else
    {
        ConsoleExtension.WriteConsole(ConsoleColor.Red, "Select correct option: ");
        goto SelectOption;
    }
    static void GetMenues()
    {
        ConsoleExtension.WriteConsole(ConsoleColor.DarkCyan, "1 - Create group\n2 - Get group by id\n3 - Update group\n4 - Delete group\n5" +
          " - Get all groups\n6 - Search for groups by teacher name\n7 - Get all groups by room\n8" +
          " - Search method for groups by name\n9 - Create student\n10 - Update student\n11 - Get student by Id\n12 - Delete student\n13" +
          " - Get students by age\n14 - Get all students by group id\n15 - Search method for students by name or surname");
    }
}





