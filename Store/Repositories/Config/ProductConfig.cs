using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.ProductId);
			builder.Property(p=>p.ProductName).IsRequired();
			builder.Property(p=>p.Price).IsRequired();

			builder.HasData(
				new Product()
				{
					ProductId = 1,
					CategoryId = 1,
					ProductName = "Computer",
					Price = 17000
				},
				new Product()
				{
					ProductId = 2,
					CategoryId = 1,
					ProductName = "SmartPhone",
					Price = 7000
				},
				new Product()
				{
					ProductId = 3,
					CategoryId = 1,
					ProductName = "Mouse",
					Price = 500
				},
				new Product()
				{
					ProductId = 4,
					CategoryId = 2,
					ProductName = "Utopia",
					Price = 50
				}
				,
				new Product()
				{
					ProductId = 5,
					CategoryId = 2,
					ProductName = "Sokrates",
					Price = 30
				}
			);
		}
	}
}
