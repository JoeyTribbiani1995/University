using System;
using System.Threading.Tasks;
using University.Core.Data;
using University.Core.Domain;
using University.Data;

namespace University.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetStudentById(int id)
        {
            if(id == 0)
            {
                return null;
            }
            var result = await _studentRepository.GetById(id);

            return result;
        }

        public void InsertStudent(Student student)
        {
            try
            {
                if(student != null)
                {
                    _studentRepository.Insert(student);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
