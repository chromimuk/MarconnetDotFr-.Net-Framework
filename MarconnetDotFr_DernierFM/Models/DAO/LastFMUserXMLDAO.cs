using MarconnetDotFr_DernierFM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarconnetDotFr_DernierFM.Models.DAO
{
    public class LastFMUserXMLDAO : ILastFMUserDAO
    {
        private XElement element;

        public LastFMUserXMLDAO(XElement e)
        {
            element = e;
        }

        public string GetName()
        {
            return XMLHelper.GetValue(element, "name");
        }

        public string GetRealName()
        {
            return XMLHelper.GetValue(element, "realname");
        }

        public string GetImage()
        {
            return XMLHelper.GetValue(element, "image");
        }

        public string GetURL()
        {
            return XMLHelper.GetValue(element, "url");
        }

        public string GetCountry()
        {
            return XMLHelper.GetValue(element, "country");
        }

        public long GetPlayCount()
        {
            string value = XMLHelper.GetValue(element, "playcount");
            long playCount = Convert.ToInt64(value);
            return playCount;
        }

        public DateTime GetRegistered()
        {
            string value = XMLHelper.GetValue(element, "registered");
            long registeredUnixTime = Convert.ToInt64(value);
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime registeredDatetime = dtDateTime.AddSeconds(registeredUnixTime).ToLocalTime();
            return registeredDatetime;
        }
    }
}
