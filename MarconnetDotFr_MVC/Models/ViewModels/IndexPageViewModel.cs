using MarconnetDotFr_MVC.Models.Entities;
using System.Collections.Generic;

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