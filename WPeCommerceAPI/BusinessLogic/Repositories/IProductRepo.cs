using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.BusinessLogic.Repositories
{
    public interface IProductRepo : IGeneralRepo<Product>
    {
        Product GetById(int id);
    }
}
