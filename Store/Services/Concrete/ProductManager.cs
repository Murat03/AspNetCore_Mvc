using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
	public class ProductManager : IProductService
	{
		public IRepositoryManager _repositoryManager;

		public ProductManager(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
		}

		public void CreateProduct(Product product)
		{
			_repositoryManager.Product.CreateProduct(product);
			_repositoryManager.Save();
		}

		public void DeleteOneProduct(int id)
		{
			Product product = GetOneProduct(id, false);
			_repositoryManager.Product.DeleteProduct(product);
			_repositoryManager.Save();
		}

		public IEnumerable<Product> GetAllProducts(bool trackChanges)
		{
			return _repositoryManager.Product.GetAllProducts(trackChanges);
		}

		public Product GetOneProduct(int id, bool trackChanges)
		{
			var product = _repositoryManager.Product.GetOneProduct(id, trackChanges);
			if (product == null)
			{
				throw new Exception("Product not found!");
			}
			return product;
		}

		public void UpdateOneProduct(Product product)
		{
			var entity = _repositoryManager.Product.GetOneProduct(product.ProductId, true);
			entity.ProductName = product.ProductName;
			entity.Price = product.Price;
			_repositoryManager.Save();
		}
	}
}
