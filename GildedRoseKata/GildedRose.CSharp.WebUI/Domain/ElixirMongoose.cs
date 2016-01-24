using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.Domain
{
    public class ElixirMongoose : Item, IUpdateQuality
    {
        public int UpdateQuality()
        {
            if (SellIn > 0)
            {
                Quality--;
            }
            else
            {
                Quality -= 2;
            }

            if (Quality < 0) Quality = 0;

            return Quality;
        }
    }
}