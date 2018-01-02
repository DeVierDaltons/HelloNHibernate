using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloNHibernate
{
    public class Product
    {

        public virtual string Category
        {
            get => default(string);
            set
            {
            }
        }

        public virtual bool Discontinued
        {
            get => default(bool);
            set
            {
            }
        }

        public virtual string Name
        {
            get => default(string);
            set
            {
            }
        }

        public virtual Guid Id
        {
            get => default(Guid);
            set
            {
            }
        }
    }
}