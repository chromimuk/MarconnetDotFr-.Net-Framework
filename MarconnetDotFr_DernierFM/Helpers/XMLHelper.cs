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
        public static string GetValue(XElement element, string name)
        {
            return element.Element(name) == null ? "" : element.Element(name).Value;
        }
    }
}
