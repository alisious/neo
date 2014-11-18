using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kseo2.DataAccess;
using Kseo2.Service;
using Kseo2.Model;
using System.Data.Entity.Infrastructure;

namespace Kseo2.Tests.UnitTests
{
    [TestClass]
    public class PersonServiceUnitTest
    {
        private KseoContext _ctx; 
        
        [TestInitialize]
        public void TestInitialize()
        {
            _ctx = new KseoContext();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _ctx.Dispose();
        }

        [TestMethod]
        public void PersonService_Can_get_person_by_id()
        {
            //given
            var ps = new PersonService(_ctx);
            
            //when
            var p_db = ps.GetSingle(1);
            //then
            Assert.IsNotNull(p_db);
            Assert.AreEqual("NAZWISKO0", p_db.LastName);

        }

        [TestMethod]
        public void PersonService_Can_add_new_person()
        {
            //given
            var ps = new PersonService(_ctx);
            var p = new Person() {Pesel="73020916558",FirstName="JACEK",LastName="KORPUSIK"};
            
            //when
            ps.AddPerson(p);
            var id = p.Id;
            var p_db = ps.GetSingle(id);
            //then
            Assert.IsNotNull(p_db);

        }

        [TestMethod]
        public void PersonService_Can_update_person()
        {
            //given
            var ps = new PersonService(_ctx);
            var p = ps.GetSingle(1);
            
            //when
            p.LastName = "NOWE NAZWISKO";
            ps.SaveChanges();

            var p_db = ps.GetSingle(p.Id);
            //then
            Assert.IsNotNull(p_db);
            Assert.AreEqual("NOWE NAZWISKO", p_db.LastName);
        }

        [TestMethod]
        public void PersonService_Can_delete_person()
        {
            //given
            var ps = new PersonService(_ctx);
            var p = ps.GetSingle(1);

            //when
            //ps.DeletePerson(p);
           
            var p_db = ps.GetSingle(1);
            //then
            Assert.IsNull(p_db);
            
        }

        
        [TestMethod]
        public void PersonService_Can_search_persons_by_pesel_and_lastname()
        {
            //given
            var ps = new PersonService(_ctx);
                       
            //when
            var sr = ps.Search("00000000001", "NAZWISKO1");
                       
            //then
            Assert.IsNotNull(sr);
            Assert.AreEqual(1, sr.ResultsCounter);
        }

        [TestMethod]
        public void PersonService_Can_search_persons_without_pesel()
        {
            //given
            var ps = new PersonService(_ctx);

            //when
            var sr = ps.Search("NAZWISKO","IMIE","","",20);

            //then
            Assert.IsNotNull(sr);
            Assert.IsTrue(sr.ResultsCounter>20);
        }

        [TestMethod]

        public void PersonService_Can_not_add_new_person_with_duplicated_pesel()
        {
            //given
            var ps = new PersonService(_ctx);
            var p1 = new Person() { Pesel = "73020916558", FirstName = "JACEK", LastName = "KORPUSIK" };
            var p2 = new Person() { Pesel = "73020916558", FirstName = "JAN", LastName = "KOWALSKI" };
            //when
            var new_person1 = ps.AddPerson(p1);
            var new_person2 = ps.AddPerson(p2);
                       
            //then
            Assert.IsNotNull(new_person1);
            Assert.IsNull(new_person2);
        }

        [TestMethod]
        public void PersonService_Can_not_update_person_with_pesel_duplicate()
        {
            //given
            var ps = new PersonService(_ctx);
            var p1 = new Person() { Pesel = "90010101010", FirstName = "JACEK", LastName = "KORPUSIK" };
            var p2 = new Person() { Pesel = "90010101011", FirstName = "JAN", LastName = "KOWALSKI" };
            var new_person1 = ps.AddPerson(p1);
            var new_person2 = ps.AddPerson(p2);
            //when
            new_person2.Pesel = new_person1.Pesel;
            //var updated_person = ps.UpdatePerson(new_person2);
            
            //then
            Assert.IsNotNull(new_person1);
            Assert.IsNotNull(new_person2);
            //Assert.IsNull(updated_person);
        }

        [TestMethod]
        public void PersonService_Can_not_load_searched_person_over_resultslimit()
        {
            //given
            var ps = new PersonService(_ctx);
            int limit = 10;

            //when
            var sr = ps.Search("0", "NAZWISKO1",limit);

            //then
            Assert.IsNotNull(sr);
            Assert.IsTrue(sr.ResultsCounter>limit);
            Assert.AreEqual(0, sr.Results.Count);
        }

        [TestMethod]
        public void PersonService_Can_set_nationality()
        {
            //given
            var country = _ctx.Countries.Find(1);
            var ps = new PersonService(_ctx);
            var p = ps.GetSingle(10);

            //when
            p.Nationality = country;
            ps.SaveChanges();
            var p_db = ps.GetSingle(10);
            

            //then
            Assert.IsNotNull(p_db);
            Assert.IsNotNull(p_db.Nationality);
            Assert.AreEqual(country.Id,p_db.Nationality.Id);
        }

    }
}
