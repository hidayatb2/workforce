using Models;
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

        IQueryable<T> FromQuery<T>(string sql, params object[] parameters) where T : class;


        T GetObject<T>(string sql, params object[] parameters) where T : class;

        T GetById<T>(Guid id) where T : class;


        int AddandSave<T>(T model) where T : class;


<<<<<<< Updated upstream
        public int Delete<T>(T model) where T : class;

        T GetById<T>(Guid id) where T : class;

=======
        IQueryable<T> FindBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
>>>>>>> Stashed changes


        bool IsExist<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
    }
}
