using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class UserAttendanceRequest
    {

        public Guid Id { get; set; }

      
       [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime In { get; set; }

        [DataType(DataType.Time)]
        public DateTime Out { get; set; }


        public Guid LabourId { get; set; }
    }

    public class UserAttendanceResponse:UserAttendanceRequest
    {
        public int TotalWorkingHours { get; set; }
    }
}
