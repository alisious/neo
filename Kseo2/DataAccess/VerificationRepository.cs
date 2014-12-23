using Kseo2.Model;
using RefactorThis.GraphDiff;

namespace Kseo2.DataAccess
{
    public interface IVerificationRepository : IRepository<Verification> { }

    public class VerificationRepository : Repository<Verification>, IVerificationRepository
    {

        public new void UpdateGraph(Verification item)
        {
            using (var context = new KseoContext())
            {
                context.UpdateGraph(item, map => map
                    .AssociatedEntity(v => v.Nationality)
                    .AssociatedCollection(v => v.Citizenships)
                    .AssociatedEntity(v=>v.Question)
                    .AssociatedEntity(v=>v.FoundedPerson));
                context.SaveChanges();

            }
        }
    }
}
