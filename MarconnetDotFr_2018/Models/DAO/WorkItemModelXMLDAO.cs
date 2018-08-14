using System.Xml.Linq;

namespace MarconnetDotFr_2018.Models.DAO
{
    public class WorkItemModelXMLDAO : IWorkItemModelDAO
    {
        private XElement element;

        public WorkItemModelXMLDAO(XElement e)
        {
            element = e;
        }

        public string GetAlias()
        {
            return element.Element("alias").Value;
        }

        public string GetDescription()
        {
            return element.Element("description").Value;
        }

        public string GetLink()
        {
            return element.Element("link").Value;
        }

        public string GetSubtitle()
        {
            return element.Element("subtitle").Value;
        }

        public string GetTitle()
        {
            return element.Element("title").Value;
        }
    }
}