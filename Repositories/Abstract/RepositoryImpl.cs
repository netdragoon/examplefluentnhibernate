using NHibernate;
using Repositories.Interfaces;
using System.Collections.Generic;

namespace Repositories.Abstract
{
    public abstract class RepositoryImpl<T>: ICrud<T>
        where T: class, new()
    {
        public IConnection Connection { get; private set; }
        public RepositoryImpl(IConnection connection)
        {
            Connection = connection;
        }

        public T Add(T model)
        {
            Connection.Add(model);
            return model;
        }

        public T Edit(T model)
        {
            Connection.Edit(model);
            return model;
        }

        public T Find(object id)
        {
            return Connection.Find<T>(id);
        }

        public T Find(object id, LockMode lockMode)
        {
            return Connection.Find<T>(id, lockMode);
        }

        public IList<T> ToList()
        {
            return Connection.ToList<T>();
        }
    }
}
