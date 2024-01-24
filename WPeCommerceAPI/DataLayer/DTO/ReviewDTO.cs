using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.DataLayer.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ReviewerName { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
