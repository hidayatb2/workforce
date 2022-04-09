using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false,Inherited =false)]     
    public sealed class Unique : Attribute
    {
        public int MyProperty { get; set; }

    }
    
}
