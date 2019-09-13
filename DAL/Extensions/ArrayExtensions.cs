﻿using System;

namespace DAL.Extensions
{
	public static class ArrayExtensions
	{
		public static T[] ConcatArray<T>(this T[] array1, T[] array2)
		{
			var initialLength = array1.Length;
			Array.Resize(ref array1, array1.Length + array2.Length);
			array2.CopyTo(array1, initialLength);
			return array1;
		}
	}
}