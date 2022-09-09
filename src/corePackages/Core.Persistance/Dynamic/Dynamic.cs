namespace Core.Persistence.Dynamic;

public class Dynamic {
    public IEnumerable<Sort>? Sort { get; set; }
    public Filter? Filter { get; set; }

    public Dynamic() { }

    public Dynamic(IEnumerable<Sort>? sort, Filter? filter) : this() {
        Sort = sort;
        Filter = filter;
    }
}