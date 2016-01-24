using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.CSharp.WebUI.Views.Home;

namespace UpdateQualityTest
{
    [TestClass]
    public class UpdateQualityServiceTests
    {
        private GildedRoseAdminPanel glidedRoseAdminPanel;

        [TestInitialize]
        public void Initialize()
        {
            glidedRoseAdminPanel = new GildedRoseAdminPanel();
        }

        [TestMethod]
        public void Given_AnItem_When_UpdateQuality_Then_QualityReduces1()
        {
            // ARRANGEMENT
            Item item = buscarItem("Elixir of the Mongoose");
            int expected = item.Quality - 1;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }


        private Item buscarItem(string nombreItem)
        {
            bool bEncontrado = false;
            int i = 0;
            Item item = new Item(); ;

            while (!bEncontrado && i < glidedRoseAdminPanel.Items.Count)
            {
                if (glidedRoseAdminPanel.Items[i].Name.Equals(nombreItem))
                {
                    item = glidedRoseAdminPanel.Items[i];
                    bEncontrado = true;
                }
            }

            return item;
        }
    }

}
