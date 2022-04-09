using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository
    {
        IEnumerable<T> GetAllUsers<T>() where T : class;

        int AddandSave<T>(T model) where T : class;

        IEnumerable<T> FindBy<T>(Expression<Func<T,bool>> expression) where T : class;

        public bool IsExist<T>(Expression<Func<T,bool>> expression) where T : class;


    }
}
