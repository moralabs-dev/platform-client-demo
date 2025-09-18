public class ResponseListBase<T> : PagingResponse
{
    public List<T>? Data { get; set; }

    public bool Success { get; set; }

    public string? Code { get; set; }

    public string? Message { get; set; }
}

public class PagingResponse
{
    public int? PageIndex { get; set; }

    public int? PageSize { get; set; }

    public int? PageCount { get; set; }
}
