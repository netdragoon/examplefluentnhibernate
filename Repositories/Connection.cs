using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Repositories.Interfaces;
using System.Collections.Generic;

namespace Repositories
{
    public class Connection : IConnection
    {
        private ISessionFactory sessionFactory;
        private ISession session;
        public Connection()
        {
            OpenSession();
            
        }

        public ISession Session()
        {
            return session;
        }
        public ISessionFactory SessionFactory()
        {
            return sessionFactory;
        }


        public T Add<T>(T model)
        {
            ITransaction trans = session.BeginTransaction();
            session.Save(model);
            trans.Commit();
            session.Flush();
            return model;
        }

        public T Edit<T>(T model)
        {
            ITransaction trans = session.BeginTransaction();
            session.SaveOrUpdate(model);
            trans.Commit();
            session.Flush();
            return model;
        }

        public T Find<T>(object id)
        {
            return session.Get<T>(id);
        }

        public T Find<T>(object id, LockMode lockMode)
        {
            return session.Get<T>(id, lockMode);
        }

        public IList<T> ToList<T>()
            where T : class
        {

            return session.CreateCriteria(typeof(T))
                .List<T>();
        }
        private void OpenSession()
        {

            if (sessionFactory == null)
            {
                sessionFactory = Fluently.Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("ConnSQLServer")).ShowSql())
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Models.Itens>())
                            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                            .BuildSessionFactory();
                session = sessionFactory.OpenSession();
            }
        }
        public void Dispose()
        {
            session.Close();
            sessionFactory.Close();
            session.Dispose();
            sessionFactory.Dispose();
        }
    }
}
