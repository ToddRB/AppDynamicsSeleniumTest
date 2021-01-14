using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AppDTestProject
{
    [TestClass]
    public class UnitTest1
    {

        public IWebDriver Driver = null;

        [ClassInitialize]
        public static void TestClassInitialize(TestContext testContext)
        {

        }

        [TestInitialize]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            Driver = new ChromeDriver("c:\\temp\\", options);
        }

        [TestCleanup]
        public void Teardown()
        {
            Driver.Close();
        }

        [TestMethod]
        public void ThisWillFailAfterRefreshingPage()
        {
            try
            {
                Driver.Navigate().GoToUrl("https://www.appdynamics.com/");
                var signInButton = Driver.FindElement(By.Id("dropdownMenu7-1"));

                Driver.Navigate().Refresh();
                signInButton.Click();

                Console.WriteLine("I clicked the button!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                Console.WriteLine(" I was unable to click the button =( ");
                Teardown();
            }
        }

        [TestMethod]
        public void ThisWillPassAfterNotRefreshingPage()
        {
            try
            {
                Driver.Navigate().GoToUrl("https://www.appdynamics.com/");
                var signInButton = Driver.FindElement(By.Id("dropdownMenu7-1"));

                signInButton.Click();

                Console.WriteLine("I clicked the button!");
            }
            catch (Exception e)
            {
                Console.WriteLine("I was unable to click the button =(");
                Teardown();
            }
        }
    }
}
