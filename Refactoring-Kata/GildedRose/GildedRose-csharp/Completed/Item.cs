namespace GildedRose_csharp.Completed
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public void DecreaseQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }

        public void IncreaseQuality()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }
        }

        public void DecreaseSellIn()
        {
            SellIn--;
        }
    }
}