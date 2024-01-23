using log4net;
using log4net.Core;
using WPeCommerceAPI.BusinessLogic.Repositories;
using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repo;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ProductService));
        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }
        public bool Create(Product product)
        {
            if (_repo.Create(product))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetAll()
        {
            var products = _repo.GetAll();
            return products;
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
