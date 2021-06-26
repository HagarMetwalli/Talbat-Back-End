using System;
using System.Collections.Generic;

namespace Talbat.IServices
{
    public interface IPartnerStatistics
    {
        public List<int> OrdersNumberByPartnerId(int partnerId, DateTime? start, DateTime? end, int? deliveryState);
    }
}
