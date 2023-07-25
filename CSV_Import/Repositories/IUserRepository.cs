using CSV_Import.Models;

namespace CSV_Import.Repositories;

public interface IUserRepository
{
    Task<List<User>> ReadPaginated(int limit, int offset, bool asc);
    Task<int> Create(List<User> entity);
}