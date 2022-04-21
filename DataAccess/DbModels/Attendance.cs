using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Attendance
    {
        public Guid AttendaceId { get; set; }


        public DateTime AttendanceTime { get; set; }


        public bool CheckAttendance { get; set; }

        [ForeignKey(nameof(AttendaceId))]
        public Labour Labour { get; set; }

    }
}
