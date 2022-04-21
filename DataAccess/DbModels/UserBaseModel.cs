using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserBaseModel: BaseModel
    {

        public string Name { get; set; }


        public Gender Gender { get; set; }


        public string Address { get; set; }


        public string Bank { get; set; }


        public string AccountNo { get; set; }


        public string IFSC { get; set; }


        public string JobProfile { get; set; }


        public string Experience { get; set; }


        public WagesType WagesType { get; set; }


        public int Wages { get; set; }


        public string Discription { get; set; }


    }
}
