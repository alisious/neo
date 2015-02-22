using System;
using Kseo2.DataAccess;
using Kseo2.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kseo2.Tests.UnitTests.DataAccess
{
    [TestClass]
    public class RepositoryUnitTest
    {
        [TestInitialize]
        public void InitializeTestContext()
        {
            var context = new KseoContext();
            context.Database.Initialize(true);
           
        }

        [TestMethod]
        public void mozna_zpisac_osobe()
        {
            //given
            var personRepo = new PersonRepository();
            var countryRepo = new CountryRepository();
            var c1 = countryRepo.GetSingle(c => c.Name.Equals("POLSKA"));
            var c2 = countryRepo.GetSingle(c => c.Name.Equals("AFGANISTAN"));
            var p1 = new Person
            {
                Pesel = "73020916558",
                FirstName = "JACEK",
                LastName = "KORPUSIK",
                Sex = "M",
                BirthDate = "1973-02-09",
                Nationality = c1,
                EntityState = EntityState.Added
            };
            p1.Citizenships.Add(c1);
            p1.Citizenships.Add(c2);

            //when
            personRepo.UpdateSingle(p1);
            var p2 = personRepo.GetSingle(p => p.Pesel.Equals("73020916558"), p => p.Citizenships, p => p.Nationality);
            
            //then
            Assert.IsNotNull(c1);
            Assert.IsNotNull(c2);
            Assert.IsNotNull(p2);
            Assert.IsNotNull(p2.Nationality);
            Assert.AreEqual(2, p2.Citizenships.Count);
        }

        [TestMethod]
        public void mozna_zmienic_dodac_obywatelstwo_i_zmienic_narodowosc_osoby()
        {
            //given
            var personRepo = new PersonRepository();
            var countryRepo = new CountryRepository();
            var c1 = countryRepo.GetSingle(c => c.Name.Equals("POLSKA"));
            var c2 = countryRepo.GetSingle(c => c.Name.Equals("AFGANISTAN"));
            
            var p1 = new Person
            {
                Pesel = "73020916558",
                FirstName = "JACEK",
                LastName = "KORPUSIK",
                Sex = "M",
                BirthDate = "1973-02-09",
                Nationality = c1,
                EntityState = EntityState.Added
            };
            p1.Citizenships.Add(c1);
            p1.Citizenships.Add(c2);

            //when
            personRepo.UpdateSingle(p1);
            var p2 = personRepo.GetSingle(p => p.Pesel.Equals("73020916558"), p => p.Citizenships, p => p.Nationality);
            var c3 = countryRepo.GetSingle(c => c.Name.Equals("HOLANDIA"));
            p2.Nationality = c2;
            p2.Citizenships.Add(c3);
            p2.EntityState = EntityState.Modified;
            personRepo.UpdateSingle(p2);
            p1 = personRepo.GetSingle(p => p.Pesel.Equals("73020916558"), p => p.Citizenships, p => p.Nationality);

            //then
            Assert.IsNotNull(p1);
            Assert.IsNotNull(p1.Nationality);
            Assert.AreEqual(c2.Name,p1.Nationality.Name);
            Assert.AreEqual(3, p2.Citizenships.Count);
        }
    }
}
