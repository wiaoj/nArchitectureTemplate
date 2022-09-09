namespace Core.ElasticSearch.Models;

public class ElasticSearchInsertManyModel : ElasticSearchModel {
    public Object[] Items { get; set; }
}