using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog;

public abstract class LoggerServiceBase {
	protected ILogger Logger { get; set; }

	public void Verbose(String message) {
		Logger.Verbose(message);
	}

	public void Fatal(String message) {
		Logger.Fatal(message);
	}

	public void Info(String message) {
		Logger.Information(message);
	}

	public void Warn(String message) {
		Logger.Warning(message);
	}

	public void Debug(String message) {
		Logger.Debug(message);
	}

	public void Error(String message) {
		Logger.Error(message);
	}
}