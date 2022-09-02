using System.Linq.Dynamic.Core;
using System.Text;

namespace Core.Persistence.Dynamic;

public static class IQueryableDynamicFilterExtensions {
	private static readonly IDictionary<String, String>
		Operators = new Dictionary<String, String>
		{
			{ "eq", "=" },
			{ "neq", "!=" },
			{ "lt", "<" },
			{ "lte", "<=" },
			{ "gt", ">" },
			{ "gte", ">=" },
			{ "isnull", "== null" },
			{ "isnotnull", "!= null" },
			{ "startswith", "StartsWith" },
			{ "endswith", "EndsWith" },
			{ "contains", "Contains" },
			{ "doesnotcontain", "Contains" }
		};

	public static IQueryable<T> ToDynamic<T>(
		this IQueryable<T> query, Dynamic dynamic) {
		if(dynamic.Filter is not null)
			query = Filter(query, dynamic.Filter);
		if(dynamic.Sort is not null && dynamic.Sort.Any())
			query = Sort(query, dynamic.Sort);
		return query;
	}

	private static IQueryable<T> Filter<T>(
		IQueryable<T> queryable, Filter filter) {
		IList<Filter> filters = GetAllFilters(filter);
		String?[] values = filters.Select(f => f.Value).ToArray();
		String where = Transform(filter, filters);
		queryable = queryable.Where(where, values);

		return queryable;
	}

	private static IQueryable<T> Sort<T>(
		IQueryable<T> queryable, IEnumerable<Sort> sort) {
		if(sort.Any()) {
			String ordering = String.Join(",", sort.Select(s => $"{s.Field} {s.Dir}"));
			return queryable.OrderBy(ordering);
		}

		return queryable;
	}

	public static IList<Filter> GetAllFilters(Filter filter) {
		List<Filter> filters = new();
		GetFilters(filter, filters);
		return filters;
	}

	private static void GetFilters(Filter filter, IList<Filter> filters) {
		filters.Add(filter);
		if(filter.Filters is not null && filter.Filters.Any())
			foreach(Filter item in filter.Filters)
				GetFilters(item, filters);
	}

	public static string Transform(Filter filter, IList<Filter> filters) {
		Int32 index = filters.IndexOf(filter);
		String comparison = Operators[filter.Operator];
		StringBuilder where = new();

		if(!string.IsNullOrEmpty(filter.Value)) {
			if(filter.Operator == "doesnotcontain")
				where.Append($"(!np({filter.Field}).{comparison}(@{index}))");
			else if(comparison == "StartsWith" ||
					 comparison == "EndsWith" ||
					 comparison == "Contains")
				where.Append($"(np({filter.Field}).{comparison}(@{index}))");
			else
				where.Append($"np({filter.Field}) {comparison} @{index}");
		} else if(filter.Operator == "isnull" || filter.Operator == "isnotnull") {
			where.Append($"np({filter.Field}) {comparison}");
		}

		if(filter.Logic is not null && filter.Filters is not null && filter.Filters.Any())
			return
				$"{where} {filter.Logic} ({String.Join($" {filter.Logic} ", filter.Filters.Select(f => Transform(f, filters)).ToArray())})";

		return where.ToString();
	}
}