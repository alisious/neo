using System.Data.Entity;
using System.Threading;
using Kseo2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using Kseo2.Model;


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
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                var sb = new StringBuilder();
                sb.AppendLine(this.GetType().ToString());
                sb.AppendLine(@"Nie powiodła się walidacja danych!");
                sb.AppendLine(e.Message);
                throw new DbEntityValidationException(sb.ToString(), e);
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
            try
            {
                //Jeśli jest tylko jedno sprawdzenie w zapytaniu to usuwamy również zapytanie
                var q = verification.Question;
                _context.Verifications.Remove(verification);
                if (q.Verifications.Count == 0) _context.Questions.Remove(q);   
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                var sb = new StringBuilder(@"Błąd zapisu w repozytorium!");
                sb.AppendLine(e.Message);
                throw new Exception(sb.ToString(), e);
            }
        }

        public Verification GetSingle(int id)
        {
            return _context.Verifications.Include(e => e.Question).FirstOrDefault(e => e.Id == id);
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
