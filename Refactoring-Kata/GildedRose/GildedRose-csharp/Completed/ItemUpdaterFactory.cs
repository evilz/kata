using System.Collections.Generic;

namespace GildedRose_csharp.Completed
{
    public static class ItemUpdaterFactory
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGE_PASSES_TO_A_TAFKAL80_ETC_CONCERT = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS_HAND_OF_RAGNAROS = "Sulfuras, Hand of Ragnaros";

        private static readonly IDictionary<string,IItemUpdater> Updaters = new Dictionary<string, IItemUpdater>
        {
            {AGED_BRIE, new AgedBrieUpdater() },
            {BACKSTAGE_PASSES_TO_A_TAFKAL80_ETC_CONCERT, new BackstagePassesUpdater() },
            {SULFURAS_HAND_OF_RAGNAROS, new SulfurasUpdater() },
        };

        private static readonly DefaultItemUpdater DefaultItemUpdater = new DefaultItemUpdater();

        public static IItemUpdater GetItemUpdater(Item item)
        {
            return Updaters.ContainsKey(item.Name) 
                ? Updaters[item.Name] 
                : DefaultItemUpdater;
        }
    }
}