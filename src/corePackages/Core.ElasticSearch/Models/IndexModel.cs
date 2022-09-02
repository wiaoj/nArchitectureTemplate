namespace Core.ElasticSearch.Models;

public class IndexModel {
	public String IndexName { get; set; }
	public String AliasName { get; set; }
	public Int32 NumberOfReplicas { get; set; } = 3;
	public Int32 NumberOfShards { get; set; } = 3;
}