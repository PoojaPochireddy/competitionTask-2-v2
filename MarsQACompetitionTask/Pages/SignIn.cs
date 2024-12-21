using MarsQACompetitionTask.GlobalHelpers;
using MarsQACompetitionTask.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQACompetitionTask.Pages
{
    public class SignIn 
    {
        private readonly IWebDriver driver;
        public SignIn(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement SignInBtn => driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']"));
        private IWebElement Email => driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));
        private IWebElement Password => driver.FindElement(By.XPath("//INPUT[@type='password']"));
        private IWebElement LoginBtn => driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));
        
        
        public static object ExcelLibHelper { get; private set; }

        public void SigninStep()
        {
            //Driver.NavigateUrl();
            SignInBtn.Click();
            Email.SendKeys(ReadJsonData.GetData("User.username"));
            Password.SendKeys(ReadJsonData.GetData("User.password"));
            LoginBtn.Click();
        }

        public void SigninStep(String filename)
        {
            //Driver.NavigateUrl();
            SignInBtn.Click();
            Email.SendKeys(ReadJsonData.GetData("User.username", filename));
            Password.SendKeys(ReadJsonData.GetData("User.password", filename));
            LoginBtn.Click();
        }
       /* public void Login()
        {
            SignInBtn.Click();

            //Enter Url
            driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']")).Click();

            //Enter Username
            driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]")).SendKeys("");

            //Enter password
            driver.FindElement(By.XPath("//INPUT[@type='password']")).SendKeys("");

            //Click on Login Button
            driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']")).Click();

        }*/
    }
}
