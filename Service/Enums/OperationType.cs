using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Enums
{
    public enum OperationType
    {
        CreateGroup = 1,
        DeleteGroup,
        GetGroupById,
        GetAllGroups,
        SearchByTeacherName,
        GetAllGroupsByRoom,
        SearchForGroupsByName,
        UpdateGroup,
        CreateStudent,
        DeleteStudent,
        GetStudentsByAge,
        GetStudentById,
        GetAllStudentsByGroupId,
        SearchForStudentsByNameOrSurname,
        UpdateStudent,

    }
}
