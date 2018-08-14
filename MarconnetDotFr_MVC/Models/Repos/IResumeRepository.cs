using MarconnetDotFr_MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarconnetDotFr_MVC.Models.Repos
{
    public interface IResumeRepository
    {
        IEnumerable<ResumeItemModel> GetWorkExperiences();
        IEnumerable<ResumeItemModel> GetUniversityDiplomas();
        IEnumerable<WorkItemModel> GetPersonalWork();
    }
}
