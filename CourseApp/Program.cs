using CourseApp.Controllers;
using Domain.Models;
using Service.Enums;
using Service.Helpers;
using Service.Helpers.Extensions;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text.RegularExpressions;


GroupController groupController = new GroupController();

StudentController studentController = new StudentController();
ConsoleExtension.WriteConsole(ConsoleColor.Yellow, "                                                💻 𝙒𝙀𝙇𝘾𝙊𝙈𝙀 𝘾𝙊𝙐𝙍𝙎𝙀 💻");
ConsoleExtension.WriteConsole(ConsoleColor.DarkMagenta, "                                               ~~~~~~~~~~~~~~~~~~~~~~");
ConsoleExtension.WriteConsole(ConsoleColor.Green, "                                           ≫ Select One Of The Operators≪");
ConsoleExtension.WriteConsole(ConsoleColor.DarkMagenta, "                                          ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");



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
        ConsoleExtension.WriteConsole(ConsoleColor.Green, "                                                      ☑ Group");
        ConsoleExtension.WriteConsole(ConsoleColor.DarkMagenta, "                                                      ~~~~~~~~~");
        ConsoleExtension.WriteConsole(ConsoleColor.DarkCyan, "                                        1 - Create Group |~| 2 - Delete Group\n                                     3 - Get Group By Id |~| 4 - Get All Groups\n" +

          "                                5-Search By Teacher Name |~| 6 - Get All Groups By Room\n                           7 - Search For Groups By Name |~| 8 - Update Group\n");
        ConsoleExtension.WriteConsole(ConsoleColor.Green, "                                                      ☑ Student");
        ConsoleExtension.WriteConsole(ConsoleColor.DarkMagenta, "                                                      ~~~~~~~~~~~");
        ConsoleExtension.WriteConsole(ConsoleColor.DarkCyan, "                                       9 - Create Student |~| 10 - Delete Student\n" +
            "                                  11 - Get Student By Age |~| 12 - Get Student By Id\n" +
        "                         13- Get All Students By Group Id |~| 14 - Search Method For Students By Name Or Surname\n" +
        "                                                  15 - Update Student");
    }
}





