using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloNHibernate
{
    public class Employment
    {
        public virtual System.Guid Id
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