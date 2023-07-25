using CSV_Import.Context;
using CSV_Import.Models;
using Microsoft.EntityFrameworkCore;

namespace CSV_Import.Repositories;

public class UserRepository:GenericRepository<User>, IUserRepository
{
    private readonly IDataContext _dataContext;

    public UserRepository(IDataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<User>> ReadPaginated(int limit, int offset, bool asc)
    {
        return asc
            ? await _dataContext.Users
                .AsNoTracking()
                .OrderBy(u => u.UserName)
                .Skip(offset)
                .Take(limit)
                .ToListAsync()
            : await _dataContext.Users
                .AsNoTracking()
                .OrderByDescending(u => u.UserName)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
    }
}