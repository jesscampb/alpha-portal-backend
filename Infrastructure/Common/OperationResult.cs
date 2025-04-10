namespace Infrastructure.Common;

public class OperationResult
{
    public bool Succeeded { get; set; }
    public int? StatusCode { get; set; }
    public string? ErrorMessage { get; set; }
}

public class OperationResult<T> : OperationResult
{
    public T? Result { get; set; }
}