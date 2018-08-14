using MarconnetDotFr_2018.Helper;
using MarconnetDotFr_2018.Models.Repos;
using MarconnetDotFr_2018.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace MarconnetDotFr_2018.Controllers
{
    public class HomeController : Controller
    {
        private readonly DateTime _birthDate = new DateTime(1992, 8, 15);
        private IResumeRepository _repository = null;

        public HomeController(IResumeRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index()
        {
            IndexPageViewModel model = new IndexPageViewModel()
            {
                CurrentAge = DateHelper.GetYearDifference(_birthDate, DateTime.UtcNow),
                WorkExperiences = _repository.GetWorkExperiences(),
                UniversityDiplomas = _repository.GetUniversityDiplomas(),
                PersonalWork = _repository.GetPersonalWork()
            };

            return View(model);
        }
    }
}