using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.DataAccess;
using Kseo2.Model;

namespace Kseo2.BusinessLayer
{
    public class ReservationService :BusinessService<Reservation>
    {


        public ReservationService(KseoContext kseoContext) : base(kseoContext) {}
        
        public SearchResult<Reservation> Search(Func<Reservation, bool> where, int resultsLimit = 20)
        {
            var query = KseoContext.Reservations.Where(where).AsQueryable();
            var result = new SearchResult<Reservation> { ResultsCounter = query.Count() };
            if (result.ResultsCounter <= resultsLimit)
                result.Results = query.ToList();
            return result;
        }
        
        public Reservation GetReservationById(int id)
        {
            return GetSingle(r => r.Id.Equals(id), r => r.Prolongations, r => r.Purpose, r => r.ReservedPerson,
                r => r.ConductingUnit, r => r.EndReason);
        }

        public Reservation GetReservationFiles(int reservationId)
        {
            return GetSingle(r => r.Id.Equals(reservationId),
                r => r.ReservedPerson,
                r => r.ReservedPerson.Addresses,
                r => r.ReservedPerson.Workplaces,
                r => r.Prolongations,
                r => r.Purpose,
                r => r.ConductingUnit,
                r => r.EndReason);
        }
        
        public IList<Reservation> GetReservationsByPerson(Person person)
        {
            return GetAll(r => r.ReservedPerson.Id.Equals(person.Id), r => r.Purpose, r => r.ConductingUnit,
                r => r.EndReason);
        }
    }
}
