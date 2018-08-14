using MarconnetDotFr_MVC.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarconnetDotFr_MVC.Models.Entities
{
    public class WorkItemModel
    {
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Link { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }

        public WorkItemModel() { }

        public WorkItemModel(IWorkItemModelDAO dao)
        {
            Title = dao.GetTitle();
            Alias = dao.GetAlias();
            Description = dao.GetDescription();
            Link = dao.GetLink();
            Subtitle = dao.GetSubtitle();
        }
    }
}