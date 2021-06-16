using System.Collections.Generic;
using System.Linq;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class PromotionItemService : IGenericComposite<PromotionItem>
    {
        private TalabatContext db;

        public PromotionItemService(TalabatContext db)
        {
            this.db = db;
        }


        public List<PromotionItem> RetriveAll()
        {
            try
            {
                var promotionItems = db.PromotionItems.ToList();
                if (promotionItems.Count == 0)
                {
                    return null;
                }

                return promotionItems;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public List<PromotionItem> RetriveWithFstKey(int id)
        {
            try
            {
                var relationsFound = db.PromotionItems.Where(x => x.PromotionId == id)
                    .ToList();

                if (relationsFound.Count == 0)
                {
                    return null;
                }

                return relationsFound;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public List<PromotionItem> RetriveWithSndKey(int id)
        {
            try
            {
                var relationsFound = db.PromotionItems.Where(x => x.ItemId == id)
                    .ToList();

                if (relationsFound.Count == 0)
                {
                    return null;
                }

                return relationsFound;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public PromotionItem Retrive(int id1, int id2)
        {
            try
            {
                var relationsFound = db.PromotionItems.FirstOrDefault(x => x.PromotionId == id1 && x.ItemId == id2);

                if (relationsFound == null)
                {
                    return null;
                }

                return relationsFound;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public PromotionItem Create(PromotionItem item)
        {
            try
            {
                var offer = db.Promotions.Find(item.PromotionId);
                var menuItem = db.Items.Find(item.ItemId);
                if (offer == null || menuItem == null)
                {
                    return null;
                }

                db.PromotionItems.Add(item);

                var affected = db.SaveChanges();
                if (affected == 0)
                {
                    return null;
                }

                return item;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public bool Delete(int id1, int id2)
        {
            try
            {
                var rel = db.PromotionItems.FirstOrDefault(x => x.PromotionId == id1 && x.ItemId == id2);

                db.PromotionItems.Remove(rel);

                int affected = db.SaveChanges();
                if (affected == 0)
                {
                    return false;
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public PromotionItem Put(PromotionItem item)
        {
            try
            {
                var rel = db.PromotionItems.FirstOrDefault(x => x.PromotionId == item.PromotionId && x.ItemId == item.ItemId);

                if (rel == null)
                {
                    return null;
                }

                rel.PromotionItemQuantity = item.PromotionItemQuantity;

                var affected = db.SaveChanges();
                if (affected == 0)
                {
                    return null;
                }

                return item;
            }
            catch (System.Exception)
            {
                return null;
            }
        }


    }
}
