public class ResponseBase<T>
{
    public T? Data { get; set; }

    public bool Success { get; set; }

    public string? Code { get; set; }

    public string? Message { get; set; }
}
