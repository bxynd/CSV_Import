using CSV_Import.Models;

namespace CSV_Import.Services;

public interface IUserService
{
    Task<int> AddUsers(IFormFile file);
    Task<List<User>> GetUsers(int limit, int offset,bool asc);
}