using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IClientAddressesRelated: IGeneric<ClientAddress>
    {
        List<ClientAddress> RetriveByClientIdAsync(int id);

    }
}
