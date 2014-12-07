using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kseo2.DataAccess;
using Kseo2.Service;
using Kseo2.Model;
using System.Data.Entity.Infrastructure;

namespace Kseo2.Tests.PersonServiceUnitTest
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
        public void PersonService_Can_check_pesel_duplicate()
        {
            //given
            var ps = new PersonService(_ctx);
            var p1 = ps.GetSingle(1);
            var p2 = new Person() { Pesel = p1.Pesel, LastName = "KWIATKOWSKI", FirstName = "JAN", Sex = "M" };
            //when
            var r = ps.HasPeselDuplicate(p2);

            //then
            Assert.IsTrue(r);
            

        }

        [TestMethod]
        public void PersonService_Can_get_person_by_id()
        {
            //given
            var ps = new PersonService(_ctx);
            
            //when
            var pDb = ps.GetSingle(1);

            //then
            Assert.IsNotNull(pDb);
            Assert.AreEqual("NAZWISKO0", pDb.LastName);

        }

        [TestMethod]
        public void PersonService_Can_add_new_person()
        {
            
            //given
            var ps = new PersonService(_ctx);
            var p = new Person() {Pesel="73020916558",FirstName="JACEK",LastName="KORPUSIK",Sex = "M"};

            //when
            ps.AddPerson(p);
            ps.SaveChanges();
            var id = p.Id;
            var pDb = ps.GetSingle(id);

            //then
            Assert.IsNotNull(pDb);

        }


        [TestMethod]
        public void mozna_dodac_nowa_osobe_z_narodowaoscia()
        {

            //given
            var cs = new DictionaryService<Country>(_ctx);
            var c = cs.GetSingle(1);

            var ps = new PersonService(_ctx);
            var p = new Person() { Pesel = "99999999999", FirstName = "JACEK", LastName = "KORPUSIK", Sex = "M" };
            p.Nationality = c;

            //when
            ps.AddPerson(p);
            ps.SaveChanges();
            var id = p.Id;
            var pDb = ps.GetSingle(id);

            //then
            Assert.IsNotNull(c);
            Assert.IsNotNull(pDb);
            Assert.IsNotNull(pDb.Nationality);

        }

        [TestMethod]
        public void mozna_dodac_nowa_osobe_z_wielokrotnym_obywatelstwem()
        {

            //given
            var cs = new DictionaryService<Country>(_ctx);
            var c1 = cs.GetSingle(1);
            var c2 = cs.GetSingle(2);

            var ps = new PersonService(_ctx);
            var p = new Person() { Pesel = "88888888888", FirstName = "JACEK", LastName = "KORPUSIK", Sex = "M" };
            p.Citizenships.Add(c1);
            p.Citizenships.Add(c2);

            //when
            ps.AddPerson(p);
            ps.SaveChanges();
            var id = p.Id;
            var pDb = ps.GetSingle(id);

            //then
            Assert.IsNotNull(c1);
            Assert.IsNotNull(c2);
            Assert.IsNotNull(pDb);
            Assert.AreEqual(2, pDb.Citizenships.Count);

        }

        [TestMethod]
        public void PersonService_Can_add_new_person_HasNoPesel()
        {

            //given
            var ps = new PersonService(_ctx);
            var p = new Person() { HasPESEL = false, FirstName = "JACEK", LastName = "KORPUSIK", Sex = "M" };

            //when
            ps.AddPerson(p);
            ps.SaveChanges();
            var id = p.Id;
            var pDb = ps.GetSingle(id);

            //then
            Assert.IsNotNull(pDb);

        }

        [TestMethod]
        public void PersonService_Can_update_person()
        {
            //given
            var ps = new PersonService(_ctx);
            var p = ps.GetSingle(10);
            
            //when
            p.LastName = "NOWE NAZWISKO";
            ps.SaveChanges();

            var pDb = ps.GetSingle(p.Id);
            //then
            Assert.IsNotNull(pDb);
            Assert.AreEqual("NOWE NAZWISKO", pDb.LastName);
        }

        [TestMethod]
        public void PersonService_Can_remove_person()
        {
            //given
            var ps = new PersonService(_ctx);
            var p = ps.GetSingle(1);

            //when
            ps.RemovePerson(p);
            ps.SaveChanges();
           
            var pDb = ps.GetSingle(1);
            //then
            Assert.IsNull(pDb);
            
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
            var sr = ps.Search("NAZW","IM","","",20);

            //then
            Assert.IsNotNull(sr);
            Assert.IsTrue(sr.ResultsCounter>0);
        }

        [TestMethod]
        
        public void PersonService_Can_not_add_new_person_with_duplicated_pesel()
        {
            //given
            var ps = new PersonService(_ctx);
            var p1 = new Person() { Pesel = "73020916558", FirstName = "JACEK", LastName = "KORPUSIK", Sex = "M" };
            var p2 = new Person() { Pesel = "73020916558", FirstName = "JAN", LastName = "KOWALSKI", Sex = "M" };
            //when
            ps.AddPerson(p1);
            Exception exc = null;
            try
            {
                ps.AddPerson(p2);
                ps.SaveChanges();
            }
            catch (Exception e)
            {
                exc = e;
            }

            //then
            Assert.IsNotNull(exc);
            Assert.AreEqual(typeof(DbUpdateException),exc.GetType());

        }

        [TestMethod]
        public void PersonService_Can_not_update_person_with_pesel_duplicate()
        {
            //given
            var ps = new PersonService(_ctx);
            var p1 = new Person() { Pesel = "90010101010", FirstName = "JACEK", LastName = "KORPUSIK", Sex = "M" };
            var p2 = new Person() { Pesel = "90010101011", FirstName = "JAN", LastName = "KOWALSKI", Sex = "M" };
            ps.AddPerson(p1);
            ps.AddPerson(p2);
            ps.SaveChanges();
            //when
            p2.Pesel = p1.Pesel;
            Exception exc = null;
            try
            {
               ps.SaveChanges();
            }
            catch (Exception e)
            {
                exc = e;
            }

            //then
            Assert.IsNotNull(exc);
            Assert.AreEqual(typeof(DbUpdateException), exc.GetType());
   
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
