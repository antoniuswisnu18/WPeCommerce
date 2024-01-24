using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.BusinessLogic.Repositories
{
    public interface IReviewRepo : IGeneralRepo<Review>
    {
        ICollection<Review> GetByProductId(int productId);
        Review GetById(int id);
    }
}
