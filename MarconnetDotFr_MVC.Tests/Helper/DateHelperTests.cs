using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarconnetDotFr_MVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarconnetDotFr_MVC.Helper.Tests
{
    [TestClass()]
    public class DateHelperTests
    {
        [TestMethod()]
        public void GetYearDifference_FirstDateNewer()
        {
            // Arrange
            int year1 = 1990;
            int year2 = 2000;
            DateTime d1 = new DateTime(year1, 01, 01);
            DateTime d2 = new DateTime(year2, 01, 01);

            // Act
            int actualAgeDifference = DateHelper.GetYearDifference(d1, d2);

            // Assert
            Assert.AreEqual(year2 - year1, actualAgeDifference);
        }

        [TestMethod()]
        public void GetYearDifference_FirstDateOlder()
        {
            // Arrange
            int year1 = 1990;
            int year2 = 2000;
            DateTime d1 = new DateTime(year1, 01, 01);
            DateTime d2 = new DateTime(year2, 01, 01);

            // Act
            int actualAgeDifference = DateHelper.GetYearDifference(d1, d2);

            // Assert
            Assert.AreEqual(year2 - year1, actualAgeDifference);
        }

        [TestMethod()]
        public void GetYearDifference_SameDate()
        {
            // Arrange
            int year1 = 1990;
            DateTime d1 = new DateTime(year1, 01, 01);
            DateTime d2 = new DateTime(year1, 01, 01);

            // Act
            int actualAgeDifference = DateHelper.GetYearDifference(d1, d2);

            // Assert
            Assert.AreEqual(0, actualAgeDifference);
        }
    }
}