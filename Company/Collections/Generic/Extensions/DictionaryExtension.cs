using System;
using System.Collections.Generic;
using System.Linq;

namespace Company.Collections.Generic.Extensions
{
	public static class DictionaryExtension
	{
		#region Methods

		public static void Sort<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer)
		{
			if(dictionary == null)
				throw new ArgumentNullException("dictionary");

			var dictionaryCopy = new Dictionary<TKey, TValue>(dictionary);

			dictionary.Clear();

			foreach(var key in dictionaryCopy.Keys.OrderBy(item => item, comparer))
			{
				dictionary.Add(key, dictionaryCopy[key]);
			}
		}

		#endregion
	}
}