using Microsoft.AspNetCore.Mvc;
using System;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerStatisticsController : ControllerBase
    {
        private IPartnerStatistics _repo;
        private IUserService<Partner> _repoPartner;

        public PartnerStatisticsController(IPartnerStatistics repo, IUserService<Partner> repoPartner)
        {
            _repo = repo;
            _repoPartner = repoPartner;
        }


        // GET api/PartnerStatistics/PartnerStoreOrdersStatistic/2
        /*deliveryState:
          1=> Delivered, 
          0=> not delivered,
          Null=> General orders without regarding delivery state!
         */
        [HttpGet]
        [Route("PartnerStoreOrdersStatistic/{partnerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public ActionResult PartnerStoreOrdersStatistic(int partnerId, DateTime? start, DateTime? end, int? deliveryState, bool customStatistics = true)
        {
            //Per month or specific time
            if (partnerId <= 0 || deliveryState > 1 || (_repoPartner.RetriveAsync(partnerId) == null))
                return BadRequest();

            if (!customStatistics)
            {
                var ordersStatistics = _repo.defaultStatistics(partnerId);
                if (ordersStatistics == null)
                    return BadRequest("Invalid Date!");
                return Ok(ordersStatistics);
            }
            else
            {
                var ordersStatistics = _repo.OrdersNumberByPartnerId(partnerId, start, end, deliveryState);
                if (ordersStatistics == null)
                    return BadRequest("Invalid Date!");
                return Ok(ordersStatistics);
            }
        }

        [HttpGet]
        [Route("PartnerStoreReviewsStatistic/{partnerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public ActionResult PartnerStoreReviewsStatistic(int partnerId, bool isPerYear = false)
        {
            //Per month by default and per year is true
            if (partnerId <= 0 || (_repoPartner.RetriveAsync(partnerId) == null))
            {
                return BadRequest();
            }

            var reviewsStatistics = _repo.ReviewPointsByPartnerId(partnerId, isPerYear);
            if (reviewsStatistics == null)
            {
                return NotFound();
            }

            return Ok(reviewsStatistics);
        }


    }
}
