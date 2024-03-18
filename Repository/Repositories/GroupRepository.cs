using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>,IGroupRepository
    {
        public void Create(Group data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found");
                AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Group data)
        {
            AppDbContext<Group>.datas.Remove(data);
        }

        public Group Get(Predicate<Group> predicate)
        {
            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;
        }

        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public List<Group> GetAllByRomm(string roomName)
        {
            return AppDbContext<Group>.datas.Where(m=>m.Room==roomName).ToList();
        }

        public List<Group> GetAllByTeacher(string name)
        {
            return AppDbContext<Group>.datas.Where(m=>m.Teacher==name).ToList();
        }

        public void Update(Group data)
        {
            Group group = Get(m => m.Id == data.Id);
            if (!string.IsNullOrEmpty(data.Name))
                group.Name = data.Name;

            if (!string.IsNullOrEmpty(data.Teacher))
                group.Teacher = data.Teacher;

            if (!string.IsNullOrEmpty(data.Room))
                group.Room = data.Room;


        }
    }
}
