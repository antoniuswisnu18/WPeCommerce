using log4net;
using WPeCommerceAPI.BusinessLogic.Repositories;
using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.BusinessLogic.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepo _repo;
        private readonly ILog _logger = LogManager.GetLogger(typeof(ReviewService));
        public ReviewService(IReviewRepo repo)
        {
            _repo = repo;
        }
        public ICollection<Review> GetByProductId(int productId)
        {
            var reviews = _repo.GetByProductId(productId);
            if(reviews == null)
            {
                _logger.Error($"Failed to retrieve Review for Product Id : {productId}");
                return null;
            }
            return reviews;
        }

        public bool Create (Review review)
        {
            if (_repo.Create(review))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Review GetById(int id)
        {
            var review = _repo.GetById(id);
            if(review == null)
            {
                _logger.Error($"review with id : {id} is not exist");
            }
            return review;
        }
    }
}
