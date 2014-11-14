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
        PersonSearchResult Search(string pesel,string lastName,int resultsLimit = 20);
        PersonSearchResult Search(string lastName, string firstName, string fatherName, string birthDate, int resultsLimit = 20);
        void AddPerson(Person person);
        void RemovePerson(Person person);


    }
}
