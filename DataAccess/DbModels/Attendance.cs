using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Attendance
    {
        [Key]
        public Guid AttendaceId { get; set; }


        public DateTime Date { get; set; }
        

        public DateTime TimeIn { get; set; }


        public DateTime TimeOut { get; set; }



        public Guid LabourId { get; set; }


        [ForeignKey(nameof(LabourId))]
        public Labour Labour { get; set; }

    }
}
