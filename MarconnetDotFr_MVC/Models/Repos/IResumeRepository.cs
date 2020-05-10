using MarconnetDotFr_MVC.Models.Entities;
using System.Collections.Generic;

namespace MarconnetDotFr_MVC.Models.Repos
{
    public interface IResumeRepository
    {
        IEnumerable<ResumeItemModel> GetWorkExperiences();

        IEnumerable<ResumeItemModel> GetUniversityDiplomas();

        IEnumerable<WorkItemModel> GetPersonalWork();
    }
}