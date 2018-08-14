using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarconnetDotFr_2018.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MarconnetDotFr_2018.Models.Repos;
using MarconnetDotFr_2018.Models.Entities;
using System.Web.Mvc;

namespace MarconnetDotFr_2018.Controllers.Tests
{
    [TestClass()]
    public class WorkControllerTests
    {
        [TestMethod()]
        public void StandardTest_ExistingWorkModel()
        {
            // Arrange
            Mock<IResumeRepository> mockResumeRepo = new Mock<IResumeRepository>();
            mockResumeRepo.Setup(x => x.GetPersonalWork()).Returns(new List<WorkItemModel>()
            {
                new WorkItemModel() { Alias = "ABC" }
            });

            Mock<IWorkRepository> mockWorkRepo = new Mock<IWorkRepository>();
            mockWorkRepo.Setup(x => x.GetWorkModel("ABC")).Returns(new WorkModel()
            {
                Title = "WorkModel_ABC"
            });

            WorkController controller = new WorkController(mockResumeRepo.Object, mockWorkRepo.Object);

            // Act
            ActionResult actionResult = controller.Standard("ABC");

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));
            Assert.AreEqual("WorkModel_ABC", ((WorkModel)((ViewResult)actionResult).Model).Title);
        }


        [TestMethod()]
        public void StandardTest_NonExistingWorkModel()
        {
            // Arrange
            Mock<IResumeRepository> mockResumeRepo = new Mock<IResumeRepository>();
            mockResumeRepo.Setup(x => x.GetPersonalWork()).Returns(new List<WorkItemModel>()
            {
                new WorkItemModel() { Alias = "XYZ" }
            });

            Mock<IWorkRepository> mockWorkRepo = new Mock<IWorkRepository>();
            mockWorkRepo.Setup(x => x.GetWorkModel("XYZ")).Returns(new WorkModel() { });

            WorkController controller = new WorkController(mockResumeRepo.Object, mockWorkRepo.Object);

            // Act
            ActionResult actionResult = controller.Standard("ABC");

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(RedirectToRouteResult));
        }


        [TestMethod()]
        public void StandardTest_MismatchBetweenRepo_CallTheOnePresentInResumeRepo()
        {
            // ABC in ResumeRepo but not in WorkRepo

            // Arrange
            Mock<IResumeRepository> mockResumeRepo = new Mock<IResumeRepository>();
            mockResumeRepo.Setup(x => x.GetPersonalWork()).Returns(new List<WorkItemModel>()
            {
                new WorkItemModel() { Alias = "ABC" }
            });

            Mock<IWorkRepository> mockWorkRepo = new Mock<IWorkRepository>();
            mockWorkRepo.Setup(x => x.GetWorkModel("XYZ")).Returns(new WorkModel() { });

            WorkController controller = new WorkController(mockResumeRepo.Object, mockWorkRepo.Object);

            // Act
            ActionResult actionResult = controller.Standard("ABC");

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(RedirectToRouteResult));
        }


        [TestMethod()]
        public void StandardTest_MismatchBetweenRepo_CallTheOnePresentInWorkRepo()
        {
            // ABC in ResumeRepo but not in WorkRepo

            // Arrange
            Mock<IResumeRepository> mockResumeRepo = new Mock<IResumeRepository>();
            mockResumeRepo.Setup(x => x.GetPersonalWork()).Returns(new List<WorkItemModel>()
            {
                new WorkItemModel() { Alias = "ABC" }
            });

            Mock<IWorkRepository> mockWorkRepo = new Mock<IWorkRepository>();
            mockWorkRepo.Setup(x => x.GetWorkModel("XYZ")).Returns(new WorkModel() { });

            WorkController controller = new WorkController(mockResumeRepo.Object, mockWorkRepo.Object);

            // Act
            ActionResult actionResult = controller.Standard("XYZ");

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(RedirectToRouteResult));
        }
    }
}