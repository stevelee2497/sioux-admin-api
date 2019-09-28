﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Repositories.Abstractions
{
	public interface IGenericRepository<T> : IRepository where T : IEntity
	{
		IQueryable<T> All();

		IIncludableQueryable<T, TProperty> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath);

		T Find(Guid id);

		Task<T> FindAsync(Guid id);

        T First(Expression<Func<T, bool>> predicate);

		T FirstOrDefault(Expression<Func<T, bool>> predicate);

		IQueryable<T> Where(Expression<Func<T, bool>> predicate);

		IQueryable<T> Where(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

		bool Contains(Expression<Func<T, bool>> predicate);

		T Create(T t, out bool isSaved);

		IEnumerable<T> CreateMany(IEnumerable<T> ts, out bool isSaved);

		bool Update(T t);

		IEnumerable<T> UpdateMany(IEnumerable<T> ts, out bool isSaved);

		bool Delete(T t);

		IEnumerable<T> Delete(IEnumerable<T> objects, out bool isSaved);

		IEnumerable<T> Block(IEnumerable<T> objects, out bool isSaved);

		int Delete(Expression<Func<T, bool>> predicate, out bool isSaved);

		int Count(Expression<Func<T, bool>> predicate);

		int Count();
	}
}