using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Linq;
using HelloNHibernate.Database;
using HelloNHibernate.Mapping;

namespace HelloNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            //create tables from mapping
            new SchemaExport(NHibernateHelper.Configuration).Create(false, true);
            #region use_inline
            //open connection to db
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                #region add
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
                            StartDate = System.DateTime.Now,
                            EndDate = System.DateTime.Now.AddDays(i)
                        };
                        session.Save(employee);
                        session.Save(employer);
                        session.Save(employment);
                    }
                    tx.Commit();
                }
                #endregion
                #region list
                using (var tx = session.BeginTransaction())
                {
                    //dont forget ToList()
                    var employments = session.Query<Employment>().ToList();
                    foreach (var employment in employments)
                    {
                        Console.Out.WriteLine("Employee: " + employment.Employee.Name.LastName + " end date " + employment.EndDate + " at employer " + employment.Employer.Name);
                    }

                    tx.Commit();
                }
                #endregion
            }
            #endregion
            #region using_repository
            IRepository<Employment> EmploymentRepository = new NHibernateRepository<Employment>();
            IRepository<Employee> EmployeeRepository = new NHibernateRepository<Employee>();
            IRepository<Employer> EmployerRepository = new NHibernateRepository<Employer>();
            #region add
            for (int i = 0; i < 30; i++)
            {
                var employee = new Employee { Name = new Name { FirstName = "Employee", LastName = string.Format("{0}", i) } };
                var employer = new Employer { Name = string.Format("Employer {0}", i) };
                var employment = new Employment
                {
                    Employee = employee,
                    Employer = employer,
                    StartDate = System.DateTime.Now,
                    EndDate = System.DateTime.Now.AddDays(i)
                };
                EmployeeRepository.Save(employee);
                EmployerRepository.Save(employer);
                EmploymentRepository.Save(employment);
            }
            #endregion
            #region show
            foreach (var employment in EmploymentRepository.GetAll())
            {
                Console.Out.WriteLine("Employee: " + employment.Employee.Name.LastName + " end date " + employment.EndDate + " at employer " + employment.Employer.Name);
            }


            #endregion
            #endregion
        }
    }
}
