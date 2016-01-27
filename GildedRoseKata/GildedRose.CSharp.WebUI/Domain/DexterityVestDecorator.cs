using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.Domain
{
    public class DexterityVestDecorator : IUpdateQuality
    {
        private Item _item;

        public DexterityVestDecorator(Item item) {
            _item = item;
        }

        public int UpdateQuality()
        {
            if (_item.SellIn > 0)
            {
                _item.Quality--;
            }
            else
            {
                _item.Quality -= 2;
            }

            if (_item.Quality < 0) _item.Quality = 0;

            return _item.Quality;
        }
    }
}