namespace Core.Persistence.Dynamic;

public class Sort {
	public String Field { get; set; }
	public String Dir { get; set; }

	public Sort() { }

	public Sort(String field, String dir) : this() {
		Field = field;
		Dir = dir;
	}
}