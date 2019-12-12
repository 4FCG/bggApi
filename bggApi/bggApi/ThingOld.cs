using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net.Http;
using System.Xml;
using System.Threading.Tasks;

namespace BoardGameGeekApi
{
    partial class ThingOld
    {
        /// <summary>
        /// Create a new Thing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<ThingOld> CreateThing(int id)
        {
            ThingOld newThing = new ThingOld(id);
            await newThing.Initialize();
            return newThing;
        }

        private ThingOld(int id)
        {
            this.Id = id;
        }

        private async Task Initialize()
        {
            XmlDocument thingData = new XmlDocument();

            using (HttpClient client = new HttpClient())
            {
                thingData.LoadXml(await client.GetStringAsync("https://www.boardgamegeek.com/xmlapi2/thing?id=1"));
            }

            XmlNode node = thingData.SelectSingleNode("items/item");

            this.Name = node.SelectSingleNode("name[@type=\"primary\"]/@value").Value;
            this.Description = node["description"].InnerText;
            this.Type = node.Attributes["type"].Value;
            this.Thumbnail = node["thumbnail"].InnerText;
            this.Image = node["image"].InnerText;
            this.Yearpublished = Convert.ToInt32(node["yearpublished"].GetAttribute("value"));
            this.Minplayers = Convert.ToInt32(node["minplayers"].GetAttribute("value"));
            this.Maxplayers = Convert.ToInt32(node["maxplayers"].GetAttribute("value"));
            this.Playingtime = Convert.ToInt32(node["playingtime"].GetAttribute("value"));
            this.Maxplaytime = Convert.ToInt32(node["maxplaytime"].GetAttribute("value"));
            this.Minplaytime = Convert.ToInt32(node["minplaytime"].GetAttribute("value"));
            this.Minage = Convert.ToInt32(node["minage"].GetAttribute("value"));
        }
    }
}
