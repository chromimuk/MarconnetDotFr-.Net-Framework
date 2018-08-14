using MarconnetDotFr_MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarconnetDotFr_MVC.Models.ViewModels
{
    public class IndexPageViewModel
    {
        public int CurrentAge { get; set; }
        public IEnumerable<ResumeItemModel> WorkExperiences { get; set; }
        public IEnumerable<ResumeItemModel> UniversityDiplomas { get; set; }
        public IEnumerable<WorkItemModel> PersonalWork { get; set; }
    }
}