using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
	public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRepository(RepositoryContext context) : base(context)
		{
		}

		public void CreateProduct(Product product) => Create(product);
		public void DeleteProduct(Product product) => Remove(product);
		public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

		public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
		{
			return _context
				.Products
				.FilteredByCategoryId(p.CategoryId)
				.FilteredBySearchTerm(p.SearchTerm)
				.FilteredByPrice(p.MinPrice,p.MaxPrice,p.IsValidPrice);
		}

		public Product? GetOneProduct(int id, bool trackChanges) => FindByCondition(p => p.ProductId.Equals(id), trackChanges);
		public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
		{
			return FindAll(trackChanges)
				.Where(p => p.ShowCase.Equals(true));
		}
		public void UpdateOneProduct(Product product) => Update(product);
	}
}