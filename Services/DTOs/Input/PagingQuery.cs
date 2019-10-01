namespace Services.DTOs.Input
{
	public class PagingQuery
	{
		public int Page { get; set; } = 1;
		public int Limit { get; set; } = 20;
		public string Sort { get; set; } 
	}
}