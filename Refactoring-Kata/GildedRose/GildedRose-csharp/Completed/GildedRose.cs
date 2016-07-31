using System;
using System.Collections.Generic;

namespace GildedRose_csharp.Completed
{
    class GildedRose
    {
        readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items ?? new List<Item>();
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                ItemUpdaterFactory.GetItemUpdater(item).Update(item);
            }
        }
    }
}
