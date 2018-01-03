using System;

namespace HelloNHibernate
{
    public class Employment
    {
        public virtual int Id
        {

            get;
            set;
        }

        public virtual DateTime EndDate
        {

            get;
            set;
        }

        public virtual DateTime StartDate
        {

            get;
            set;
        }

        public virtual Employer Employer
        {

            get;
            set;
        }

        public virtual Employee Employee
        {

            get;
            set;
        }

        public virtual MonetaryAmount HourlyRate
        {

            get;
            set;
        }
    }
}