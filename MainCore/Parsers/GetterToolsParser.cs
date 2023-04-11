using HtmlAgilityPack;

namespace MainCore.Parsers
{
    public static class GetterToolsParser
    {
        public static List<HtmlNode> GetWorldRegions(HtmlDocument doc)
        {
            var worldTable = doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.HasClass("worldTable2"));
            return worldTable.Descendants("div").Where(x => x.HasClass("block")).Skip(1).SkipLast(1).ToList();
        }

        public static string GetWorldRegion(HtmlNode node)
        {
            return node.Descendants("span").FirstOrDefault(x => x.HasClass("collname")).InnerText;
        }

        public static List<HtmlNode> GetWorlds(HtmlNode node)
        {
            return node.Descendants("a").Where(x => x.HasClass("world")).ToList();
        }

        public static string GetWorldUrl(HtmlNode node)
        {
            return new string(node.Descendants("span").LastOrDefault().InnerText.Skip(1).SkipLast(1).ToArray());
        }

        public static DateTime GetWorldStartDate(HtmlNode node)
        {
            return node.GetAttributeValue("data-start", DateTime.MinValue);
        }
    }
}