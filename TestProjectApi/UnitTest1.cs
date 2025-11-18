using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Usuarios.Api.Endpoints.Handlers;
using Usuarios.Api.Models;
using Usuarios.Api.Services;

namespace TestProjectApi
{
    public class UnitTestStudent
    {

        [Fact]
        public async Task GET_Students_ReturnsOkWithData()
        {
            //Arrange
            var fakeData = new List<Student>{
                     new Student { FirstName="Jona" , MiddleName = "Hernandez", LastName = "Galindo", StudentId = 1 },
                     new Student { FirstName="Jona 2" , MiddleName = "Hernandez 2", LastName = "Galindo 2", StudentId = 2 },
            };

            var serviceMock = new Mock<IStudentService>();
            serviceMock.Setup(s => s.GetAllStudentsAsync())
                                .ReturnsAsync(fakeData);

            //Ejecución directa del handler
            var result = await StudentHandlers.GetAll(serviceMock.Object);

            //Assert
            var ok = Assert.IsType<Ok<List<Student>>>(result);
            Assert.Equal(fakeData, ok.Value);
        }

        [Fact]
        public async Task POST_Student_Add_ReturnOk()
        {
            //Arrange
            var studentFake = new Student
            {
                Emails = new List<Email> { new Email { EmailAddress = "jona@example.com" } },
                Phones = new List<Phone> { new Phone { PhoneNumber = "1234567890" } },
                Addresses = new List<Address> { new Address { AddressLine = "Calle Falsa 123" } }
            };
            var serviceMock = new Mock<IStudentService>(); //Mock
            serviceMock.Setup(s => s.AddNewStudentAsync(It.IsAny<Student>())).ReturnsAsync(1); //Moc

            //Ejecución directa del handler
            var result = await StudentHandlers.Create(serviceMock.Object, studentFake);

            //Assert
            var createdResult = Assert.IsType<Created<Student>>(result); // 201 Created
            Assert.Equal("/students/1", createdResult.Location);
            Assert.Equal(studentFake,createdResult.Value);

            // Verificar que el método del servicio fue llamado exactamente 1 vez
            serviceMock.Verify(s => s.AddNewStudentAsync(It.IsAny<Student>()), Times.Once);
        }
    }
}