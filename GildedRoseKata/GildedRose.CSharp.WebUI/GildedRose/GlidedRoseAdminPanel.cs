using GildedRose.CSharp.WebUI.GildedRose;
using GildedRose.CSharp.WebUI.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GildedRose.CSharp.WebUI.Views.Home
{
    public class GildedRoseAdminPanel
    {
        public List<Item> Items;

        public GildedRoseAdminPanel()
        {
            Items = new List<Item>()
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                IUpdateQuality updateQuality = ItemFactory.GetItemInstance(Items[i]);

                if (updateQuality != null)
                {
                    Items[i].Quality = updateQuality.UpdateQuality();
                }

                Items[i].SellIn -= 1;
            }
        }
    }
}