using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
//using RelevantCodes.ExtentReports;


namespace MarsQACompetitionTask.GlobalHelpers
{
    public class CommonMethods
    {
        //Screenshots
        //Screenshot

        public class SaveScreenShotClass
        {
            private static object ScreenshotImageFormat;
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = (ConstantHelpers.ScreenshotPath);
                var dir = TestContext.CurrentContext.TestDirectory + "\\Screenshots";
               

                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                fileName.Append(".jpeg");
                //screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.jpeg);
                screenShot.SaveAsFile(fileName.ToString() + "jpeg");

                return fileName.ToString();

            }
            public static string TakeScreenshot(IWebDriver driver, string screenshotFolder = "Screenshots")
            {
                try
                {
                    // Create the screenshot folder if it doesn't exist
                    Directory.CreateDirectory(screenshotFolder);
                    // Generate a unique file name with timestamp
                    string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}.png";
                    string filePath = Path.Combine(screenshotFolder, fileName);
                    ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                    Screenshot screenshot = screenshotDriver.GetScreenshot();
                    screenshot.SaveAsFile(filePath);
                    return filePath;
                }
                catch (Exception ex)
                {
                    // Handle exceptions, e.g., log the error
                    Console.WriteLine($"Error taking screenshot: {ex.Message}");
                    return string.Empty;
                }
            }

            //ExtentReports
            #region reports
            public static ExtentTest test;
             public static ExtentReports Extent;
             // private static object DisplayOrder;

             public static void ExtentReports()
             {
                 //Extent = new ExtentReports(ConstantHelpers.ReportsPath, true);
                 //Extent.LoadConfig(ConstantHelpers.ReportXMLPath);  
             }
            #endregion
        }
     }
}
