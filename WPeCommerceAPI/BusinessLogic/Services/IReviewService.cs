using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.BusinessLogic.Services
{
    public interface IReviewService
    {
        ICollection<Review> GetByProductId(int productId);
        bool Create(Review review);

        Review GetById(int id);

    }
}
