namespace Core.Persistence.Dynamic;

public class Filter {
	public String Field { get; set; }
	public String Operator { get; set; }
	public String? Value { get; set; }
	public String? Logic { get; set; }
	public IEnumerable<Filter>? Filters { get; set; }

	public Filter() { }

	public Filter(String field, String @operator, String? value, String? logic, IEnumerable<Filter>? filters) : this() {
		Field = field;
		Operator = @operator;
		Value = value;
		Logic = logic;
		Filters = filters;
	}
}