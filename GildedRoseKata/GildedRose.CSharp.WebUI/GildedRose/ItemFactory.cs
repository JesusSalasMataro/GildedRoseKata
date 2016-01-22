using GildedRose.CSharp.WebUI.Domain;
using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.GildedRose
{
    public static class ItemFactory
    {
        public static IUpdateQuality GetItemInstance(Item item)
        {
            IUpdateQuality updateQuality = null;

            if (item.Name.Equals("Aged Brie"))
            {
                updateQuality = new AgedBrie
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                };
            }

            else if (item.Name.Equals("Elixir of the Mongoose"))
            {
                updateQuality = new ElixirMongoose
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                };
            }

            else if (item.Name.Equals("+5 Dexterity Vest"))
            {
                updateQuality = new DexterityVest
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                };
            }

            else if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                updateQuality = new BackstagePasses
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                };
            }

            else if (item.Name.Equals("Conjured Mana Cake"))
            {
                updateQuality = new Conjured
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                };
            }

            return updateQuality;
        }
    }
}
