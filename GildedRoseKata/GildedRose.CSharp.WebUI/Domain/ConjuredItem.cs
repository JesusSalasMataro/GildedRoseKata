﻿using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.Domain
{
    public class ConjuredItem : Item
    {
        protected override void UpdateQuality()
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
    }
}