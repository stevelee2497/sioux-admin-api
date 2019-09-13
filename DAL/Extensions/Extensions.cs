using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DAL.Extensions
{
	public static class TypeExtensions
	{
		public static List<T> GetConstantValues<T>(this Type type)
		{
			return type
				.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
				.Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(T))
				.Select(x => (T)x.GetRawConstantValue())
				.ToList();
		}
	}
}