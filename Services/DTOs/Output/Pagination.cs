using System.Collections.Generic;

namespace Services.DTOs.Output
{
	public class Pagination<T>
	{
		public int Page { get; set; }
		public int Limit { get; set; }
		public IEnumerable<T> Objects { get; set; }
	}
}