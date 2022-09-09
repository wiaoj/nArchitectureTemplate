namespace Core.Application.Requests;

public record PageRequest {
    public Int32 Page { get; set; } = 0;
    public Int32 PageSize { get; set; } = 5;
}