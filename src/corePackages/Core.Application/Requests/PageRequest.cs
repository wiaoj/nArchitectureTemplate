namespace Core.Application.Requests;

public class PageRequest {
	public Int32 Page { get; set; }
	public Byte PageSize { get; set; }

	public PageRequest() {
		Page = 0;
		PageSize = 5;
	}
}