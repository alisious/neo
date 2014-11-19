using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Service
{
    public interface IPersonService
    {
        SearchResult<Person> Search(string pesel,string lastName,int resultsLimit = 20);
        SearchResult<Person> Search(string lastName, string firstName, string fatherName, string birthDate, int resultsLimit = 20);
        Person GetSingle(int id);
        void AddPerson(Person person);
        void RemovePerson(Person person);
        void SaveChanges();


    }
}
