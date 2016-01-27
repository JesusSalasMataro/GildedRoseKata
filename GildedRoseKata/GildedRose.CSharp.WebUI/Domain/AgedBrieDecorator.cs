using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.Domain
{
    public class AgedBrieDecorator: IUpdateQuality
    {
        private Item _item;

        public AgedBrieDecorator(Item item)
        {
            _item = item;
        }

        public int UpdateQuality()
        {
            if (_item.Quality < 50)
            {
                _item.Quality++;
            }

            return _item.Quality;
        }
    }
}
