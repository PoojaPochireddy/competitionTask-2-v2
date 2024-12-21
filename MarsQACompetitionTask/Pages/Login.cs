using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsQACompetitionTask.Utilities;
using System.Threading;

namespace MarsQACompetitionTask.Pages
{
    public class Login : CommonDriver
    {
       public object Wait { get; private set; }
       
        public void LoginSteps()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            SignInObj.SigninStep();

           // object value = Wait.WaitToBeVisible(driver, "Id", "UserName", 10);

            try
            {
                //Identify username textbox and enter valid username
                IWebElement Username = driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));
                Username.SendKeys(Utilities.ReadJsonData.GetData("User.username"));

            }

            catch (Exception ex)
            {
                Assert.Fail("Seller portal login page hasn't loaded successfully", ex.Message);
            }

            //Identify password textbox and enter valid password
            IWebElement Password = driver.FindElement(By.XPath("//INPUT[@name='password']"));
            Password.SendKeys(Utilities.ReadJsonData.GetData("User.password"));

            //Identify login button and click on it
            IWebElement Login = driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));
            Login.Click();

            Thread.Sleep(1000);

           /* IWebElement UserProfileName = driver.FindElement(By.XPath("//body/div/div/div[@id='home']/div/div/div/div/div/span[1]"));

            //IWebElement UserProfileName = driver.FindElement(By.XPath("//span[@class='item ui dropdown link']"));

            if (UserProfileName.Text == "Hi Pooja")
            {
                Console.WriteLine("User has loged in Successfully");
            }
            else
            {
                Console.WriteLine("User has not logged in sucessfully");
            }*/
        }
    }
}

