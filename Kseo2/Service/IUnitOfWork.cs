using Kseo2.DataAccess;
using System;


namespace Kseo2.Service
{
    public interface IUnitOfWork
    {
        KseoContext Context();
        void SaveChanges();
    }
}
