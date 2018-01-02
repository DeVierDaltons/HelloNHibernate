using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace HelloNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            //new SchemaExport(new Configuration().Configure()).Create(false, true);
            ISession session = NHibernateHelper.SessionFactory.OpenSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    for (int i = 0; i < 30; i++)
                    {
                        var employment = new Employment
                        {
                            Employee = new Employee { Name = new Name { FirstName = "Employee", LastName = string.Format("{0}",i) } },
                            Employer = new Employer { Name = string.Format("Employer {0}", i)},
                            StartDate = new System.DateTime(),
                            EndDate = new System.DateTime().AddDays(i)

                        };
                        session.Save(employment);
                    }
                    tx.Commit();
                }
            }
            finally
            {
                NHibernateHelper.CloseSessionFactory();
            }
        }
    }
}
