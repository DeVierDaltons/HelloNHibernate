using System;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using System.Net.Http;

namespace HelloNHibernate
{

    public sealed class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    //Create the session factory
                    _sessionFactory = new Configuration().Configure().BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        
        public static void CloseSession()
        {
            var currentSession = _sessionFactory.GetCurrentSession();

            if (currentSession == null)
            {
                // No current session
                return;
            }

            currentSession.Close();
        }

        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }
    }
}