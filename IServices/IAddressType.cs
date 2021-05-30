using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IAddressType 
    {
        public Task<AddressType> CreatAsync(AddressType addressType);
        public Task<bool> DeleteAsync(int id);
        public Task<AddressType> RetriveAsync(int id);
        public Task<AddressType> PatchAsync(AddressType addressType);
    }
}
