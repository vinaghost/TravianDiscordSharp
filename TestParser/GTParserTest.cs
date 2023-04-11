using HtmlAgilityPack;
using MainCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestParser
{
    [TestClass]
    public class GTParserTest
    {
        private static readonly HtmlDocument doc = new();

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            doc.Load(Path.Combine("HtmlFiles", "GetterTools.html"));
        }

        [TestMethod]
        public void GetWorldRegionsTest()
        {
            var nodes = GetterToolsParser.GetWorldRegions(doc);
            Assert.AreEqual(14, nodes.Count);
        }

        [DataTestMethod]
        [DataRow(0, "International")]
        [DataRow(13, "Turkey")]
        public void GetWorldRegionTest(int location, string expected)
        {
            var nodes = GetterToolsParser.GetWorldRegions(doc);
            var actual = GetterToolsParser.GetWorldRegion(nodes[location]);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(13)]
        public void GetWorldsTest(int location)
        {
            var worldRegions = GetterToolsParser.GetWorldRegions(doc);
            var worlds = GetterToolsParser.GetWorlds(worldRegions[location]);
            Assert.AreNotEqual(0, worlds.Count);
        }

        [DataTestMethod]
        [DataRow(0, 0, "com1.kingdoms.com")]
        [DataRow(13, 0, "alpler.x3.turkey.travian.com")]
        public void GetWorldUrlTest(int locRegion, int locWorld, string expected)
        {
            var worldRegions = GetterToolsParser.GetWorldRegions(doc);
            var worlds = GetterToolsParser.GetWorlds(worldRegions[locRegion]);
            var actual = GetterToolsParser.GetWorldUrl(worlds[locWorld]);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 0, 13, 12, 2022)]
        [DataRow(13, 0, 1, 3, 2023)]
        public void GetWorldStartDateTest(int locRegion, int locWorld, int day, int month, int year)
        {
            var worldRegions = GetterToolsParser.GetWorldRegions(doc);
            var worlds = GetterToolsParser.GetWorlds(worldRegions[locRegion]);
            var actual = GetterToolsParser.GetWorldStartDate(worlds[locWorld]);
            Assert.AreEqual(new DateTime(year, month, day), actual);
        }
    }
}