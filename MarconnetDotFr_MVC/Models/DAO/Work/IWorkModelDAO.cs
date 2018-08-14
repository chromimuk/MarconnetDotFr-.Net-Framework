using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarconnetDotFr_MVC.Models.DAO.Work
{
    public interface IWorkModelDAO
    {
        string GetTitle();
        string GetLink();
        string GetSubtitle();
        string GetImage();
        string GetPeriod();
        string GetContent();
        List<string> GetScreenshots();
    }
}
