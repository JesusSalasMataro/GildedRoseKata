using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.Domain
{
    public class BackstagePasses : Item, IUpdateQuality
    {
        public int UpdateQuality()
        {
            if (SellIn <= 0)
            {
                Quality = 0;
            }
            else
            {
                if (SellIn <= 5)
                {
                    Quality += 3;
                }
                else if (SellIn <= 10)
                {
                    Quality += 2;
                }
            }

            if (Quality > 50)
            {
                Quality = 50;
            }

            return Quality;
        }
    }
}
