namespace WorkModel.Application.Services;

public class Result
{
  public bool IsSuccess { get; private set; }
  public List<string> Errors { get; private set; }
  public static Result Success() => new() { IsSuccess = true };
  public static Result Failure(IEnumerable<string> errors) => new()
  {
    IsSuccess = false,
    Errors = errors.ToList()
  };
}