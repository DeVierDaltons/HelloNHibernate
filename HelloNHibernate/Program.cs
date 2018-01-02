using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Linq;

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
                /*
                using (ITransaction tx = session.BeginTransaction())
                {
                    for (int i = 0; i < 30; i++)
                    {
                        var employee = new Employee { Name = new Name { FirstName = "Employee", LastName = string.Format("{0}", i) } };
                        var employer = new Employer { Name = string.Format("Employer {0}", i) };
                        var employment = new Employment
                        {
                            Employee = employee,
                            Employer = employer,
                            StartDate = new System.DateTime(),
                            EndDate = new System.DateTime().AddDays(i)
                        };
                        session.Save(employee);
                        session.Save(employer);
                        session.Save(employment);
                    }
                    tx.Commit();
                }
                using (var tx = session.BeginTransaction())
                {
                    var employments = session.Query<Employment>().Where(w => w.Employee.Name.FirstName == "Employee").ToList();
                    foreach (var employee in employments)
                    {
                        Console.Out.WriteLine("Employee: " + employee.Employee.Name.LastName);
                    }

                    tx.Commit();
                }
                */
                using (var tx = session.BeginTransaction())
                {
                    var employments = session.Query<Employment>().ToList();
                    foreach (var employment in employments)
                    {
                        Console.Out.WriteLine("Employee: " + employment.Employee.Name.LastName + " end date " + employment.EndDate + " at employer " + employment.Employer.Name);
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
