using Kseo2.Model;
using RefactorThis.GraphDiff;

namespace Kseo2.DataAccess
{
    public interface IPersonRepository : IRepository<Person> {}

    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        
        public new void UpdateGraph(Person item)
        {
            using (var context = new KseoContext())
            {
                context.UpdateGraph(item, map => map
                    .AssociatedEntity(p => p.Nationality)
                    .AssociatedCollection(p=>p.Citizenships));
                context.SaveChanges();
                
            }
        }
    }
}
