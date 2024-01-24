using WPeCommerceAPI.DataLayer;
using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.BusinessLogic.Repositories
{
    public class ReviewRepo : GeneralRepo<Review>, IReviewRepo
    {
        private readonly AppDbContext _db;
        public ReviewRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public ICollection<Review> GetByProductId(int productId)
        {
            var ProductReviews = _db.Set<Review>().Where(r => r.ProductId == productId).ToList();
            return ProductReviews;
        }

        public Review GetById(int id)
        {
            var review = _db.Set<Review>().Where(r => r.Id == id).FirstOrDefault();
            return review;
        }
    }
}
