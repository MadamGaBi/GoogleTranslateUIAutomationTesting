using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using GoogleTranslateTAFramework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslateUIAutomationTesting.Reports
{    
    public class Reporting
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;
                
        /*
         * One Time Set Up Reporting.
         * Runs before all the tests are started
         */
        public void SetUpReporting()
        {
                string reportPath = TestContext.CurrentContext.TestDirectory + "\\";
                string fileName = this.GetType().ToString() + "_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ".html";
                ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath + fileName);

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);         
        }

        /*
         * Cleans up reporting.
         * Runs after all the tests are finished
         */
        public void CleanUpReporting()
        {
            _extent.Flush();
        }

        /*
         * Initializes the test for reporting.
         * Runs at the beginning of every test
         */
        public void InitializeTest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        /*
         * Finalizes the test.
         * Runs at the end of every test
         */
        public void FinalizeTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
        }
    }
}
