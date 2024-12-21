using MarsQACompetitionTask.Pages;
using MarsQACompetitionTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.DevTools.V114.Profiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQACompetitionTask.POMTests
{
    [TestFixture]
    public class EducationAndCertificationTests  : CommonDriver
    {
        /*public IWebDriver driver;
        public SignIn SignInObj;
        public Education EducationObj;
        public Certifications CertificationObj;*/
        

        [Test, Order(1), Description("Create Record")]
        public void CreateEducationTests()
        {
            SignInObj.SigninStep("CreateENFile.json");
            EducationObj.EducationTab();
            EducationObj.CleanEducationTable();
            Assert.AreEqual("Education has been added", EducationObj.CreateEducation("CreateENFile.json"));
        }

        [Test, Order(2), Description("Cancel Record")]
        public void CancelEducationTests()
        {
            SignInObj.SigninStep("CancelAddedENFile.json");
            EducationObj.EducationTab();
            EducationObj.CancelAddedEducation("CancelAddedENFile.json");
        }
        [Test, Order(3), Description("Edit or update Record")]
        public void UpdateEducationTests()
        {
            SignInObj.SigninStep("UpdateENFile.json");
            EducationObj.EducationTab();
            EducationObj.CleanEducationTable();
            Assert.AreEqual("Education has been added", EducationObj.CreateEducation("CreateENFile.json"));
            Assert.AreEqual("Education as been updated", EducationObj.EditEducation("UpdateENFile.json"));
        }
        [Test, Order(4), Description("CancelUpdated Record")]
        public void CancelUpdatedEducationTests()
        {
            SignInObj.SigninStep("CancelUpdatedENFile.json");
            EducationObj.EducationTab();
            EducationObj.CancelEditEducation("CancelUpdatedENFile.json");
        }
        [Test, Order(5), Description("Delete Record")]
        public void DeleteEducationTests()
        {
            SignInObj.SigninStep("DeleteENFile.json");
            EducationObj.EducationTab();
            EducationObj.DeleteEducation();
            Thread.Sleep(1000);
        }
        [Test, Order(6), Description("Create CRecord")]
        public void CreateCertificationsTests()
        {
            SignInObj.SigninStep("CreateCRFile.json");

            CertificationObj.CertificationTab();
            CertificationObj.CreateCertification("CreateCRFile.json");

        }

        [Test, Order(7), Description("Cancel Record")]
        public void CancelAddedCertifications()
        {
            SignInObj.SigninStep("CancelAddedCRFile.json");

            CertificationObj.CertificationTab();
            CertificationObj.CancelAddedCertification("CancelAddedCRFile.json");
        }
        [Test, Order(8), Description("Edit or update Record")]
        public void UpdateCertification()
        {
            SignInObj.SigninStep("UpdateCRFile.json");
            CertificationObj.CertificationTab();
            CertificationObj.EditCertification1("UpdateCRFile.json");

        }
        [Test, Order(9), Description("CancelUpdated Record")]
        public void CancelUpdatedCertificationTests()
        {
            SignInObj.SigninStep("CancelUpdatedCRFile.json");
            CertificationObj.CertificationTab();
            CertificationObj.CancelEditCertification("CancelUpdatedCRFile.json");
        }
        [Test, Order(10), Description("Delete Record")]
        public void DeleteCertificationTests()
        {
            SignInObj.SigninStep("DeleteCRFile.json");
            CertificationObj.CertificationTab();
            CertificationObj.DeleteCertification1();
            Thread.Sleep(1000);
        }

    }
}
