using MarconnetDotFr_2018.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarconnetDotFr_2018.Models.ViewModels
{
    public class IndexPageViewModel
    {
        public int CurrentAge { get; set; }
        public IEnumerable<ResumeItemModel> WorkExperiences { get; set; }
        public IEnumerable<ResumeItemModel> UniversityDiplomas { get; set; }
        public IEnumerable<WorkItemModel> PersonalWork { get; set; }
    }
}