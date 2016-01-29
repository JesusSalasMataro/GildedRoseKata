using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GildedRose.CSharp.WebUI.Views.Home
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public void UpdateItem() 
        { 
            UpdateQuality();
            UpdateSellIn();
        }

        protected virtual void UpdateQuality() 
        {
            if (SellIn <= 0)
            {
                if (Quality > 1)
                {
                    Quality -= 2;
                }
                else
                {
                    Quality = 0;
                }
            }
            else
            {
                if (Quality > 0)
                {
                    Quality -= 1;
                }
            }
        }

        protected void UpdateSellIn()
        {
            SellIn -= 1;
        }

        public override String ToString()
        {
            return Name + "#" + SellIn + "#" + Quality;
        }
    }
}