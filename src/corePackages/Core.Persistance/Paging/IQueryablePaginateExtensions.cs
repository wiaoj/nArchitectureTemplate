using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Paging;

public static class IQueryablePaginateExtensions {
	public static async Task<IPaginate<T>> ToPaginateAsync<T>(this IQueryable<T> source, Int32 index, Int32 size,
															  Int32 from = 0,
															  CancellationToken cancellationToken = default) {
		if(from > index)
			throw new ArgumentException($"From: {from} > Index: {index}, must from <= Index");

		Int32 count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
		List<T> items = await source.Skip((index - from) * size).Take(size).ToListAsync(cancellationToken)
									.ConfigureAwait(false);
		Paginate<T> list = new() {
			Index = index,
			Size = size,
			From = from,
			Count = count,
			Items = items,
			Pages = (Int32)Math.Ceiling(count / (Double)size)
		};
		return list;
	}


	public static IPaginate<T> ToPaginate<T>(this IQueryable<T> source, Int32 index, Int32 size,
											 Int32 from = 0) {
		if(from > index)
			throw new ArgumentException($"From: {from} > Index: {index}, must from <= Index");

		Int32 count = source.Count();
		List<T> items = source.Skip((index - from) * size).Take(size).ToList();
		Paginate<T> list = new() {
			Index = index,
			Size = size,
			From = from,
			Count = count,
			Items = items,
			Pages = (Int32)Math.Ceiling(count / (Double)size)
		};
		return list;
	}
}