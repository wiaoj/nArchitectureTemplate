namespace Core.Persistence.Paging;

public record BasePageableModel/*<Type>*/ {
    public Int32 Index { get; set; }
    public Int32 Size { get; set; }
    public Int32 Count { get; set; }
    public Int32 Pages { get; set; }
    public Boolean HasPrevious { get; set; }
    public Boolean HasNext { get; set; }
    //public IList<Type> Items { get; set; }
}