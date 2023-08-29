using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Config;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Repositories;
public class RepositoryContext : IdentityDbContext<IdentityUser>
{
	public DbSet<Product> Products { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Order> Orders { get; set; }
	public RepositoryContext(DbContextOptions<RepositoryContext> options)
		: base(options){}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		//builder.ApplyConfiguration(new ProductConfig());
		//builder.ApplyConfiguration(new CategoryConfig());
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
