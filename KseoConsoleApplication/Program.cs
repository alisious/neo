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
            var pl = businessLayer.GetDictionaryItemByName<Country>("POLSKA");
            var af = businessLayer.GetDictionaryItemByName<Country>("AFGANISTAN");
            var al = businessLayer.GetDictionaryItemByName<Country>("ALBANIA");
            /*
            var ja = new Person
            {
                Pesel = "73020916563",
                LastName = "KORPUSIK",
                FirstName = "JACEK",
                BirthDate = "1973-02-09",
                BirthPlace = "HONOLULU",
                Sex = "M",
                Nationality = pl,
                Citizenships = new HashSet<Country>(){pl,af},
                EntityState = EntityState.Added
            };
            businessLayer.AddPerson(new Person[]{ja});
            Console.WriteLine(@"Dodana osoba:");
            var osoby = businessLayer.GetAllPersons();
            foreach (var osoba in osoby)
            {
                Console.WriteLine(osoba.Pesel);
            }
             */ 
            var o = businessLayer.GetPersonByPesel("73020916563");
            //o.Citizenships.Remove(af);
            al.EntityState = EntityState.Added;
            o.Citizenships.Add(al);
            o.EntityState = EntityState.Modified;
            businessLayer.UpdatePerson(o);
            o = businessLayer.GetPersonByPesel("73020916563");
            Console.WriteLine(String.Format("{0} {1} Narodowość: {2}",o.FirstName,o.LastName,o.Nationality.Name));
            foreach (var ob in o.Citizenships)
            {
                Console.WriteLine(String.Format("Obywatelstwo: {0}", ob.Name));
            }
            Console.ReadLine();
        }
    }
}
