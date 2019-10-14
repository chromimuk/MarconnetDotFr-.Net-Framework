using MarconnetDotFr_DernierFM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarconnetDotFr_DernierFM.Models.DAO
{
    public class LastFMAlbumXMLDao : ILastFMAlbumDAO
    {
        private XElement element;

        public LastFMAlbumXMLDao(XElement e)
        {
            element = e;
        }

        public string GetMBID()
        {
            return XMLHelper.GetValue(element, "mbid");
        }

        public string GetName()
        {
            return XMLHelper.GetValue(element, "name");
        }

        public string GetArtist()
        {
            return XMLHelper.GetValue(element, "artist");
        }

        public long GetPlaycount()
        {
            string value = XMLHelper.GetValue(element, "playcount");
            long playCount = Convert.ToInt64(value);
            return playCount;
        }

        public string GetAlbumImageURL()
        {
            return XMLHelper.GetValue(element, "image", "size", "large");
        }
    }
}
