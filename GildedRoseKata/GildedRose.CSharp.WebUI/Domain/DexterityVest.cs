using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.Domain
{
    public class DexterityVest : Item, IUpdateQuality
    {
        public int UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }

            return Quality;
        }
    }
}