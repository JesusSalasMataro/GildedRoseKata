﻿using GildedRose.CSharp.WebUI.GildedRose;
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
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                new Item {Name = "Conjured Mana Cake", SellIn = 4, Quality = 8}
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

        public void UpdateQualityOld()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == "Conjured")
                {
                    UpdateQualityConjured(i);

                }
                else if (Items[i].Name == "AgedBrie")
                {
                    
                }
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        private void UpdateQualityConjured(int i)
        {
            if (Items[i].Quality > 0)
            {
                Items[i].Quality -= 2;
            }

            if (Items[i].Quality < 0) Items[i].Quality = 0;
        }
    }
}