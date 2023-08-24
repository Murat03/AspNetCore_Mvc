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
					ImageUrl="/images/1.jpg",
					Price = 17000,
					ShowCase = false
				},
				new Product()
				{
					ProductId = 2,
					CategoryId = 1,
					ProductName = "SmartPhone",
					ImageUrl = "/images/2.jpg",
					Price = 7000,
					ShowCase = false
				},
				new Product()
				{
					ProductId = 3,
					CategoryId = 1,
					ProductName = "Mouse",
					ImageUrl = "/images/3.jpg",
					Price = 500,
					ShowCase = false
				},
				new Product()
				{
					ProductId = 4,
					CategoryId = 2,
					ProductName = "Utopia",
					ImageUrl = "/images/4.jpg",
					Price = 50,
					ShowCase = false
				}
				,
				new Product()
				{
					ProductId = 5,
					CategoryId = 2,
					ProductName = "Sokrates",
					ImageUrl = "/images/5.jpg",
					Price = 30,
					ShowCase = false
				},
				new Product()
				{
					ProductId = 6,
					CategoryId = 1,
					ProductName = "Stream Deck",
					ImageUrl = "/images/6.jpg",
					Price = 15000,
					ShowCase = true
				},
				new Product()
				{
					ProductId = 7,
					CategoryId = 1,
					ProductName = "Console",
					ImageUrl = "/images/7.jpg",
					Price = 15000,
					ShowCase = true
				}
			);
		}
	}
}
