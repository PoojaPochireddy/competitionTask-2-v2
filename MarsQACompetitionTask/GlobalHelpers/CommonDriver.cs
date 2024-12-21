using AventStack.ExtentReports;
using MarsQACompetitionTask.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsQACompetitionTask.GlobalHelpers.CommonMethods;

namespace MarsQACompetitionTask.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;
        public SignIn SignInObj;
        public Education EducationObj;
        public Certification CertificationObj;
        protected ExtentReports _extent;
        protected ExtentTest _test;

        [SetUp]
        public void StartBrowser()
        {
           //driver = new ChromeDriver("C:\\Competition Task-MVP\\MarsQACompetitionTask\\bin\\Debug");
            driver = new ChromeDriver();
            driver.Url = "http://localhost:5000/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SignInObj = new SignIn(driver);
            EducationObj = new Education(driver);
            CertificationObj = new Certification(driver);
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void StopBrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
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

            string path = SaveScreenShotClass.TakeScreenshot(driver);
            _test.AddScreenCaptureFromPath(path);
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
            driver.Quit();
        }
        [OneTimeSetUp]
        public void Setup()
        {
            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new AventStack.ExtentReports.Reporter.ExtentSparkReporter(dir + "Report.html");
           
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            _extent.Flush();
        }

    }
}

