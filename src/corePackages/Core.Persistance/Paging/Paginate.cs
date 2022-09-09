namespace Core.Persistence.Paging;

public class Paginate<T> : IPaginate<T> {
    internal Paginate(IEnumerable<T> source, Int32 index, Int32 size, Int32 from) {
        var enumerable = source as T[] ?? source.ToArray();

        if(from > index)
            throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");

        if(source is IQueryable<T> querable) {
            Index = index;
            Size = size;
            From = from;
            Count = querable.Count();
            Pages = (Int32)Math.Ceiling(Count / (Double)Size);

            Items = querable.Skip((Index - From) * Size).Take(Size).ToList();
        } else {
            Index = index;
            Size = size;
            From = from;

            Count = enumerable.Count();
            Pages = (Int32)Math.Ceiling(Count / (Double)Size);

            Items = enumerable.Skip((Index - From) * Size).Take(Size).ToList();
        }
    }

    internal Paginate() {
        Items = new T[0];
    }

    public Int32 From { get; set; }
    public Int32 Index { get; set; }
    public Int32 Size { get; set; }
    public Int32 Count { get; set; }
    public Int32 Pages { get; set; }
    public IList<T> Items { get; set; }
    public Boolean HasPrevious => Index - From > 0;
    public Boolean HasNext => Index - From + 1 < Pages;
}

internal class Paginate<TSource, TResult> : IPaginate<TResult> {
    public Paginate(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
                    Int32 index, Int32 size, Int32 from) {
        var enumerable = source as TSource[] ?? source.ToArray();

        if(from > index)
            throw new ArgumentException($"From: {from} > Index: {index}, must From <= Index");

        if(source is IQueryable<TSource> queryable) {
            Index = index;
            Size = size;
            From = from;
            Count = queryable.Count();
            Pages = (Int32)Math.Ceiling(Count / (Double)Size);

            var items = queryable.Skip((Index - From) * Size).Take(Size).ToArray();

            Items = new List<TResult>(converter(items));
        } else {
            Index = index;
            Size = size;
            From = from;
            Count = enumerable.Count();
            Pages = (Int32)Math.Ceiling(Count / (Double)Size);

            var items = enumerable.Skip((Index - From) * Size).Take(Size).ToArray();

            Items = new List<TResult>(converter(items));
        }
    }


    public Paginate(IPaginate<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter) {
        Index = source.Index;
        Size = source.Size;
        From = source.From;
        Count = source.Count;
        Pages = source.Pages;

        Items = new List<TResult>(converter(source.Items));
    }

    public Int32 Index { get; }

    public Int32 Size { get; }

    public Int32 Count { get; }

    public Int32 Pages { get; }

    public Int32 From { get; }

    public IList<TResult> Items { get; }

    public Boolean HasPrevious => Index - From > 0;

    public Boolean HasNext => Index - From + 1 < Pages;
}

public static class Paginate {
    public static IPaginate<T> Empty<T>() {
        return new Paginate<T>();
    }

    public static IPaginate<TResult> From<TResult, TSource>(IPaginate<TSource> source,
                                                            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter) {
        return new Paginate<TSource, TResult>(source, converter);
    }
}