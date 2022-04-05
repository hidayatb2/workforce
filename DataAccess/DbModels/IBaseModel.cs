using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbModels
{
    public interface IBaseModel
    {
        public Guid Id { get; set; }
    }
}
