using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace HelloNHibernate.Mapping
{
    public class EmployerMap : ClassMapping<Employer>
    {
        public EmployerMap()
        {
            Table("employers");
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.Name);
        }

    }
    public class EmploymentMap : ClassMapping<Employment>
    {
        public EmploymentMap()
        {
            Table("employment_periods");
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.StartDate);
            Property(x => x.EndDate);
            Component<MonetaryAmount>(x => x.HourlyRate);
        }
    }
    public class EmployeeMap : ClassMapping<Employee>
    {
        public EmployeeMap()
        {
            Table("employees");
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.TaxfileNumber);
            Component<Name>(x => x.Name);
        }

    }
}
