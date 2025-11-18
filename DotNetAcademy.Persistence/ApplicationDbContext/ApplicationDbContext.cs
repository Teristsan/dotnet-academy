using DotNetAcademy.Persistence.Constants;
using DotNetAcademy.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
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
			item.Property(i => i.MediaType).IsRequired().HasMaxLength(40);
			item.Property(i => i.Title).IsRequired().HasMaxLength(200);
			item.Property(i => i.Description).IsRequired().HasMaxLength(255);
			item.Property(i => i.Poster).IsRequired().HasColumnType("varbinary(max)");
			item.Property(i => i.Rating).HasDefaultValue(0);

			item.HasMany(i => i.Images)
				.WithOne(img => img.Item)
				.HasForeignKey(img => img.ItemId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);
		});

		// Seed roles with required static properties
		var adminRoleId = "1";
		var userRoleId = "2";

		builder.Entity<IdentityRole>().HasData(
			new IdentityRole
			{
				Id = adminRoleId,
				Name = RoleNames.Admin,
				NormalizedName = RoleNames.Admin.ToUpper(),
				ConcurrencyStamp = "admin-role-stamp-static"
			},
			new IdentityRole
			{
				Id = userRoleId,
				Name = RoleNames.User,
				NormalizedName = RoleNames.User.ToUpper(),
				ConcurrencyStamp = "user-role-stamp-static"
			}
		);

		// Seed users with required static properties
		var adminUserId = "admin-user-id";
		var regularUserId = "regular-user-id";

		builder.Entity<ApplicationUser>().HasData(
			new ApplicationUser
			{
				Id = adminUserId,
				FirstName = "Quentin",
				LastName = "Tarantino",
				Description = "Administrator of the application",
                UserName = "admin@dotnetacademy.com",
				NormalizedUserName = "ADMIN@DOTNETACADEMY.COM",
				Email = "admin@dotnetacademy.com",
				NormalizedEmail = "ADMIN@DOTNETACADEMY.COM",
				EmailConfirmed = true,
				PasswordHash = "AQAAAAIAAYagAAAAEOgHHAPxCzc9Q3h54P4MfcJFcbnKjXN52yKG/aI31U6jfRYWLVWpGSVo0+nPBwpMVg==",
				SecurityStamp = "admin-security-stamp-static",
				ConcurrencyStamp = "admin-concurrency-stamp-static",
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnabled = false,
				AccessFailedCount = 0
			},
			new ApplicationUser
			{
				Id = regularUserId,
				FirstName = "Roy",
				LastName = "Batty",
				Description = "Tears in rain",
                UserName = "user@dotnetacademy.com",
				NormalizedUserName = "USER@DOTNETACADEMY.COM",
				Email = "user@dotnetacademy.com",
				NormalizedEmail = "USER@DOTNETACADEMY.COM",
				EmailConfirmed = true,
				PasswordHash = "AQAAAAIAAYagAAAAELnjWmX8OcR7M4S5V4j7lXvNbCvOuCGiB9Km4TtBd6Zy5AcVzjlc9ByWz9ynXxUL2w==",
				SecurityStamp = "user-security-stamp-static",
				ConcurrencyStamp = "user-concurrency-stamp-static",
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnabled = false,
				AccessFailedCount = 0
			}
		);

		// Seed user roles
		builder.Entity<IdentityUserRole<string>>().HasData(
			new IdentityUserRole<string>
			{
				RoleId = adminRoleId,
				UserId = adminUserId
			},
			new IdentityUserRole<string>
			{
				RoleId = userRoleId,
				UserId = regularUserId
			}
		);
	}
}