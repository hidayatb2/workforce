using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  enum UserStatus:byte
    {
        Active=1,
        Inactive=2,
    }

    public enum UserRole:byte
    {
        Admin=1,
        Customer=2,
        Contractor=3,
        Manager=4,
        Labour=5,
    }
}
