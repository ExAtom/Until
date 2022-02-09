using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Until
{
    public class Config
    {
        public string Token;
        public ulong OwnerID;
        public List<ulong> EmojiServers;

        public Config(string path)
        {
            using (StreamReader stream = File.OpenText(path))
            {
                XDocument config = XDocument.Load(stream);
                XElement configElement = config.Element("config");

                this.Token = configElement.Element("token").Value;
                this.OwnerID = ulong.Parse(configElement.Element("ownerid").Value);
                this.EmojiServers = new List<ulong>();

                configElement.Element("emojiservers").Elements("server").ToList().ForEach(s => this.EmojiServers.Add(ulong.Parse(s.Value)));
            }
        }

        //public static Config FromXML(string path)
        //{
        //    Config temp = new Config();
        //    using (StreamReader stream = File.OpenText(path))
        //    {
        //        XDocument config = XDocument.Load(stream);
        //        XElement configElement = config.Element("config");
        //        temp.Token = configElement.Element("token").Value;
        //        temp.OwnerID = ulong.Parse(configElement.Element("ownerid").Value);
        //        temp.EmojiServers
        //    }
        //    return temp;
        //}
    }
}
