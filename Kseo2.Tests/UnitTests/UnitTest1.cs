using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kseo2.Model;
using Moq;
using System.Data.Entity;
using Kseo2.Service;
using Kseo2.DataAccess;


namespace Kseo2.Tests.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var mockSet = new Mock<DbSet<Person>>();
            var mocKseoContext = new Mock<KseoContext>();
            mocKseoContext.Setup(m => m.Persons).Returns(mockSet.Object);

            var ps = new PersonService(mocKseoContext.Object);
            ps.AddPerson(new Person() {Pesel = "73020916558",LastName="KORPUSIK",FirstName="JACEK",HasPESEL=true });

            mockSet.Verify(m => m.Add(It.IsAny<Person>()), Times.Once());
            mocKseoContext.Verify(m => m.SaveChanges(), Times.Once());
            
            






        }
    }
}
