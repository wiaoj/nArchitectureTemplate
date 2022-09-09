namespace Core.ElasticSearch.Models;

public class SearchParameters {
    public String IndexName { get; set; }
    public Int32 From { get; set; } = 0;
    public Int32 Size { get; set; } = 10;
}