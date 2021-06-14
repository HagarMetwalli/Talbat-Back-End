using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IPromotionRelatedService : IGeneric<Promotion>
    {
        public Store RetrieveOfferStoreAsync(int Id);
        public List<Store> RetriveAllSotresHavePromotions();
        public List<PromotionItem> RetriveAllSotrePromotionItems(int storeId);

    }

}
