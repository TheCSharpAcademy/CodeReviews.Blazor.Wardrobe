using Microsoft.EntityFrameworkCore;
using Buutyful.Wardrobe.Models;

namespace Buutyful.Wardrobe.Data
{
    public class BuutyfulWardrobeContext : DbContext
    {
        public BuutyfulWardrobeContext (DbContextOptions<BuutyfulWardrobeContext> options)
            : base(options)
        {
        }

        public DbSet<WardrobeItem> WardrobeItem { get; set; } = default!;
    }
}
