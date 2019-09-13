using Newtonsoft.Json;
using System.Collections.Generic;

namespace Services.Helpers
{
	public static class DictionaryHelper
	{
		public static Dictionary<string, object> ToDictionary(object obj)
		{
			var json = JsonConvert.SerializeObject(obj);

			return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
		}

		public static T ToObject<T>(Dictionary<string, object> dictionary)
		{
			var json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}