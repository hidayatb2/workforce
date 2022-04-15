﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository : IRepository
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<T> FromQuery<T>(string sql, params object[] parameters) where T : class
        {
            return dbContext.SqlQuery<T>(sql, parameters);
        }
        public T GetObject<T>(string sql, params object[] parameters) where T : class
        {
            return dbContext.SqlQuery<T>(sql, parameters).FirstOrDefault();
        }
        public IEnumerable<T> GetAllUsers<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public T GetById<T>(Guid id) where T : class
        {
            return dbContext.Set<T>().Find(id);
        }


        public int AddandSave<T>(T model) where T : class
        {
            dbContext.Set<T>().Add(model);
            return dbContext.SaveChanges();
        }

        public IQueryable<T> FindBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            return dbContext.Set<T>().Where(predicate);
        }

        public bool IsExist<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            return dbContext.Set<T>().Any(predicate);
        }

    }
    public static class EFExtensions
    {
        public static IQueryable<T> IncludeNav<T, TProperty>(this IQueryable<T> query, Expression<Func<T, TProperty>> expression) where T : class
        {
            return query.Include(expression);
        }

        public T GetById<T>(Guid id) where T : class
        {
            return dbContext.Set<T>().Find(id);
        }

<<<<<<< Updated upstream
         int IRepository.Delete<T>(T model)
        {
            dbContext.Set<T>().Remove(model);
           return dbContext.SaveChanges();
        }
=======
        public static IQueryable<T> IncludeNav<T>(this IQueryable<T> query, params string[] navProperties) where T : class
        {
            foreach (var navProperty in navProperties)
                query = query.Include(navProperty);
            return query;
        }

        public static IQueryable<T> SqlQuery<T>(this DbContext db, string sql, params object[] parameters) where T : class
        {
            ContextForQueryType<T> db2 = new(db.Database.GetDbConnection());
            return db2.Set<T>().FromSqlRaw(sql, parameters);
        }
    }
    public class ContextForQueryType<T> : DbContext where T : class
    {
        private readonly DbConnection connection;

        public ContextForQueryType(DbConnection connection)
        {
            this.connection = connection;
        }

>>>>>>> Stashed changes

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection, options => options.EnableRetryOnFailure());

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
