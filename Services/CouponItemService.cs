using System.Collections.Generic;
using System.Linq;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class CouponItemService : IGenericComposite<CouponItem>
    {
        private TalabatContext db;

        public CouponItemService(TalabatContext db)
        {
            this.db = db;
        }


        public List<CouponItem> RetriveAll()
        {
            try
            {
                var couponItems = db.CouponItems.ToList();
                if (couponItems.Count == 0)
                {
                    return null;
                }

                return couponItems;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public List<CouponItem> RetriveWithFstKey(int id)
        {
            try
            {
                var relationsFound = db.CouponItems.Where(x => x.CouponId == id)
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

        public List<CouponItem> RetriveWithSndKey(int id)
        {
            try
            {
                var relationsFound = db.CouponItems.Where(x => x.ItemId == id)
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

        public CouponItem Retrive(int id1, int id2)
        {
            try
            {
                var relationsFound = db.CouponItems.FirstOrDefault(x => x.CouponId == id1 && x.ItemId == id2);

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

        public CouponItem Create(CouponItem item)
        {
            try
            {
                var offer = db.Promotions.Find(item.CouponId);
                var menuItem = db.Items.Find(item.ItemId);
                if (offer == null || menuItem == null)
                {
                    return null;
                }

                db.CouponItems.Add(item);

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
                var rel = db.CouponItems.FirstOrDefault(x => x.CouponId == id1 && x.ItemId == id2);

                db.CouponItems.Remove(rel);

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

        public CouponItem Put(CouponItem item)
        {
            try
            {
                var rel = db.CouponItems.FirstOrDefault(x => x.CouponId == item.CouponId && x.ItemId == item.ItemId);

                if (rel == null)
                {
                    return null;
                }

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
