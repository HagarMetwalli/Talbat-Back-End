﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IItemService : IGeneric<Item>
    {
        public Task<List<SubItem>> RetriveSubItemsByItemIdAsync(int itemId);

        public Task<List<SubItemCategory>> RetriveSubItemsCategoriesByItemIdAsync(int itemId);
    }
}