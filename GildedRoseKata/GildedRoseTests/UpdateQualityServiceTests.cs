using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.CSharp.WebUI.Views.Home;

namespace UpdateQualityTest
{
    [TestClass]
    public class UpdateQualityServiceTests
    {
        public GildedRoseAdminPanel gildedRoseAdminPanel;

        [TestInitialize]
        public void Initialize()
        {
            gildedRoseAdminPanel = new GildedRoseAdminPanel();
        }


        // Tests en positivo

        [TestMethod]
        public void Given_AnItem_When_UpdateQuality_Then_QualityReduces1()
        {
            // ARRANGEMENT
            Item item = buscarItem("Elixir of the Mongoose");
            item.Quality = 3;
            int expected = item.Quality - 1;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_AnItem_When_SellDatePassed_Then_QualityReduces2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Elixir of the Mongoose");
            item.SellIn = 0;
            item.Quality = 3;
            int expected = item.Quality - 2;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_AnItem_When_QualityReduces_Then_QualityNeverUnder0()
        {
            // ARRANGEMENT
            Item item = buscarItem("Elixir of the Mongoose");
            item.Quality = 0;
            int expected = 0;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_AgedBridItem_When_UpdateQuality_Then_QualityIncreases1()
        {
            // ARRANGEMENT
            Item item = buscarItem("Aged Brie");
            item.Quality = 3;
            int expected = item.Quality + 1;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_AnItem_When_UpdateQuality_Then_QualityNeverAbove50()
        {
            // ARRANGEMENT
            Item item = buscarItem("Aged Brie");
            item.Quality = 50;
            int expected = 50;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_SulfurasItem_When_UpdateQuality_Then_QualityNeverDecreases()
        {
            // ARRANGEMENT
            Item item = buscarItem("Sulfuras, Hand of Ragnaros");
            int expected = item.Quality;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_Between10and6DaysLeft_Then_QualityIncreases2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 7;
            int expected = item.Quality + 2;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_Between5and1DaysLeft_Then_QualityIncreases3()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 3;
            int expected = item.Quality + 3;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_0DaysLeft_Then_QualityEquals0()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 0;
            int expected = 0;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_ConjuredItem_When_UpdateQuality_Then_QualityDecreases2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Conjured Mana Cake");
            int expected = item.Quality - 2;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }


        // Valores extremos

        [TestMethod]
        public void Given_AnItem_When_SellDateUnder0_Then_QualityReduces2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Elixir of the Mongoose");
            item.SellIn = -12;
            int expected = item.Quality - 2;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_SellDateIs10DaysLeft_Then_QualityIncreases2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 10;
            int expected = item.Quality + 2;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_SellDate6DaysLeft_Then_QualityIncreases2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 6;
            int expected = item.Quality + 2;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_SellDate5DaysLeft_Then_QualityIncreases3()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 5;
            int expected = item.Quality + 3;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_SellDate1DayLeft_Then_QualityIncreases3()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 1;
            int expected = item.Quality + 3;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_SellInUnder0_Then_QualityEquals0()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = -5;
            int expected = 0;

            // ACT
            gildedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }


        private Item buscarItem(string nombreItem)
        {
            bool bEncontrado = false;
            int i = 0;
            Item item = new Item();

            while (!bEncontrado && i < gildedRoseAdminPanel.Items.Count)
            {
                if (gildedRoseAdminPanel.Items[i].Name.Equals(nombreItem))
                {
                    item = gildedRoseAdminPanel.Items[i];
                    bEncontrado = true;
                }
                i++;
            }

            return item;
        }
    }

}
