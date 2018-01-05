using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace HelloNHibernate.Mapping
{
    public class EmployerMap : ClassMapping<Employer>
    {
        public EmployerMap()
        {
            Table("employers");
            //Id(x => x.Id, m => m.Generator(Generators.HighLow));
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.Name);
        }

    }
    public class EmploymentMap : ClassMapping<Employment>
    {
        public EmploymentMap()
        {
            Table("employment_periods");
            //Id(x => x.Id, m => m.Generator(Generators.HighLow));
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.StartDate, m => m.Column("start_date"));
            Property(x => x.EndDate, m => m.Column("end_date"));
            Component<MonetaryAmount>(x => x.HourlyRate, c =>
            {
                c.Property(m => m.Amount, k =>
                {
                    k.Column(l =>
                    {
                        l.Name("hourly_rate");
                        l.SqlType("NUMERIC(12, 2)");
                    });
                });
                c.Property(m => m.Currency, k => k.Length(12));

            });
            ManyToOne(x => x.Employer, m => m.Column(c =>
            {
                c.Name("employer_id");
                c.NotNullable(true);
            }));
            ManyToOne(x => x.Employee, m => m.Column(c =>
            {
                c.Name("employee_id");
                c.NotNullable(true);
            }));

        }
    }

    public class EmployeeMap : ClassMapping<Employee>
    {
        public EmployeeMap()
        {
            Table("employees");
            //Id(x => x.Id, m => m.Generator(Generators.HighLow));
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.TaxfileNumber);
            Component<Name>(x => x.Name, c =>
            {
                c.Property(m => m.FirstName);
                c.Property(m => m.Initial);
                c.Property(m => m.LastName);
            });
        }

    }
}
