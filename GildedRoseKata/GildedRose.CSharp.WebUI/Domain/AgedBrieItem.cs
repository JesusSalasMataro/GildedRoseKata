using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.Domain
{
    public class AgedBrieItem: Item
    {
        protected override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality++;
            }
        }
    }
}
