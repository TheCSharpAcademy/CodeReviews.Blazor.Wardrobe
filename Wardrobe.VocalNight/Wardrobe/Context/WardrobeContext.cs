using Microsoft.EntityFrameworkCore;
using System;
using Wardrobe.Model;

namespace Wardrobe.Context
{
    public class WardrobeContext : DbContext
    {
        public WardrobeContext( DbContextOptions<WardrobeContext> options ) : base(options) { }
        public DbSet<WardrobeViewModel> Clothes { get; set; }
    }
}
