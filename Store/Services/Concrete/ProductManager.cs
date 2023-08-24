using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestParameters;
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
		private readonly IMapper _mapper;
		public ProductManager(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public void CreateProduct(ProductDtoForInsertion productDto)
		{
			Product product = _mapper.Map<Product>(productDto);
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

		public void UpdateOneProduct(ProductDtoForUpdate productDto)
		{
			//var entity = _repositoryManager.Product.GetOneProduct(productDto.ProductId, true);
			//entity.ProductName = productDto.ProductName;
			//entity.Price = productDto.Price;
			//entity.CategoryId = productDto.CategoryId;
			var entity = _mapper.Map<Product>(productDto);
			_repositoryManager.Product.UpdateOneProduct(entity);
			_repositoryManager.Save();
		}

		public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
		{
			var product = GetOneProduct(id, trackChanges);
			var productDto = _mapper.Map<ProductDtoForUpdate>(product);
			return productDto;
		}

		public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
		{
			return _repositoryManager.Product.GetShowcaseProducts(trackChanges);
		}

		public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
		{
			return _repositoryManager.Product.GetAllProductsWithDetails(p);
		}
	}
}
