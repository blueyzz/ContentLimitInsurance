namespace ContentLimitInsurance.Core;

public class ContentLimitInsuranceContext : DbContext
{
    public ContentLimitInsuranceContext(DbContextOptions<ContentLimitInsuranceContext> options) : base(options) { }

    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasKey(x => x.ItemID);
        modelBuilder.Entity<Category>().HasKey(x => x.CategoryID);
        
        modelBuilder.Entity<Item>()
            .HasOne(i => i.Category)
            .WithMany(c => c.Items)
            .HasForeignKey(i => i.CategoryID);
    }
}