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
        IQueryable<T> GetAll<T>() where T : class;


        int UpdateAndSave<T>(T model) where T : class;


        T GetById<T>(Guid id) where T : class;


        int AddandSave<T>(T model) where T : class;


        int Delete<T>(T model) where T : class;


        void Delete<T>(Guid id) where T : class, IBaseModel, new();


        IQueryable<T> FindBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;


        bool IsExist<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;


        IQueryable<T> FromQuery<T>(string sql, params object[] parameters) where T : class;



        T GetObject<T>(string sql, params object[] parameters) where T : class;

    }
}
