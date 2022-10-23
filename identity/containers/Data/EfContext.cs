using Microsoft.EntityFrameworkCore;
using NetDevPack.Identity.Data;

namespace Easyfood.Identity.Data;

public class EfContext : NetDevPackAppDbContext
{
    public EfContext(DbContextOptions<NetDevPackAppDbContext> options) : base(options)
    {
    }
}