namespace Core.Application.Pipelines.Caching;

public interface ICachableRequest {
    Boolean BypassCache { get; }
    String CacheKey { get; }
    TimeSpan? SlidingExpiration { get; }
}