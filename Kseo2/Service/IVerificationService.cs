using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Service
{
    public interface IVerificationService
    {
        void AddVerification(Verification verification);
        void RemoveVerification(Verification verification);
        void UpdateVerification(Verification verification);
        Verification GetSingle(int id); 
        SearchResult<Verification> Search(string regNum,string pesel, string firstName, string lastName, int resultsLimit = 20);
        SearchResult<Verification> Search(User author,DateTime creationDate, int resultsLimit = 20);
        

    }
}
