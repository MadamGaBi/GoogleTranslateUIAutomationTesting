using GoogleTranslateTAFramework;
using GoogleTranslateUIAutomationTesting.Reports;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace GoogleTranslateUIAutomationTesting
{
    [TestFixture]
    public class BaseTest
    {
        protected ExtentReports extent;
        protected ExtentTest test;
        private static Reporting reporting;

        [OneTimeSetUp]
        protected void Setup()
        {
            reporting = new Reporting();
            reporting.SetUpReporting();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            reporting.CleanUpReporting();
        }

        [SetUp]
        public void Initialize()
        {
            Browser.Initialize();
            reporting.InitializeTest();
        }

        [TearDown]
        public void TearDown()
        {
            if (Browser.Driver != null)
            {
                Browser.Quit();
            }
            reporting.FinalizeTest();

        }

    }
}

