using WPeCommerceAPI.BusinessLogic.Repositories;
using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.BusinessLogic.Services
{
    public interface IProductService
    {
        ICollection<Product> GetAll();
        bool Create(Product product);
        bool Update(Product product);
        bool Delete(Product product);
    }
}
