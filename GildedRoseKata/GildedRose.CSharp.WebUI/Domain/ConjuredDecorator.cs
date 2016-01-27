using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.Domain
{
    public class ConjuredDecorator : IUpdateQuality
    {
        private Item _item;

        public ConjuredDecorator(Item item)
        {
            _item = item;
        }

        public int UpdateQuality()
        {
            if (_item.Quality > 0)
            {
                _item.Quality -= 2;
            }

            if (_item.Quality < 0) _item.Quality = 0;

            return _item.Quality;
        }
    }
}