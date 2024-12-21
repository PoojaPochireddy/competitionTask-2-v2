using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;
using MarsQACompetitionTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MarsQACompetitionTask.Pages 
{
    public class Certification
    {
        private readonly IWebDriver driver;
        private IWebElement CertificationTab1 => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        private IWebElement AddNewBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        private IWebElement CName => driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
        private IWebElement CertifiedFrom => driver.FindElement(By.Name("certificationFrom"));
        private IWebElement CYearDrpdown => driver.FindElement(By.Name("certificationYear"));
        private IWebElement AddCertification => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement CancelCertification => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        private IWebElement EditCertification => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i"));
        private IWebElement CUpdateBtn => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement CancelCBtn1 => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        private IWebElement DeleteCertification => driver.FindElement(By.XPath("//tbody/tr/td[4]/span[2]/i[1]"));
        private IWebElement DelMessage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]"));
        private IWebElement RemoveButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
       
        protected ExtentReports _extent;
        protected ExtentTest _test;

        //Duplicate Certifications Details cant be added so cleanup the existing education records first //
        public void CleanEducationTable()
        {
            try
            {
                while (RemoveButton.Displayed) //once all Certification details are deleted, remove button wont be displayed and loop will end
                {
                    RemoveButton.Click();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Certification(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void CertificationTab()
        {
            CertificationTab1.Click();
        }
        public void CreateCertification(String fileName)

        {
            IList certdetails;
            certdetails = Utilities.ReadJsonData.GetDataObject2("Certification[*]", fileName);
            int j = 0;
            j = certdetails.Count;

            Console.WriteLine("cert details '''''", j);


            for (int i = 0; i < j; i++)
            { 

            AddNewBtn.Click();
            CName.Click();
           // CName.Clear();
            CName.SendKeys(Utilities.ReadJsonData.GetData("Certification[" + i + "].CertificationName",fileName));

            CertifiedFrom.Click();
            CertifiedFrom.SendKeys(Utilities.ReadJsonData.GetData("Certification[" + i + "].CertifiedFrom", fileName));

            CYearDrpdown.Click();
                CYearDrpdown.SendKeys(Utilities.ReadJsonData.GetData("Certification[" + i + "].CyrDropdown", fileName));


            AddCertification.Click();
                //Thread.Sleep(1000);
                //Thread.Sleep(6000);
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
//
             //wait.PollingInterval = TimeSpan.FromMilliseconds(200);
               // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[normalize-space()='Certification details added']")));

              //  _test.Log(Status.Info, "Certification details added");
            }

        }
        public void CancelAddedCertification(String fileName)
        {

            CertificationTab1.Click();

            int i = 0;

            AddNewBtn.Click();

           
            CName.Click();
            CName.Clear();
            CName.SendKeys(Utilities.ReadJsonData.GetData("Certification[" + i + "].CertificationName", fileName));

            CertifiedFrom.Click();
            CName.SendKeys(Utilities.ReadJsonData.GetData("Certification[" + i + "].CertifiedFrom",fileName));


            CYearDrpdown.Click();
            CName.SendKeys(Utilities.ReadJsonData.GetData("Certification[" + i + "].CyrDropdown",fileName));

            CancelCertification.Click();
        }

        public void EditCertification1(String fileName)
        {
            Thread.Sleep(2000);
            EditCertification.Click();
            int i = 0;

            CName.Click();
            CName.Clear();
            CName.SendKeys(Utilities.ReadJsonData.GetData("Certification[" + i + "].CertificationName",fileName));


            CUpdateBtn.Click();

        }
        public void CancelEditCertification(String fileName)
        {
            Thread.Sleep(2000);
            EditCertification.Click();

            int i = 0;

            CName.Click();
            CName.Clear();
            CName.SendKeys(Utilities.ReadJsonData.GetData("Certification[" + i + "].CertificationName" ,fileName));

            CancelCBtn1.Click();
        }
        public void DeleteCertification1()
        { 
            DeleteCertification.Click();

            if (DelMessage.Text == "Certification Entry Successfully Removed")
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }

}
