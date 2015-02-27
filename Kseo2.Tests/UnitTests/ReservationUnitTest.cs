using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Kseo2.DataAccess;
using Kseo2.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kseo2.Tests.UnitTests
{
    [TestClass]
    public class ReservationUnitTest
    {
        [TestMethod]
        public void mozna_dodac_nowe_zabezpieczenie()
        {
            var mockSetReservations = new Mock<DbSet<Reservation>>();
            var mockSetPersons = new Mock<DbSet<Person>>();
            var mockContext = new Mock<KseoContext>();
            mockContext.Setup(m => m.Reservations).Returns(mockSetReservations.Object);
            mockContext.Setup(m => m.Persons).Returns(mockSetPersons.Object);

            var newReservation = new Reservation(new Person());
            mockContext.Object.Reservations.Add(newReservation);
            mockContext.Object.SaveChanges();

            mockSetReservations.Verify(m=>m.Add(It.IsAny<Reservation>()),Times.Once());
            mockSetPersons.Verify(m=>m.Add(It.IsAny<Person>()),Times.Once);
            mockContext.Verify(m => m.SaveChanges(),Times.Once());
 
           
        }

        [TestMethod]
        public void mozna_dodac_nowe_zabezpieczenie_przez_KseoKontext()
        {
            var ctx = new KseoContext();
            var person = new Person()
            {
                
                Pesel = "73020916558",
                FirstName = "JACEK",
                LastName = "KORPUSIK",
                FatherName = "JAN",
                Sex = "M"
            };
            var ou = ctx.OrganizationalUnits.FirstOrDefault(x => x.Id.Equals(1));
            var ps = ctx.ReservationPurposes.FirstOrDefault(x => x.Id.Equals(1));
            var reservation = new Reservation(person) {StartDate = "2015-02-02", ConductingUnit = ou, Purpose = ps};
            
            //person.Reservations.Add(reservation);
            ctx.Reservations.Add(reservation);
            //ctx.Persons.Add(person);
            
            ctx.SaveChanges();

            Assert.AreEqual(1,ctx.Reservations.Count());

        }
    }
}
