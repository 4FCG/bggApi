using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace bggApi
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Avatarlink { get; private set; }
        public string Yearregistered { get; private set; }
        public string Lastlogin { get; private set; }
        public string Stateorprovince { get; private set; }
        public string Country { get; private set; }
        public string Webaddress { get; private set; }
        public string Xboxaccount { get; private set; }
        public string Wiiaccount { get; private set; }
        public string Psnaccount { get; private set; }
        public string Battlenetaccount { get; private set; }
        public string Steamaccount { get; private set; }
        public int Traderating { get; private set; }
        public int Marketrating { get; private set; }

        public User(XmlNode node)
        {
            Id = Convert.ToInt32(node.Attributes["id"].Value);
            Name = node.Attributes["name"].Value.ToString();

            PropertyInfo[] properties = this.GetType().GetProperties();
            
            foreach (PropertyInfo property in properties)
            {
                
                if (property.GetValue(this) == null || property.GetValue(this).ToString() == "0")
                {
                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(this, node[property.Name.ToLower()].GetAttribute("value").ToString());
                    }
                    else
                    {
                        property.SetValue(this, Convert.ToInt32(node[property.Name.ToLower()].GetAttribute("value")));
                    }
                }
                Console.WriteLine(property.Name + property.GetValue(this));
            }
        }
    }
}
