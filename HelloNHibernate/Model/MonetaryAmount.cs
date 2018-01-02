using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloNHibernate
{
    public class MonetaryAmount
    {
        public virtual int Amount
        {
            get;
            set;
        }

        public virtual string Currency
        {
            get;
            set;
        }
    }
}