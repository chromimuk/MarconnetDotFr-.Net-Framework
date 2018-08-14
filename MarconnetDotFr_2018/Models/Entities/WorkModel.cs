using MarconnetDotFr_2018.Models.DAO.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarconnetDotFr_2018.Models.Entities
{
    public class WorkModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Subtitle { get; set; }
        public string Image { get; set; }
        public string Period { get; set; }
        public string Content { get; set; }
        public List<string> Screenshots { get; set; }

        public WorkModel() { }

        public WorkModel(IWorkModelDAO dao)
        {
            Title = dao.GetTitle();
            Link = dao.GetLink();
            Subtitle = dao.GetSubtitle();
            Image = dao.GetImage();
            Period = dao.GetPeriod();
            Content = dao.GetContent();
            Screenshots = dao.GetScreenshots();
        }
    }
}