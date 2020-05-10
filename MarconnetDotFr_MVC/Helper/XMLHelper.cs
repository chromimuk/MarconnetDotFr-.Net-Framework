using System.Xml.Linq;

namespace MarconnetDotFr_MVC.Helper
{
    public class XMLHelper
    {
        public static string GetValue(XElement element, string name)
        {
            return element.Element(name) == null ? "" : element.Element(name).Value;
        }
    }
}