using System;
using Kneat.Framework.Browser;
using NUnit.Framework;

namespace Kneat.TestCases.Base
{
    [TestFixture]
    public class BaseTest
    {
        public BaseTest()
        {

        }

        [SetUp]
        public void MyTestInitialize()
        {
            // start logger

            // Test Init
            BrowserManager.Instance.Init();
            BrowserManager.Instance.Visit("https://www.booking.com/searchresults.html");
        }

        [TearDown]
        public void MyTestCleanup()
        {
            // Test Clean up
            BrowserManager.Instance.Quit();
        }


    }
}
