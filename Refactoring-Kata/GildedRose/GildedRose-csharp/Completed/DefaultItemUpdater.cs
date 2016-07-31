namespace GildedRose_csharp.Completed
{
    public class DefaultItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseSellIn();
            if (item.SellIn >= 0) return;
            item.DecreaseQuality();
        }
    }
}