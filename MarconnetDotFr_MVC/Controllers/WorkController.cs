using MarconnetDotFr_MVC.Models.Entities;
using MarconnetDotFr_MVC.Models.Repos;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MarconnetDotFr_MVC.Controllers
{
    public class WorkController : Controller
    {
        private IWorkRepository _workRepository;

        // list of aliases of 'WorkModel'
        private IEnumerable<string> _availableWorks = null;

        public WorkController(IResumeRepository resumeRepository, IWorkRepository workRepository)
        {
            /// resumeRepository contains the list of 'WorkModel'
            /// workRepository has access to the details of each 'WorkModel'
            /// we're going to save the aliases of each 'WorkModel',
            /// and use that against the parameter we get from request on the Standard action

            IEnumerable<WorkItemModel> workItems = resumeRepository.GetPersonalWork();
            _availableWorks = workItems.Select(x => x.Alias);

            _workRepository = workRepository;
        }

        /// <summary>
        /// Standard presentation for WorkItem
        /// </summary>
        /// <param name="title">name of the WorkItem to show</param>
        /// <returns>if the WorkItem exists then returns the view, else redirect to root</returns>
        public ActionResult Standard(string title)
        {
            ActionResult actionResult = null;

            if (_availableWorks.Contains(title))
            {
                WorkModel workModel = _workRepository.GetWorkModel(title);
                if (workModel != null)
                    actionResult = View(workModel);
                else
                    actionResult = RedirectToAction("Index", "Home");
            }
            else
            {
                actionResult = RedirectToAction("Index", "Home");
            }

            return actionResult;
        }

        /// <summary>
        /// Specific view for the IDKCSS project
        /// </summary>
        public ActionResult IDKCSS()
        {
            return View();
        }
    }
}