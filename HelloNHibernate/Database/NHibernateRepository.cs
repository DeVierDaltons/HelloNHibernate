﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloNHibernate.Database
{
    public class NHibernateRepository<T> : IRepository<T> where T : class
    {
        ISession session = NHibernateHelper.GetSession();

        public void Save(T item)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(item);
                transaction.Commit();
            }
        }

        public T Get(Guid id)
        {
            return session.Get<T>(id);
        }

        public void Update(T item)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(item);
                transaction.Commit();
            }
        }

        public List<T> GetAll()
        {
            return session.Query<T>().ToList();
        }

        public void Delete(T person)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(person);
                transaction.Commit();
            }
        }

        public long RowCount()
        {
            return session.QueryOver<T>().RowCountInt64();
        }
    }
}
