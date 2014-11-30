using System.Threading;
using Kseo2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Service
{
    public class VerificationService :Service, IVerificationService
    {
        public VerificationService(KseoContext ctx) :base(ctx) { }

        public void AddVerification(Model.Verification verification)
        {
            try
            {
                _context.Verifications.Add(verification);
            }
            catch (Exception e)
            {
                var sb = new StringBuilder(@"Błąd zapisu w repozytorium!");
                sb.AppendLine(e.Message);
                throw new Exception(sb.ToString(), e);
            }
        }

        public void RemoveVerification(Model.Verification verification)
        {
            throw new NotImplementedException();
        }

        public SearchResult<Model.Verification> Search(string regNum, string pesel, string firstName, string lastName, int resultsLimit = 20)
        {
            throw new NotImplementedException();
        }

        public SearchResult<Model.Verification> Search(Model.User author, DateTime creationDate, int resultsLimit = 20)
        {
            throw new NotImplementedException();
        }
    }
}
