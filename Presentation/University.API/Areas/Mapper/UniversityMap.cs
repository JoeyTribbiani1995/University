using System;
using AutoMapper;
using University.API.Models;
using University.Core.Domain;

namespace University.API.Areas.Mapper
{
    public class UniversityMap : Profile
    {
        public UniversityMap()
        {
            CreateStudentMaps();
        }


        protected void CreateStudentMaps()
        {
            CreateMap<Student, StudentModel>();
            CreateMap<StudentModel, Student>();

        }
    }

    
}
