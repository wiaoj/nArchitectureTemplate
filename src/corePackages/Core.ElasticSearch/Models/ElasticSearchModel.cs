using Nest;

namespace Core.ElasticSearch.Models;

public class ElasticSearchModel {
    public Id ElasticId { get; set; }
    public String IndexName { get; set; }
}