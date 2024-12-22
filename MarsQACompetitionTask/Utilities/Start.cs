using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MarsQACompetitionTask.Pages;
using MarsQACompetitionTask.Utilities;

namespace MarsQACompetitionTask
{
    public class Start : CommonDriver
    {
        new IWebDriver driver;

        [SetUp]
        public void StartBrowsers()
        {
            driver = new ChromeDriver("C:\\Competition Task-MVP\\MarsQACompetitionTask\\bin\\Debug");
        }

        //[Test]

        public void UrlTest()
        { 
            driver.Url = "http://localhost:5000/";
        }

        //[TearDown]
        public void InitializeComponent()
        {
            IWebElement SignIn = driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In'][1]"));
            //IWebElement SignIn = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            SignIn.Click();
            Login LoginObj = new Login();
            LoginObj.LoginSteps();
        }

    }

}
