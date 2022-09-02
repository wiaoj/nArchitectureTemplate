namespace Core.ElasticSearch.Models;

public class SearchByQueryParameters : SearchParameters {
	public String QueryName { get; set; }
	public String Query { get; set; }
	public String[] Fields { get; set; }
}