using System;
using System.Linq;
using Kseo2.DataAccess;
using Kseo2.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kseo2.Tests.UnitTests
{
    [TestClass]
    public class RepositoryUnitTest
    {
        [TestInitialize]
        public void InitializeTest()
        {
            var context = new KseoContext();
            context.Database.Initialize(true);
        }


        [TestMethod]
        public void mozna_usunac_osobe()
        {
            //given
            InitializeTest();
            var personRepo = new PersonRepository();
            var dictRepo = new DictionaryItemRepository<Country>();
            var c1 = dictRepo.GetSingle(c => c.Name.Equals("POLSKA"));
            var c2 = dictRepo.GetSingle(c => c.Name.Equals("HOLANDIA"));
            var p1 = new Person()
            {
                Pesel = "73020916001",
                FirstName = "JACEK",
                LastName = "KORPUSIK",
                Sex = "M",
                Nationality = c1,
                BirthDate = "1973"
            };
            p1.Citizenships.Add(c1);
            p1.Citizenships.Add(c2);
            personRepo.UpdateGraph(p1);
            
            //when
            var p2 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"), p => p.Nationality, p => p.Citizenships);
            p2.EntityState = EntityState.Deleted;
            personRepo.Remove(p2);

            var p3 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"), p => p.Nationality, p => p.Citizenships);
            c1 = dictRepo.GetSingle(c => c.Name.Equals("POLSKA"));
            c2 = dictRepo.GetSingle(c => c.Name.Equals("HOLANDIA"));
            //then
            Assert.IsNotNull(c1);
            Assert.IsNotNull(c2);
            Assert.IsNull(p3);
            
        }


        [TestMethod]
        public void mozna_zmienic_dane_osoby()
        {
            //given
            InitializeTest();
            var personRepo = new PersonRepository();
            var p1 = new Person()
            {
                Pesel = "73020916001",
                FirstName = "JACEK",
                LastName = "KORPUSIK",
                Sex = "M",
                BirthDate = "1973"
            };
            personRepo.UpdateGraph(p1);
            var p2 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"), p => p.Nationality, p => p.Citizenships);

            //when
            p2.LastName = "NOWAK";
            personRepo.UpdateGraph(p2);

            var p3 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"), p => p.Nationality, p => p.Citizenships);
            //then
            Assert.IsNotNull(p3);
            Assert.AreEqual("NOWAK",p3.LastName);
        }


        [TestMethod]
        public void mozna_dodac_narodowosc()
        {
            //given
            InitializeTest();
            var personRepo = new PersonRepository();
            var countryRepo = new DictionaryItemRepository<Country>();
            var c1 = countryRepo.GetSingle(c => c.Name.Equals("POLSKA"));
            var p1 = new Person()
            {
                Pesel="73020916001",
                FirstName = "JACEK", 
                LastName = "KORPUSIK",
                Sex = "M",
                BirthDate = "1973",
                Nationality = c1
            };
                            
            //when
            personRepo.UpdateGraph(p1);
            var p2 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"),p=>p.Nationality,p=>p.Citizenships);

            //then
            Assert.IsNotNull(c1);
            Assert.IsNotNull(p2);
            Assert.IsNotNull(p2.Nationality);
            Assert.AreEqual(p2.Nationality.Name,c1.Name);
        }

        [TestMethod]
        public void mozna_zmienic_narodowosc()
        {
            //given
            InitializeTest();
            var personRepo = new PersonRepository();
            var countryRepo = new DictionaryItemRepository<Country>();
            var c1 = countryRepo.GetSingle(c => c.Name.Equals("POLSKA"));
            var c2 = countryRepo.GetSingle(c => c.Name.Equals("HOLANDIA"));
            var p1 = new Person()
            {
                Pesel = "73020916001",
                FirstName = "JACEK",
                LastName = "KORPUSIK",
                Sex = "M",
                BirthDate = "1973",
                Nationality = c1,
                EntityState = EntityState.Added
            };
            personRepo.UpdateGraph(p1);
            var p2 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"), p => p.Nationality, p => p.Citizenships);
           
            //when
            p2.Nationality = c2;
            personRepo.UpdateGraph(p2);

            var p3 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"), p => p.Nationality, p => p.Citizenships);
            //then
            Assert.IsNotNull(c2);
            Assert.IsNotNull(p3);
            Assert.IsNotNull(p3.Nationality);
            Assert.AreEqual(p3.Nationality.Name, c2.Name);
        }

        [TestMethod]
        public void mozna_dodac_obywatelstwo()
        {
            //given
            InitializeTest();
            var personRepo = new PersonRepository();
            var countryRepo = new DictionaryItemRepository<Country>();
            var c1 = countryRepo.GetSingle(c => c.Name.Equals("POLSKA"));
            var c2 = countryRepo.GetSingle(c => c.Name.Equals("HOLANDIA"));
            var p1 = new Person()
            {
                Pesel = "73020916001",
                FirstName = "JACEK",
                LastName = "KORPUSIK",
                Sex = "M",
                BirthDate = "1973",
                Nationality = c1
            };
            personRepo.UpdateGraph(p1);
            var p2 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"), p => p.Nationality, p => p.Citizenships);

            //when
            p2.Citizenships.Add(c1);
            p2.Citizenships.Add(c2);
            personRepo.UpdateGraph(p2);

            var p3 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"), p => p.Nationality, p => p.Citizenships);
            //then
            Assert.IsNotNull(p3);
            Assert.AreEqual(2,p3.Citizenships.Count);
        }

        [TestMethod]
        public void mozna_zmienic_obywatelstwo()
        {
            //given
            InitializeTest();
            var personRepo = new PersonRepository();
            var countryRepo = new DictionaryItemRepository<Country>();
            var c1 = countryRepo.GetSingle(c => c.Name.Equals("POLSKA"));
            var c2 = countryRepo.GetSingle(c => c.Name.Equals("HOLANDIA"));
            var c3 = countryRepo.GetSingle(c => c.Name.Equals("FINLANDIA"));
            var p1 = new Person()
            {
                Pesel = "73020916001",
                FirstName = "JACEK",
                LastName = "KORPUSIK",
                Sex = "M",
                BirthDate = "1973",
                Nationality = c1
            };
            personRepo.UpdateGraph(p1);
            var p2 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"), p => p.Nationality, p => p.Citizenships);

            //when
            p2.Citizenships.Add(c1);
            p2.Citizenships.Remove(c2);
            p2.Citizenships.Add(c3);
            personRepo.UpdateGraph(p2);

            var p3 = personRepo.GetSingle(p => p.Pesel.Equals("73020916001"), p => p.Nationality, p => p.Citizenships);
            //then
            Assert.IsNotNull(p3);
            Assert.AreEqual(2, p3.Citizenships.Count);
            Assert.IsNotNull(p3.Citizenships.FirstOrDefault(c=>c.Name.Equals(c3.Name)));
        }
    }
}
