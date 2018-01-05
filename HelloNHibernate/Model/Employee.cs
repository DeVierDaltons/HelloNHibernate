namespace HelloNHibernate
{
    public class Employee
    {
        public virtual System.Guid Id
        {

            get;
            set;
        }

        public virtual int TaxfileNumber
        {

            get;
            set;
        }

        public virtual Name Name
        {

            get;
            set;
        }
    }
}