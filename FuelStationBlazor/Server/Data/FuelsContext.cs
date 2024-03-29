﻿using FuelStationBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FuelStationBlazor.Server.Data
{
    public class FuelsContext : DbContext
    {
        public FuelsContext(DbContextOptions<FuelsContext> options) : base(options)
        {
        }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Tank> Tanks { get; set; }
    }
}
