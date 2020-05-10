using MarconnetDotFr_MVC.Models.DAO;
using MarconnetDotFr_MVC.Models.Entities;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using System.Xml.Linq;

namespace MarconnetDotFr_MVC.Models.Repos
{
    public class XMLFilesResumeRepository : IResumeRepository
    {
        private readonly string ResumeFile = HostingEnvironment.MapPath("/Content/XML/resume.xml");
        private readonly string PersonalWorkFile = HostingEnvironment.MapPath("/Content/XML/work.xml");

        private bool _isInitialized = false;
        private XDocument _resumeDoc = null;
        private XDocument _personalWorkDoc = null;

        public XMLFilesResumeRepository()
        {
            try
            {
                _resumeDoc = XDocument.Load(ResumeFile);
                _personalWorkDoc = XDocument.Load(PersonalWorkFile);
                _isInitialized = true;
            }
            catch (DirectoryNotFoundException)
            {
#if DEBUG
                throw;
#endif
            }
        }

        public IEnumerable<WorkItemModel> GetPersonalWork()
        {
            List<WorkItemModel> items = new List<WorkItemModel>();

            if (_isInitialized)
            {
                IEnumerable<XElement> elements = _personalWorkDoc.Descendants("work");
                foreach (XElement element in elements)
                {
                    IWorkItemModelDAO dao = new WorkItemModelXMLDAO(element);
                    WorkItemModel item = new WorkItemModel(dao);
                    items.Add(item);
                }
            }

            return items;
        }

        public IEnumerable<ResumeItemModel> GetUniversityDiplomas()
        {
            List<ResumeItemModel> items = new List<ResumeItemModel>();

            if (_isInitialized)
            {
                IEnumerable<XElement> elements = _resumeDoc.Descendants("education").Descendants("edu");
                foreach (XElement element in elements)
                {
                    IResumeItemModelDAO dao = new ResumeItemModelXMLDAO(element);
                    ResumeItemModel item = new ResumeItemModel(dao);
                    items.Add(item);
                }
            }

            return items;
        }

        public IEnumerable<ResumeItemModel> GetWorkExperiences()
        {
            List<ResumeItemModel> items = new List<ResumeItemModel>();

            if (_isInitialized)
            {
                IEnumerable<XElement> elements = _resumeDoc.Descendants("experiences").Descendants("exp");
                foreach (XElement element in elements)
                {
                    IResumeItemModelDAO dao = new ResumeItemModelXMLDAO(element);
                    ResumeItemModel item = new ResumeItemModel(dao);
                    items.Add(item);
                }
            }

            return items;
        }
    }
}