using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IOfferService : IGenericService<Offer>
    {
        public Task<IEnumerable<Store>> GetAllStoreThatHaveCopon();

        public Task<IEnumerable<Offer>> GetAllCoponsForSpecificStore(int storeid);

        public Task<IEnumerable<Store>> GetAllStoreThatHavePromotion();

        public Task<IEnumerable<Offer>> GetAllPromotionForSpecificStore(int storeid);




    }
}
