using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;

namespace MarconnetDotFr_MVC.Tests
{
    // testing logic from the book 'Pro ASP.Net MVC 5' by Adam Freeman ; 'URL Routing' chapter

    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        public void TestIncomingRoutes_Work_IDKCSS()
        {
            TestRouteMatch("∼/work/idkcss", "Work", "IDKCSS");
        }

        [TestMethod]
        public void TestIncomingRoutes_Work_Standard()
        {
            TestRouteMatch("∼/work/cdf", "Work", "Standard", new { Title = "cdf" });
        }

        [TestMethod]
        public void TestIncomingRoutes_Default()
        {
            TestRouteMatch("∼/", "Home", "Index");
        }



        /// <summary>
        /// Test if an URL targets the expected controller/action
        /// </summary>
        /// <param name="url">URL to test</param>
        /// <param name="controller">expected targeted controller</param>
        /// <param name="action">expected targeted action</param>
        /// <param name="routeProperties">object containing the aditional values</param>
        /// <param name="httpMethod">Type of the method (GET, POST, etc.)</param>
        private void TestRouteMatch(string url, string controller, string action, 
            object routeProperties = null, string httpMethod = "GET")
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }


        private void TestRouteFail(string url)
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            // Assert
            Assert.IsTrue(result == null || result.Route == null);
        }



        /// <summary>
        /// Expose the URL we want to test through the AppRelativeCurrentExecutionFilePath property
        /// Expose the HttpRequestBase through the Request property of the mock HttpContextBase
        /// </summary>
        /// <param name="targetUrl">URL we want to test</param>
        /// <param name="httpMethod">Type of the method (GET, POST, etc.)</param>
        /// <returns>HttpContext for testing</returns>
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            // create the mock request
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // create the mock response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            // create the mock context, using the request and response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            // return the mocked context
            return mockContext.Object;
        }

        /// <summary>
        /// Compare the result obtained from the routing system with the segment variable values expected
        /// </summary>
        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action,
            object propertySet = null)
        {
            bool valCompare(object v1, object v2)
            {
                return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
            }

            bool result = valCompare(routeResult.Values["controller"], controller)
                && valCompare(routeResult.Values["action"], action);

            if (propertySet != null)
            {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo)
                {

                    if (!(routeResult.Values.ContainsKey(pi.Name) && valCompare(routeResult.Values[pi.Name], pi.GetValue(propertySet, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
    }

}
