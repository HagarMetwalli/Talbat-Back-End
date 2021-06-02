using System.Collections.Generic;
using System.Linq;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class OfferItemService : IGenericComposite<OfferItem>
    {
        private TalabatContext db;

        public OfferItemService(TalabatContext db)
        {
            this.db = db;
        }


        public List<OfferItem> RetriveAll()
        {
            try
            {
                var offerItems = db.OfferItems.ToList();
                if (offerItems.Count == 0)
                {
                    return null;
                }

                return offerItems;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public List<OfferItem> RetriveWithFstKey(int id)
        {
            try
            {
                var relationsFound = db.OfferItems.Where(x => x.OfferId == id)
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

        public List<OfferItem> RetriveWithSndKey(int id)
        {
            try
            {
                var relationsFound = db.OfferItems.Where(x => x.ItemId == id)
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

        public OfferItem Retrive(int id1, int id2)
        {
            try
            {
                var relationsFound = db.OfferItems.FirstOrDefault(x => x.OfferId == id1 && x.ItemId == id2);

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

        public OfferItem Create(OfferItem item)
        {
            try
            {
                var offer = db.Offers.Find(item.OfferId);
                var menuItem = db.Items.Find(item.ItemId);
                if (offer == null || menuItem == null)
                {
                    return null;
                }

                db.OfferItems.Add(item);

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
                var rel = db.OfferItems.FirstOrDefault(x => x.OfferId == id1 && x.ItemId == id2);

                db.OfferItems.Remove(rel);

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

        public OfferItem Put(OfferItem item)
        {
            try
            {
                var rel = db.OfferItems.FirstOrDefault(x => x.OfferId == item.OfferId && x.ItemId == item.ItemId);

                if (rel == null)
                {
                    return null;
                }

                rel.OfferItemQuantity = item.OfferItemQuantity;

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
