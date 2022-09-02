namespace Core.ElasticSearch.Models;

public interface IElasticSearchResult {
	Boolean Success { get; }
	String Message { get; }
}