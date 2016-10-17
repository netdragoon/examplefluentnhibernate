using NHibernate;
using Repositories.Interfaces;
using System.Collections.Generic;
using System;
using System.Collections;

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

        public IList SqlQuery(string sql)
        {
            return Connection.SqlQuery(sql);
        }

        public T First(string sql, IDictionary<string, object> parameters)
        {
            var q = Connection.Query(sql);
            foreach(var p in parameters)
            {
                q = q.SetParameter(p.Key, p.Value);
            }   
            return q.UniqueResult<T>();
        }
    }
}
