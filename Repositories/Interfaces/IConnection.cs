using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Repositories.Interfaces
{
    public interface IConnection : IDisposable
    {
        T Add<T>(T model);
        T Edit<T>(T model);
        T Find<T>(object id);
        T Find<T>(object id, LockMode lockMode);
        IList<T> ToList<T>() where T : class;
        ISession Session();
        ISessionFactory SessionFactory();
        IList SqlQuery(string sql);
    }
}
