using Microsoft.EntityFrameworkCore;
using Wardrobe.BBualdo.Models;

namespace Wardrobe.BBualdo.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Cloth> Clothes { get; set; }
}