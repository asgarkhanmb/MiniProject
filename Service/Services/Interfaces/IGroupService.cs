using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        Group Update(int id,Group group);
        void Delete(int id);
        Group GetById(int id);
        List<Group> GetAll();
        List<Group> GetAllByTeacherName(string name);
        List<Group> GetAllByRoom(string roomName);
        List<Group> GetAllByRoomNames(string search);
    }
}
