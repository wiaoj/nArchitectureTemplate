namespace Core.Persistence.Paging;

public interface IPaginate<T> {
    Int32 From { get; }
    Int32 Index { get; }
    Int32 Size { get; }
    Int32 Count { get; }
    Int32 Pages { get; }
    IList<T> Items { get; }
    Boolean HasPrevious { get; }
    Boolean HasNext { get; }
}