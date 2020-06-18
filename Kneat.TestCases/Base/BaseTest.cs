using System;
using Kneat.Framework.Browser;
using Kneat.Reports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Kneat.TestCases.Base
{
    [TestFixture]
    public class BaseTest
    {
        [OneTimeSetUp]
        public void SetUpReporter()
        {
            ExtentReportsHelper.Instance.Init();
        }

        [SetUp]
        public void MyTestInitialize()
        {
            try
            {
                // start logger
                ExtentReportsHelper.Instance.CreateTest(TestContext.CurrentContext.Test.Name);

                // Test Init
                BrowserManager.Instance.Init();
                BrowserManager.Instance.Visit("https://www.booking.com");
            }
            catch (Exception ex)
            {
                var errorMessage = $"{ex.Message} :: {ex.StackTrace}";
                ExtentReportsHelper.Instance.SetTestStatusFail(errorMessage);

                throw new Exception(errorMessage);
            }
        }

        [TearDown]
        public void MyTestCleanup()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";

                switch (status)
                {
                    case TestStatus.Failed:
                        ExtentReportsHelper.Instance.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        ExtentReportsHelper.Instance.AddTestFailureScreenshot(BrowserManager.Instance.ScreenCaptureAsBase64String());
                        break;
                    case TestStatus.Skipped:
                        ExtentReportsHelper.Instance.SetTestStatusSkipped();
                        break;
                    default:
                        ExtentReportsHelper.Instance.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                // Test Clean up
                BrowserManager.Instance.Quit();
            }
           
        }

        [OneTimeTearDown]
        public void CloseAll()
        {
            try
            {
                ExtentReportsHelper.Instance.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
