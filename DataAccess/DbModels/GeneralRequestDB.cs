using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GeneralRequestDB
    {

        public Guid Id { get; set; }


        public string Name { get; set; }


        public string Message { get; set; }


        public UserRole UserRole { get; set; }


        public Guid CurrentUserId { get; set; } 


    }
}
