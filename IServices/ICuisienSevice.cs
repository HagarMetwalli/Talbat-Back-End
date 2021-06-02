using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{

    public interface ICuisienSevice : IGeneric<Cuisine>
    {
        public Task<List<string>> RetriveMostCommonAsync();
        public Task<Cuisine> RetriveByNameAsync(string name);

    }
}
