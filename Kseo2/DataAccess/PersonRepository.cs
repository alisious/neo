using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorThis.GraphDiff;
using EntityState = System.Data.Entity.EntityState;

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
