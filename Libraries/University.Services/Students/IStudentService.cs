using System;
using System.Threading.Tasks;
using University.Core.Domain;

namespace University.Services.Students
{
    public interface IStudentService
    {
        Task<Student> GetStudentById(int id);
    }
}
