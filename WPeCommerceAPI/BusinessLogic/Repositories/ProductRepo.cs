using WPeCommerceAPI.DataLayer;
using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.BusinessLogic.Repositories
{
    public class ProductRepo : GeneralRepo<Product>, IProductRepo
    {
        private readonly AppDbContext _db;
        public ProductRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public Product GetById(int id)
        {
            var product = _db.Set<Product>().Find(id);
            return product;
        }
    }
}
