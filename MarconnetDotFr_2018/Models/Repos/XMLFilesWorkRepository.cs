using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;
using MarconnetDotFr_2018.Models.DAO.Work;
using MarconnetDotFr_2018.Models.Entities;

namespace MarconnetDotFr_2018.Models.Repos
{
    public class XMLFilesWorkRepository : IWorkRepository
    {
        private Dictionary<string, string> _knownWorks = new Dictionary<string, string>()
        {
            { "castable", "work_castable.xml" },
            { "cdf", "work_cdf.xml" },
            { "colisee", "work_colisee.xml" },
        };

        public WorkModel GetWorkModel(string workModelName)
        {
            if (_knownWorks.ContainsKey(workModelName))
            {
                string xmlFileName = _knownWorks[workModelName];
                string xmlFilePath = HostingEnvironment.MapPath(Path.Combine("/Content/XML/", xmlFileName));
                XDocument xmlFile = XDocument.Load(xmlFilePath);

                IWorkModelDAO dao = new WorkModelXMLDAO(xmlFile);
                return new WorkModel(dao);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}