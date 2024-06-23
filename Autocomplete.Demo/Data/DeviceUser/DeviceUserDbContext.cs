using Microsoft.EntityFrameworkCore;

namespace Autocomplete.Demo.Data.DeviceUser;

public class DeviceUserDbContext(DbContextOptions<DeviceUserDbContext> options) : DbContext(options)
{
    public DbSet<DeviceUserModel> DeviceUsers { get; init; }
}