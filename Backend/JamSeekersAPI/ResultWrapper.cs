namespace JamSeekersAPI;

public class ResultWrapper<T>
{
    public bool IsSuccess { get; set; }
    public List<T>? Data { get; set; }
    public List<string>? Errors { get; set; }

    private ResultWrapper(List<T> data)
    {
        IsSuccess = true;
        Data = data;
    }

    private ResultWrapper(List<string> errors)
    {
        IsSuccess = false;
        Errors = errors;
    }

    public string? ToStringErrors()
    {
        return this.Errors?.ToString();
    }


    public static ResultWrapper<T> Fail(List<string> errors)
    {
        return new ResultWrapper<T>(errors);
    }
    public static ResultWrapper<T> Success(List<T> data) => new ResultWrapper<T>(data);
}