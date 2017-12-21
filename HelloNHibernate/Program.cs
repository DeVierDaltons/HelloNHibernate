using HelloNHibernate.Dao;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            var schemaUpdate = new SchemaUpdate(NHibernateHelper.Configuration);
            schemaUpdate.Execute(Console.WriteLine, true);
        }
    }
}
