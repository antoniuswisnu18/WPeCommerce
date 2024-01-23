using WPeCommerceAPI.DataLayer;
using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.BusinessLogic.Repositories
{
    public class ProductRepo : GeneralRepo<Product>, IProductRepo
    {
        public ProductRepo(AppDbContext db) : base(db)
        {
        }
    }
}
