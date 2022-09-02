namespace Core.ElasticSearch.Models;

public class ElasticSearchResult : IElasticSearchResult //todo: refactor
{
	public ElasticSearchResult(Boolean success, String message) : this(success) {
		Message = message;
	}

	public ElasticSearchResult(Boolean success) {
		Success = success;
	}

	public Boolean Success { get; set; }
	public String Message { get; set; }
}