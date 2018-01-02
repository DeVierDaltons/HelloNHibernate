using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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