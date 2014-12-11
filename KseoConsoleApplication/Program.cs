using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.BusinessLayer;
using Kseo2.Model;

namespace KseoConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var businessLayer = new BusinessLayer();
            var country = businessLayer.GetCountryByName("POLSKA");
            var ja = new Person
            {
                Pesel = "73020916561",
                LastName = "KORPUSIK",
                FirstName = "JACEK",
                BirthDate = "1973-02-09",
                BirthPlace = "HONOLULU",
                Sex = "M",
                Nationality = country,
                EntityState = EntityState.Added
            };
            businessLayer.AddPerson(new Person[]{ja});
            Console.WriteLine(@"Dodana osoba:");
            var osoby = businessLayer.GetAllPersons();
            foreach (var osoba in osoby)
            {
                Console.WriteLine(osoba.Pesel);
            }
            var o = businessLayer.GetPersonByPesel("73020916561");
            Console.WriteLine(String.Format("{0} {1} Narodowość: {2}",o.FirstName,o.LastName,o.Nationality.Name));
            Console.ReadLine();
        }
    }
}
