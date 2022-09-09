namespace Core.CrossCuttingConcerns.Logging;

public class LogDetail {
    public String FullName { get; set; }
    public String MethodName { get; set; }
    public String User { get; set; }
    public ICollection<LogParameter> Parameters { get; set; }
}