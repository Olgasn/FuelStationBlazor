using FuelStationBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FuelStationBlazor.Server.Data
{
    public class FuelsContext(DbContextOptions<FuelsContext> options) : DbContext(options)
    {
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Tank> Tanks { get; set; }
    }
}
