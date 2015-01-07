using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.DataAccess
{
    public interface IKseoContext
    {
        DbSet<Person> Persons { get; }
        DbSet<Question> Questions { get;}
        DbSet<Verification> Verifications { get;}
        DbSet<Country> Countries { get; }
        DbSet<Rank> Ranks { get;  }
        DbSet<Organization> Organizations { get;  }
        DbSet<OrganizationalUnit> OrganizationalUnits { get;  }
        DbSet<QuestionForm> QuestionForms { get; }
        DbSet<QuestionReason> QuestionReasons { get;  }
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
