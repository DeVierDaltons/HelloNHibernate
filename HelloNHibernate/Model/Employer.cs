using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloNHibernate
{
    public class Employer
    {
        public virtual System.Guid Id
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }
    }
}