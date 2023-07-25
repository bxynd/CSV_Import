using CSV_Import.Models;
using Microsoft.EntityFrameworkCore;

namespace CSV_Import.Context;

public interface IDataContext
{
    DbSet<User> Users { get; set; }
    Task<int> ContextSaveChanges();
    DbSet<T> Set<T>() where T : class;
}