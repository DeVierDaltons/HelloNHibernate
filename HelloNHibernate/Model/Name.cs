using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloNHibernate
{
    public class Name
    {
        public virtual string FirstName
        {
            get;
            set;
        }

        public virtual string Initial
        {

            get;
            set;
        }

        public virtual string LastName
        {
            get;
            set;
        }
    }
}