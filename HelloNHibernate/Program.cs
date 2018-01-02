using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelloNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();
            String ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NHibernateTestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = ConnectionString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var sefact = cfg.BuildSessionFactory();
            using (var session = sefact.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {

                    var student1 = new Product
                    {
                        Category = "Blha",
                        Name = "blah",
                        Id = new Guid()
                        

                    };

                    var student2 = new Product
                    {
                        Category = "Glah",
                        Name = "Konijn",
                        Id = new Guid()
                    };

                    session.Save(student1);
                    session.Save(student2);
                    tx.Commit();
                }

                Console.ReadLine();
            }
        }
    }
}
