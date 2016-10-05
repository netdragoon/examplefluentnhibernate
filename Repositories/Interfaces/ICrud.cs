using NHibernate;

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
        System.Collections.Generic.IList<T> ToList();
        System.Collections.IList SqlQuery(string sql);
    }
}
