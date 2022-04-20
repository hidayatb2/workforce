using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum BidStatus : byte
    {
        Accepted = 1,
        Pending = 2,
    }


    public enum UserStatus:byte
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

    public enum Gender : byte
    {
        Male = 1,
        Female = 2,
    }

    public enum Skill:byte
    {
        Skilled=1,
        NonSkilled=2,
    }

    public enum WagesType : byte
    {
        Daily = 1,

        Monthly = 2,

        Contract=3,
    }

    public enum FeedbackStatus : byte
    {
        Approved = 1,

        Hidden = 2,
    }
}
