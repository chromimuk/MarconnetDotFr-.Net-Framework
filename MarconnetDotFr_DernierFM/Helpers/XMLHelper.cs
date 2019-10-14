using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarconnetDotFr_DernierFM.Helpers
{
    public static class XMLHelper
    {
        public static string GetValue(XElement element, string name, string attributeName = null, string attributeValue = null)
        {
            if (attributeName != null && attributeValue != null)
            {
                IEnumerable<XElement> elements = element.Elements(name);
                if (elements.Any())
                {
                    return elements.First(x => x.Attribute(attributeName).Value == attributeValue).Value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return element.Element(name) == null ? "" : element.Element(name).Value;
            }
        }
    }
}
