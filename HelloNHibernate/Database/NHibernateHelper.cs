using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using HelloNHibernate.Mapping;
using System.Collections.Generic;
using System;

namespace HelloNHibernate.Database
{

    public sealed class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static HbmMapping _mapping;
        private static Configuration _configuration;
        private static ISession _session;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    //Create the session factory
                    _sessionFactory = Configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }
        public static Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    //Create the nhibernate configuration
                    _configuration = CreateConfiguration();
                }
                return _configuration;
            }
        }

        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            configuration.Configure();
            //Loads nhibernate mappings 
            configuration.AddDeserializedMapping(Mapping, null);

            return configuration;
        }


        public static HbmMapping Mapping
        {
            get
            {
                if (_mapping == null)
                {
                    //Create the mapping
                    _mapping = CreateMapping();
                }
                return _mapping;
            }
        }
        
        private static HbmMapping CreateMapping()
        {
            var mapper = new ModelMapper();
            //Add the person mapping to the model mapper
            mapper.AddMappings(new List<System.Type> { typeof(EmployerMap), typeof(EmploymentMap), typeof(EmployeeMap) });
            //Create and return a HbmMapping of the model mapping in code
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }

        public static ISession GetSession()
        {            
                //Open and return the nhibernate session 
                return _session ?? SessionFactory.OpenSession();
        }
    }
}