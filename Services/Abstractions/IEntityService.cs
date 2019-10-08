﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Services.Abstractions
{
    public interface IEntityService<T> : IService where T : IEntity
    {
        IQueryable<T> All();
        IIncludableQueryable<T, TProperty> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath);
        T Find(Guid id);
        Task<T> FindAsync(Guid id);
        T First(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50);
        T Create(T entity, out bool isSaved);
        IEnumerable<T> CreateMany(IEnumerable<T> objects, out bool isSaved);
        bool Update(T entity);
        T UpdateStatus(Guid id, string status);
        IEnumerable<T> UpdateMany(IEnumerable<T> objects, out bool isSaved);
        bool Delete(T entity);
        bool DeletePermanent(T entity);
        bool DeletePermanent(IEnumerable<T> objects);
        IEnumerable<T> Delete(IEnumerable<T> objects, out bool isSaved);
        IEnumerable<T> Block(IEnumerable<T> objects, out bool isSaved);
        int Delete(Expression<Func<T, bool>> predicate, out bool isSaved);
        bool Contains(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>> predicate);
        int Count();
    }
}