using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Core.Data;

public class HrDbContext : DbContext
{
    public HrDbContext(DbContextOptions<HrDbContext> options) : base(options)
    {
        
    }
}