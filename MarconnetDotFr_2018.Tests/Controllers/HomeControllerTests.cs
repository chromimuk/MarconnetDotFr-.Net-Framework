using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarconnetDotFr_2018.Models.Repos;
using Moq;
using System.Collections.Generic;
using MarconnetDotFr_2018.Models.Entities;
using MarconnetDotFr_2018.Models.ViewModels;
using System.Linq;

namespace MarconnetDotFr_2018.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            Mock<IResumeRepository> mock = new Mock<IResumeRepository>();
            mock.Setup(x => x.GetPersonalWork()).Returns(new List<WorkItemModel>()
            {
                new WorkItemModel() { Title = "Title" }
            });
            mock.Setup(x => x.GetWorkExperiences()).Returns(new List<ResumeItemModel>()
            {
                new ResumeItemModel() { Title = "Title" },
                new ResumeItemModel() { Title = "Title2" }
            });
            mock.Setup(x => x.GetUniversityDiplomas()).Returns(new List<ResumeItemModel>() {});
            HomeController controller = new HomeController(mock.Object);

            // Act
            IndexPageViewModel actualModel = (IndexPageViewModel) controller.Index().Model;

            // Assert
            Assert.AreEqual(1, actualModel.PersonalWork.Count());
            Assert.AreEqual("Title", actualModel.PersonalWork.ToArray()[0].Title);

            Assert.AreEqual(2, actualModel.WorkExperiences.Count());
            Assert.AreEqual("Title", actualModel.WorkExperiences.ToArray()[0].Title);
            Assert.AreEqual("Title2", actualModel.WorkExperiences.ToArray()[1].Title);

            Assert.AreEqual(0, actualModel.UniversityDiplomas.Count());
        }
    }
}