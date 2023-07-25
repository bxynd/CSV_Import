namespace CSV_Import.Repositories;

public interface IGenericRepository<T>
{
    public Task<int> Create(List<T> users);
}