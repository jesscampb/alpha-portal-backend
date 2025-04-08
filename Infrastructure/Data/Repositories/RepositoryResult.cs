namespace Infrastructure.Data.Repositories;

public class RepositoryResult
{
    public bool Success { get; set; }
    public int? StatusCode { get; set; }
    public string? ErrorMessage { get; set; }
}

public class RepositoryResult<T> : RepositoryResult
{
    public T? Result { get; set; }
}