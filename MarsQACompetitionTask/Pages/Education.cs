using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Collections;
using Microsoft.SqlServer.Server;
using MarsQACompetitionTask.GlobalHelpers;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using MarsQACompetitionTask.Utilities;
using AventStack.ExtentReports;

namespace MarsQACompetitionTask.Pages
{

    public class Education
    {
        private readonly IWebDriver driver;
        private IWebElement EducationTab1 => driver.FindElement(By.XPath("//a[text()='Education']"));
        private IWebElement AddNew => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[@class='ui teal button '][normalize-space()='Add New']"));
        private IWebElement CollegeName => driver.FindElement(By.Name("instituteName")); 
        private IWebElement CountryNameDropdown => driver.FindElement(By.Name("country"));
        private IWebElement TitleDropdown => driver.FindElement(By.Name("title"));
        private IWebElement Degree => driver.FindElement(By.Name("degree"));
        private IWebElement YearOfGraduationDropdown => driver.FindElement(By.Name("yearOfGraduation"));
        private IWebElement AddEducation => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement AddMessagechk => driver.FindElement(By.XPath("//*[normalize-space()='Education has been added']"));
        private IWebElement AddMessage => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private IWebElement CancelEducation => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        private IWebElement UpdateBtn => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement UpdateMessage => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private IWebElement CancelBtn1 => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        private IWebElement DeleteMessage => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //*Duplicate Education Details cant be added so cleanup the existing education records first //
        public void CleanEducationTable()
        {
            var Removebuttons = driver.FindElements(By.CssSelector("[class='remove icon']"));
            for (int i = 0; i < Removebuttons.Count; i++)
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                string script = "arguments[0].click();";
                jsExecutor.ExecuteScript(script, Removebuttons[i]);

            }

        }
        public Education(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void EducationTab()
        {
            EducationTab1.Click();
        }
        public String CreateEducation(String fileName)
        {
            Thread.Sleep(2000);
            IList edudetails;
            edudetails = Utilities.ReadJsonData.GetDataObject2("Education[*]", fileName);
            int j = 0;
            j=  edudetails.Count;
           
            Console.WriteLine("edu details '''''", j);

            for (int i = 0 ; i < j; i++)
            {
                AddNew.Click();
                CollegeName.Click();
                CollegeName.SendKeys(Utilities.ReadJsonData.GetData("Education["+i+"].CollegeUniversityName", fileName));

                CountryNameDropdown.Click();                
                CountryNameDropdown.SendKeys(Utilities.ReadJsonData.GetData("Education["+i+"].country",  fileName));

                TitleDropdown.Click();
                TitleDropdown.SendKeys(Utilities.ReadJsonData.GetData("Education["+i+"].title", fileName));

                Degree.Click();
                Degree.Clear();
                Degree.SendKeys(Utilities.ReadJsonData.GetData("Education["+i+ "].Degree", fileName));

                YearOfGraduationDropdown.Click();
                YearOfGraduationDropdown.SendKeys(Utilities.ReadJsonData.GetData("Education["+i+"].yearOfGraduation", fileName));

                AddEducation.Click();
                // Assert.That(AddMessagechk.Text == "Education had been Added", Is.True);
                Thread.Sleep(6000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                wait.PollingInterval = TimeSpan.FromMilliseconds(200);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[normalize-space()='Education has been added']")));

                //  Assert.IsTrue(AddMessagechk.Text == "Education had been Added");

            }

            return AddMessagechk.Text;
        }
        public String CreateEducation1()
        {
            Thread.Sleep(2000);
            IList edudetails;
           
       


            edudetails = Utilities.ReadJsonData.GetDataObject2("Education[*]");
            int j = 0;
            j = edudetails.Count;

            Console.WriteLine("edu details '''''", j);

            for (int i = 0; i < j; i++)
            {
                AddNew.Click();
                CollegeName.Click();
                CollegeName.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].CollegeUniversityName"));

                CountryNameDropdown.Click();
                CountryNameDropdown.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].country"));

                TitleDropdown.Click();
                TitleDropdown.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].title"));

                Degree.Click();
                Degree.Clear();
                Degree.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].Degree"));

                YearOfGraduationDropdown.Click();
                YearOfGraduationDropdown.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].yearOfGraduation"));

                AddEducation.Click();
                // Assert.That(AddMessagechk.Text == "Education had been Added", Is.True);
                Thread.Sleep(6000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                wait.PollingInterval = TimeSpan.FromMilliseconds(200);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[normalize-space()='Education has been added']")));

                //  Assert.IsTrue(AddMessagechk.Text == "Education had been Added");

            }

            return AddMessagechk.Text;
        }
        public void CancelAddedEducation(String fileName)
        {

            EducationTab1.Click();
            int i = 0;
            
            AddNew.Click();

            CollegeName.Click();
            CollegeName.Clear();
            CollegeName.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].CollegeUniversityName", fileName));

            CountryNameDropdown.Click();
            CountryNameDropdown.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].country", fileName));


            TitleDropdown.Click();
            TitleDropdown.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].title", fileName));


            Degree.Click();
            Degree.Clear();
            Degree.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].Degree", fileName));

            YearOfGraduationDropdown.Click();
            YearOfGraduationDropdown.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].yearOfGraduation", fileName));

            CancelEducation.Click();
            
        }
        public String EditEducation(String fileName)
        {
            IWebElement EditEducation = driver.FindElement(By.XPath("//tbody/tr/td[6]/span[1]/i[1]"));
            Thread.Sleep(2000);
            EditEducation.Click();

            int i = 0;
 
            CollegeName.Click();
            CollegeName.Clear();
            CollegeName.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].updateTitle", fileName));


            UpdateBtn.Click();

            return UpdateMessage.Text;
        }

        public void CancelEditEducation(String fileName)
        {
            IWebElement EditEducation = driver.FindElement(By.XPath("//tbody/tr/td[6]/span[1]/i[1]"));
            Thread.Sleep(2000);
            EditEducation.Click();

            int i = 0;

            CollegeName.Click();
            CollegeName.Clear();
            CollegeName.SendKeys(Utilities.ReadJsonData.GetData("Education[" + i + "].CollegeUniversityName",fileName));

            CancelBtn1.Click();
        }
        public void DeleteEducation()
        {
            IWebElement DeleteButton = driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
            DeleteButton.Click();

            if(DeleteMessage.Text == "Education Entry Successfully Removed")
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
