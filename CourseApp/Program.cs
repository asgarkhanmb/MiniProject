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

            case (int)OperationType.DeleteGroup:
                groupController.Delete();
                break;


            case (int)OperationType.GetGroupById:
                groupController.GetById();
                break;


            case (int)OperationType.GetAllGroups:
                groupController.GetAll();
                break;

            case (int)OperationType.SearchByTeacherName:
                groupController.SearchByTeacherName();
                break;

            case (int)OperationType.GetAllGroupsByRoom:
                groupController.GetAllByRoom();
                break;

            case (int)OperationType.SearchForGroupsByName:
                groupController.SearchByName();
                break;

            case (int)OperationType.UpdateGroup:
                groupController.Update();
                break;


            // Students 

            case (int)OperationType.CreateStudent:
                studentController.Create();
                break;

            case (int)OperationType.DeleteStudent:
                studentController.Delete();
                break;

            case (int)OperationType.GetStudentsByAge:
                studentController.GetStudentsByAge();
                break;

            case (int)OperationType.GetStudentById:
                studentController.GetById();
                break;


            case (int)OperationType.GetAllStudentsByGroupId:
                studentController.GetAllStudentByGrupId();
                break;

            case (int)OperationType.SearchForStudentsByNameOrSurname:
                studentController.Search();
                break;


            case (int)OperationType.UpdateStudent:
                studentController.Update();
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
        ConsoleExtension.WriteConsole(ConsoleColor.DarkCyan, "1 - Create Group\n2 - Delete Group\n3 - Get Group By Id\n4 - Get All Groups\n5" +
          " - Search By Teacher Name\n6 - Get All Groups By Room\n7 - Search For Groups By Name\n8" +
          " - Update Group\n9 - Create Student\n10 - Delete Student\n11 - Get Student By Age \n12 - Get Student By Id\n13" +
          " - Get All Students By Group Id\n14 - Search Method For Students By Name Or Surname\"\n15 - Update Student");
    }
}





