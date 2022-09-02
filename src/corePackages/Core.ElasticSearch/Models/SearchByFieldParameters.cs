namespace Core.ElasticSearch.Models;

public class SearchByFieldParameters : SearchParameters {
	public String FieldName { get; set; }
	public String Value { get; set; }
}