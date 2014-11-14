using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.DataAccess
{
    public class KseoContextInitializer : DropCreateDatabaseAlways<KseoContext>
    {
        protected override void Seed(KseoContext context)
        {


         #region Inicjowanie słowników
            context.Countries.AddRange(new List<Country>()
            {
                new Country() {Name="PL",LongName="POLSKA"},
                new Country() {Name="USA",LongName="STANY ZJEDNOCZONE AMERYKI"},
                new Country() {Name="AU",LongName="AUSTRIA"},
                new Country() {Name="GB",LongName="WIELKA BRYTANIA"},
                new Country() {Name="RU",LongName="ROSJA"},
                new Country() {Name="NL",LongName="HOLANDIA"}
            }
                ); 

         #endregion


            for (int i = 0; i < 100; i++)
            {
                string pesel = "00000000000"+i.ToString();
                context.Persons.Add(new Person() { Pesel = pesel.Substring(pesel.Length-11,11), FirstName = "IMIĘ"+i.ToString(), LastName = "NAZWISKO"+i.ToString() });
            }

            context.SaveChanges();
        }
    }
}
