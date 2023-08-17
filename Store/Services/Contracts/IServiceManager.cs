using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IServiceManager
	{
        public IProductService ProductService { get; }
        public ICategoryService CategoryService { get; }
    }
}
