namespace Core.Application.Pipelines.Authorization;

public interface ISecuredRequest {
	public String[] Roles { get; }
}