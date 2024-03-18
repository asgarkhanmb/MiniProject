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
    public class GroupController
    {
        private readonly GroupService groupService = new();

        public void Create()
        {
            ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add group name:");
        GroupName: string groupName = Console.ReadLine();
            try
            {
                if (string.IsNullOrWhiteSpace(groupName))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Group name can't be eempty:");
                    goto GroupName;
                }
                ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add teacher name:");
            GroupTeacherName: string groupTeacherName = Console.ReadLine();
                if (!groupTeacherName.Any(char.IsLetter))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Please correct teacher name:");
                    goto GroupTeacherName;
                }
                else if (string.IsNullOrWhiteSpace(groupTeacherName))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Teacher name can't be empty");
                    goto GroupTeacherName;
                }
                ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add room name:");
            RoomName: string roomName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(roomName))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Room name can't be empty:");
                    goto RoomName;
                }

                Group group = new Group
                {
                    Name = groupName,
                    Teacher = groupTeacherName,
                    Room = roomName
                };

                var result = groupService.Create(group);
                ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Group id : {result.Id}, Group name : {result.Name}, Teacher name : {result.Teacher}, Room name : {result.Room}");

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }
        public void GetById()
        {
            try
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add group id : ");
            GroupId: string groupId = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(groupId))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Id cant be empty: ");
                    goto GroupId;
                }
                int id;

                bool isGroupId = int.TryParse(groupId, out id);

                if (isGroupId)
                {
                    Group group1 = groupService.GetById(id);
                    if (group1 != null)
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Group id : {group1.Id}, Group name : {group1.Name}, Teacher name : {group1.Teacher}, Room name : {group1.Room}");
                    }
                }
                else
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Select correct id type: ");
                    goto GroupId;
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);

            }


        }
        public void GetAll()
        {
            List<Group> groups = groupService.GetAll();


            if (groups.Count > 0)
            {
                foreach (var item in groups)
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                }
            }
            else
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Red, "Group not found:");

            }
        }
        public void SearchByTeacherName()
        {
            try
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Search group by teacher's name: ");
            TeacName: string searchTeacherName = Console.ReadLine();

                List<Group> resultTeachers = groupService.GetAllByTeacherName(searchTeacherName);
                if (resultTeachers.Count != 0)
                {
                    foreach (var item in resultTeachers)
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                    }
                }
                else if (string.IsNullOrWhiteSpace(searchTeacherName))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Search teacher name cant be empty: ");
                    goto TeacName;
                }
                else
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Teacher name not found : ");

                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }
        public void GetAllByRoom()
        {
            try
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Search group by room's name : ");
            RoomName: string searcRoomName = Console.ReadLine();

                List<Group> resultRooms = groupService.GetAllByRoom(searcRoomName);
                if (resultRooms.Count != 0)
                {

                    foreach (var item in resultRooms)
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                    }
                }
                else if (string.IsNullOrWhiteSpace(searcRoomName))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Search room name cant be empty: ");
                    goto RoomName;
                }
                else 
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Room name not found : ");
                }    
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }
        public void SearchByName()
        {
            try
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Blue, " Search group by name : ");
            SearchByName: string groupsByName = Console.ReadLine();

                List<Group> resultsearch = groupService.SearchGroupByNames(groupsByName);
                if (resultsearch.Count != 0)
                {

                    foreach (var item in resultsearch)
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                    }
                }
                else if (string.IsNullOrWhiteSpace(groupsByName))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Search group name cant be empty: ");
                    goto SearchByName;
                }
                else
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Group name not found : ");
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }



        }
        public void Delete()
        {
            try
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add group id : ");
            GroupId: string groupId = Console.ReadLine();

                int id;
                bool isGroupId = int.TryParse(groupId, out id);

                if (isGroupId)
                {
                    groupService.Delete(id);

                }
                else if (string.IsNullOrWhiteSpace(groupId))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Group id cant be empty: ");
                    goto GroupId;
                }
                else
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Select correct id type: ");
                   
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }
        public void Update()
        {
            try
            {
                ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add group id: ");
            GroupId: string updateGroupId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(updateGroupId))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Group id cant be empty: ");
                    goto GroupId;
                }

                int groupId;

                bool isGroupId = int.TryParse(updateGroupId, out groupId);

                if (isGroupId)
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add group  new name: ");
                    string groupNewName = Console.ReadLine();


                    ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add group new teacher name: ");
                NewTeacName: string groupNewTeacherName = Console.ReadLine();
                    if (!groupNewTeacherName.Any(char.IsLetter))
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Red, "Teacher name is not correct: ");
                        goto NewTeacName;
                    }
                    ConsoleExtension.WriteConsole(ConsoleColor.Blue, "Add group new room name: ");
                RmName: string groupNewRoomName = Console.ReadLine();

                    Group group = new Group()
                    {
                        Name = groupNewName,
                        Teacher = groupNewTeacherName,
                        Room = groupNewRoomName
                    };

                    var resultGroup = groupService.Update(groupId, group);

                    if (resultGroup == null)
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Red, "Group not found, please try again:");
                        goto RmName;
                    }

                    else
                    {
                        ConsoleExtension.WriteConsole(ConsoleColor.Green, $"Group id : {resultGroup.Id}, Group name : {resultGroup.Name}, Teacher name : {resultGroup.Teacher}, Room name : {resultGroup.Room}");
                    }
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }

    }
}

