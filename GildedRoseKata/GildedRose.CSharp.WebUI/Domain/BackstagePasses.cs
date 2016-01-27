using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.Domain
{
    public class BackstagePassesDecorator: IUpdateQuality
    {
         private Item _item;

         public BackstagePassesDecorator(Item item)
        {
            _item = item;
        }

        public int UpdateQuality()
        {
            if (_item.SellIn <= 0)
            {
                _item.Quality = 0;
            }
            else
            {
                if (_item.SellIn <= 5)
                {
                    _item.Quality += 3;
                }
                else if (_item.SellIn <= 10)
                {
                    _item.Quality += 2;
                }
            }

            if (_item.Quality > 50)
            {
                _item.Quality = 50;
            }

            return _item.Quality;
        }
    }
}
