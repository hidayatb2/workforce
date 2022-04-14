using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Skill:BaseModel,IBaseModel
    {
        public Guid Id { get; set; }


        public string SkillName { get; set; }


        public string Experience { get; set; }


        public WagesType WagesType { get; set; }


        public float Wages { get; set; }

        public Guid LabourId { get; set; }


        [ForeignKey(nameof(LabourId))]
        public Labour Labour { get; set; }
    }
}
