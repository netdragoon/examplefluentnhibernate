using NHibernate;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    public interface ICrud<T>
        where T : class, new()
    {
        IConnection Connection { get; }
        T Add(T model);
        T Edit(T model);
        T Find(object id);
        T Find(object id, LockMode lockMode);
        IList<T> ToList();
    }
}
