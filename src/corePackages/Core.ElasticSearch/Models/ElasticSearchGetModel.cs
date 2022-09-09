namespace Core.ElasticSearch.Models;

public class ElasticSearchGetModel<T> {
    public String ElasticId { get; set; }
    public T Item { get; set; }
}