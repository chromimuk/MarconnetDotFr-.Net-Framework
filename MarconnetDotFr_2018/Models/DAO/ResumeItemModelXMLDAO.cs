using MarconnetDotFr_2018.Helper;
using System.Xml.Linq;

namespace MarconnetDotFr_2018.Models.DAO
{
    public class ResumeItemModelXMLDAO : IResumeItemModelDAO
    {
        private XElement element;

        public ResumeItemModelXMLDAO(XElement e)
        {
            element = e;
        }

        public string GetDescription()
        {
            return XMLHelper.GetValue(element, "description");
        }

        public string GetLocation()
        {
            return XMLHelper.GetValue(element, "location");
        }

        public string GetShortLocation()
        {
            return XMLHelper.GetValue(element, "short-location");
        }

        public string GetTitle()
        {
            return XMLHelper.GetValue(element, "title");
        }

        public string GetShortTitle()
        {
            return XMLHelper.GetValue(element, "short-title");
        }

        public string GetImage()
        {
            return XMLHelper.GetValue(element, "image");
        }

        public string GetTech()
        {
            return XMLHelper.GetValue(element, "tech");
        }
    }
}