using GildedRose.CSharp.WebUI.Domain;
using GildedRose.CSharp.WebUI.IServices;
using GildedRose.CSharp.WebUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.CSharp.WebUI.GildedRose
{
    public static class ItemFactory
    {
        public static IUpdateQuality GetItemInstance(Item item)
        {
            IUpdateQuality updateQuality = null;

            if (item.Name.Equals("Aged Brie"))
            {
                updateQuality = new AgedBrieDecorator(item);
            }

            else if (item.Name.Equals("Elixir of the Mongoose"))
            {
                updateQuality = new ElixirMongooseDecorator(item);
            }

            else if (item.Name.Equals("+5 Dexterity Vest"))
            {
                updateQuality = new DexterityVestDecorator(item);
            }

            else if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                updateQuality = new BackstagePassesDecorator(item);
            }

            else if (item.Name.Equals("Conjured Mana Cake"))
            {
                updateQuality = new ConjuredDecorator(item);
            }

            return updateQuality;
        }
    }
}
