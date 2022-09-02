namespace Core.Application.Pipelines.Caching;

public interface ICacheRemoverRequest {
	Boolean BypassCache { get; }
	String CacheKey { get; }
}