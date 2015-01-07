using System;
using System.Data.Entity;
using Kseo2.BusinessLayer;
using Kseo2.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Kseo2.Model;

namespace Kseo2.Tests.BusinessLayerTests
{
    [TestClass]
    public class PersonServiceTests
    {
        [TestMethod]
        public void mozna_zapisac_nowa_osobe()
        {
            var mockSet = new Mock<DbSet<Person>>();
            var mockContext = new Mock<KseoContext>();
            mockContext.Setup(m => m.Persons).Returns(mockSet.Object);

            var service = new PersonService(mockContext.Object);
            var person = new Person()
            {
                FirstName = "JACEK",
                LastName = "KORPUSIK",
                Pesel = "73020916558",
                Sex = "M"
            };
            service.Add(person);

            mockSet.Verify(m => m.Add(It.IsAny<Person>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once()); 

        }
    }
}
