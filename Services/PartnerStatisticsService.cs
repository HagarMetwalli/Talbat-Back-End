using System;
using System.Collections.Generic;
using System.Linq;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class PartnerStatisticsService : IPartnerStatistics
    {
        private TalabatContext _db;
        public PartnerStatisticsService(TalabatContext db)
        {
            _db = db;
        }

        //only for one month
        //reports are only per month so if requested for more than a month... only give for the starting date month report
        public List<int> OrdersNumberByPartnerId(int partnerId, DateTime? start, DateTime? end, int? deliveryState)
        {
            List<int> ordersNumberList = new List<int>();
            Partner partner;
            DateTime startDate;
            DateTime endDate;
            int monthDaysCount;

            using (var dbCon = new TalabatContext())
            {
                partner = dbCon.Partners.Find(partnerId);
            }

            if (start == null)
            {
                startDate = new DateTime(DateTime.Now.Year, ((DateTime.Now.Month) - 1), 1, 1, 0, 0);
            }
            else if (((DateTime)start).Year < partner.JoinDate.Year || ((DateTime)start).Month < partner.JoinDate.Month || ((DateTime)start).Day < partner.JoinDate.Day)
            {
                return null;
            }
            else
            {
                startDate = (DateTime)start;
            }

            monthDaysCount = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            if (end == null)
            {
                endDate = new DateTime(startDate.Year, startDate.Month, (startDate.Day + (monthDaysCount - startDate.Day)), 1, 0, 0);
            }
            else if (((DateTime)end).Year > DateTime.Now.Year || ((DateTime)end).Month > DateTime.Now.Month || (((DateTime)end).Day > DateTime.Now.Day && ((DateTime)end).Month == DateTime.Now.Month))
            {
                return null;
            }
            else
            {
                if (((DateTime)end).Day == 1)
                {
                    endDate = startDate.AddDays(29);
                }
                else if (((DateTime)end).Month != startDate.Month)
                {
                    endDate = startDate;
                    endDate = new DateTime(startDate.Year, startDate.Month, (startDate.Day + (monthDaysCount - startDate.Day)), 1, 0, 0);
                }
                else
                {
                    endDate = new DateTime(startDate.Year, startDate.Month, (startDate.Day + (monthDaysCount - startDate.Day)), 1, 0, 0);
                }
            }

            List<Order> PartnerOrdersList = deliveryState switch
            {
                0 => _db.Orders.Where(o => o.StoreId == partner.StoreId && o.IsDelivered == 0 && o.OrderTime.Year == startDate.Year && o.OrderTime.Month == startDate.Month && o.OrderTime.Day >= startDate.Day).ToList(),
                1 => _db.Orders.Where(o => o.StoreId == partner.StoreId && o.IsDelivered == 1 && o.OrderTime.Year == startDate.Year && o.OrderTime.Month == startDate.Month && o.OrderTime.Day >= startDate.Day).ToList(),
                _ => _db.Orders.Where(o => o.StoreId == partner.StoreId && o.OrderTime.Year == startDate.Year && o.OrderTime.Month == startDate.Month && o.OrderTime.Day >= startDate.Day).ToList(),
            };

            var daysIncremental = (int)((endDate.Day - startDate.Day) / 4);

            var ordersList = PartnerOrdersList.Where(o => o.OrderTime.Day <= startDate.AddDays(daysIncremental - 1).Day).ToList();
            ordersNumberList.Add(ordersList.Count());
            ordersList = null;

            ordersList = PartnerOrdersList.Where(o => o.OrderTime.Day <= startDate.AddDays((2 * daysIncremental) - 1).Day && o.OrderTime.Day > startDate.AddDays(daysIncremental - 1).Day).ToList();
            ordersNumberList.Add(ordersList.Count());
            ordersList = null;

            ordersList = PartnerOrdersList.Where(o => o.OrderTime.Day <= startDate.AddDays((3 * daysIncremental) - 1).Day && o.OrderTime.Day > startDate.AddDays((2 * daysIncremental) - 1).Day).ToList();
            ordersNumberList.Add(ordersList.Count());
            ordersList = null;

            ordersList = PartnerOrdersList.Where(o => o.OrderTime.Day <= startDate.AddDays((4 * daysIncremental) - 1).Day && o.OrderTime.Day > startDate.AddDays((3 * daysIncremental) - 1).Day).ToList();
            ordersNumberList.Add(ordersList.Count());

            return ordersNumberList;
        }

        //Reports are generated basically per month but can be changed to be per year
        public List<int> ReviewPointsByPartnerId(int partnerId, bool isPerYear)
        {
            var reportEvals = new List<int>();
            int storeId;
            var listOfOrdersList = new List<List<Order>>();
            Partner partner;

            using (var dbCon = new TalabatContext())
            {
                storeId = dbCon.Partners.FirstOrDefault(x => x.PartnerId == partnerId).StoreId;
                partner = dbCon.Partners.Find(partnerId);
            }

            if (!isPerYear)
            {
                //monthly report
                var pastMonth = DateTime.Now.AddMonths(-1).Month;
                int daysIncrement = (DateTime.DaysInMonth(DateTime.Now.Year, pastMonth)) / 4;
                int start = 1;

                #region initialize ordersLists and reviewsList sum
                for (int i = 1; i < 5; i++)
                {
                    var ordersCollection = _db.Orders.Where(o =>
                           o.StoreId == storeId
                        && o.OrderTime.Year == DateTime.Now.Year
                        && o.OrderTime.Month == pastMonth
                        && o.OrderTime.Day >= start
                        && o.OrderTime.Day < (daysIncrement * i)
                        )
                    .ToList();

                    listOfOrdersList.Add(ordersCollection);
                    start = (daysIncrement * i);

                }

                listOfOrdersList.ForEach(x =>
                {
                    var reviewsSumPerPeriod = (_db.OrderReviews.ToList()).Join(
                    x,
                    ordrReview => ordrReview.OrderId,
                    ordr => ordr.OrderId,
                    (ordRev, ord) => new { ordRev })
                    .ToList()
                    .Sum(x => x.ordRev.OrderPackaging + x.ordRev.QualityOfFood + x.ordRev.ValueForMoney + x.ordRev.DeliveryTime);

                    reportEvals.Add(reviewsSumPerPeriod);

                });
                #endregion
            }
            else
            {
                //yearly report
                if (partner.JoinDate.Year >= DateTime.Now.Year)
                {
                    reportEvals.Add(0);
                    reportEvals.Add(0);
                    reportEvals.Add(0);
                    reportEvals.Add(0);
                    return reportEvals;
                }

                for (int i = 0; i < 13; i += 3)
                {
                    var ordersCollection = _db.Orders.Where(o =>
                               o.StoreId == storeId
                            && o.OrderTime.Year == DateTime.Now.Year - 1
                            && o.OrderTime.Month > i
                            && o.OrderTime.Month <= i + 3
                            )
                            .ToList();
                    listOfOrdersList.Add(ordersCollection);
                }

                listOfOrdersList.ForEach(x =>
                {
                    var reviewsSumPerPeriod = (_db.OrderReviews.ToList()).Join(
                    x,
                    ordrReview => ordrReview.OrderId,
                    ordr => ordr.OrderId,
                    (ordRev, ord) => new { ordRev })
                    .ToList()
                    .Sum(x => x.ordRev.OrderPackaging + x.ordRev.QualityOfFood + x.ordRev.ValueForMoney + x.ordRev.DeliveryTime);

                    reportEvals.Add(reviewsSumPerPeriod);

                });


            }

            return reportEvals;
        }


    }
}

