using System.Collections.Generic;

namespace Talbat.Models
{
    public class StoreReviews_StatisticModel
    {
        public OrderReview orderReview { get; set; }
        public List<ItemReview> itemsReview { get; set; }

        public StoreReviews_StatisticModel()
        {
            this.orderReview = new OrderReview();
            this.itemsReview = new List<ItemReview>();
        }

        public StoreReviews_StatisticModel(OrderReview orderReview, List<ItemReview> itemsReview)
        {
            this.orderReview = orderReview;
            this.itemsReview = itemsReview;
        }
    }
}
