using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.CSharp.WebUI.Views.Home;

namespace UpdateQualityTest
{
    [TestClass]
    public class UpdateQualityServiceTests
    {
        public GildedRoseAdminPanel glidedRoseAdminPanel;

        [TestInitialize]
        public void Initialize()
        {
            glidedRoseAdminPanel = new GildedRoseAdminPanel();
        }


        // Tests en positivo

        [TestMethod]
        public void Given_UnItem_When_UpdateQuality_Then_QualityReduce1()
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

        [TestMethod]
        public void Given_UnItem_When_FechaCaducidadHaPasado_Then_QualityReduce2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Elixir of the Mongoose");
            item.SellIn = 0;
            int expected = item.Quality - 2;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_UnItem_When_QualityReduce_QualityNuncaInferiorA0()
        {
            // ARRANGEMENT
            Item item = buscarItem("Elixir of the Mongoose");
            item.Quality = 0;
            int expected = 0;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_AgedBridItem_When_UpdateQuality_QualityAumenta()
        {
            // ARRANGEMENT
            Item item = buscarItem("Aged Brie");
            int expected = item.Quality + 1;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_UnItem_When_UpdateQuality_QualityNuncaSuperiorA50()
        {
            // ARRANGEMENT
            Item item = buscarItem("Aged Brie");
            item.Quality = 50;
            int expected = 50;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_SulfurasItem_When_UpdateQuality_QualityNuncaReduce()
        {
            // ARRANGEMENT
            Item item = buscarItem("Sulfuras, Hand of Ragnaros");
            int expected = item.Quality;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_QuedanEntre10y6Dias_QualityIncrementa2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 7;
            int expected = item.Quality + 2;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_QuedanEntre5y1Dias_QualityIncrementa3()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 3;
            int expected = item.Quality + 3;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_Quedan0Dias_QualityEs0()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 0;
            int expected = 0;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_ConjuredItem_When_UpdateQuality_QualityReduce2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Conjured Mana Cake");
            int expected = item.Quality - 2;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }


        // Valores extremos

        [TestMethod]
        public void Given_UnItem_When_FechaCaducidadNegativa_Then_QualityReduce2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Elixir of the Mongoose");
            item.SellIn = -12;
            int expected = item.Quality - 2;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_Quedan10Dias_QualityIncrementa2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 10;
            int expected = item.Quality + 2;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_Quedan6Dias_QualityIncrementa2()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 6;
            int expected = item.Quality + 2;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_Quedan5Dias_QualityIncrementa3()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 5;
            int expected = item.Quality + 3;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_Queda1Dia_QualityIncrementa3()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 1;
            int expected = item.Quality + 3;

            // ACT
            glidedRoseAdminPanel.UpdateQuality();
            int actual = item.Quality;

            // ASSERTS
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_BackstagePassesItem_When_SellInNegativo_QualityEs0()
        {
            // ARRANGEMENT
            Item item = buscarItem("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = -5;
            int expected = 0;

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
            Item item = new Item();

            while (!bEncontrado && i < glidedRoseAdminPanel.Items.Count)
            {
                if (glidedRoseAdminPanel.Items[i].Name.Equals(nombreItem))
                {
                    item = glidedRoseAdminPanel.Items[i];
                    bEncontrado = true;
                }
                i++;
            }

            return item;
        }
    }

}
