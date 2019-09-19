using System;
using University.Core.Data;
using University.Core.Domain;
using University.Services.Students;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace University.Services.Tests.Students
{
    [TestFixture]
    public class StudentServiceTests
    {
        private IStudentService _studentService;
        private Mock<IRepository<Student>> _studentRepository;

        [SetUp]
        public new void SetUp()
        {
            _studentRepository = new Mock<IRepository<Student>>();
            Student student = new Student
            {Id = 1,
                Name = "Joey",
                Address = "LA"
            };
            //create fake data 
            _studentRepository.Setup(x => x.Table).Returns(new List<Student> { student }.AsQueryable());

            _studentService = new StudentService(_studentRepository.Object);
        }

        [Test]
        public void GetStudentById_NotNull()
        {
            //Arrange
            Student student = new Student
            {
                Id = 1,
                Name = "Joey",
                Address = "LA"
            };

            //Act
            var result = _studentService.GetStudentById(1);

            //Assert
            Assert.Equals(result, student);
        }

        [Test]
        public void InsertStudent_Success()
        {
            //Arrange
            Student student = new Student
            {
                Name = "Joey",
                Address = "LA"
            };

            //Act
            _studentService.InsertStudent(student);
            var result = _studentService.GetStudentById(1);

            //Assert
            Assert.NotNull(result);
        }


        //[Test]
        //public void Get()
        //{
        //    // Arrange
        //    var mock = new Mock<IGetDataRepository>();
        //    mock.Setup(p => p.GetNameById(1)).Returns("Jignesh");
        //    ValuesController valuesController = new ValuesController(mock.Object);

        //    //Act
        //    string result = valuesController.GetById(1);

        //    //Assert
        //    Assert.AreEqual("Jignesh", result);


        //}
    }
}
