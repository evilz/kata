namespace GildedRose_csharp.Completed
{
    public class AgedBrieUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.IncreaseQuality();
            item.DecreaseSellIn();
            if (item.SellIn >= 0) return;
            item.IncreaseQuality();
        }
    }
}