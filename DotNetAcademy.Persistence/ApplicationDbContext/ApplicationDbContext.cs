using DotNetAcademy.Persistence.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetAcademy.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<Item> Items { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<Item>(item =>
		{
			item.HasKey(i => i.Id);
			item.Property(i => i.Name).IsRequired().HasMaxLength(100);
			item.Property(i => i.Description).IsRequired().HasMaxLength(255);
		});
	}
}