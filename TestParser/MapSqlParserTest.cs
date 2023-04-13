using MainCore.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestParser
{
    [TestClass]
    public class MapSqlParserTest
    {
        private static string[] mapSqlContent;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            mapSqlContent = File.ReadAllLines(Path.Combine("Files", "map.sql"));
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(10)]
        [DataRow(20)]
        [DataRow(30)]
        [DataRow(40)]
        [DataRow(50)]
        public void GetVillageTest(int location)
        {
            var village = MapSqlParser.GetVillage(mapSqlContent[location]);

            Assert.IsFalse(village.MapId == default);
            Assert.IsFalse(village.X == default);
            Assert.IsFalse(village.Y == default);
            Assert.IsFalse(village.Tribe == default);
            Assert.IsFalse(village.Id == default);
            Assert.IsFalse(village.Name == default);
            Assert.IsFalse(village.PlayerId == default);
            Assert.IsFalse(village.PlayerName == default);
            Assert.IsFalse(village.AllyId == default);
            Assert.IsFalse(village.AllyName == default);
        }
    }
}