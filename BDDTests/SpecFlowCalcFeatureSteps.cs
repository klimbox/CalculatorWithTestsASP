using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace BDDTests
{
    [Binding]
    public class SpecFlowCalcFeatureSteps
    {
        static IWebDriver web = null;
        static Process Server = null;

        [BeforeFeature]
        public static void BeforeFeature()
        {
            // для запуска IISexpress сервиса приложения
            Server = new Process();
            Server.StartInfo.FileName = @"C:\Program Files\IIS Express\iisexpress.exe";
            //Debug.WriteLine(Directory.GetCurrentDirectory());
            //Server.StartInfo.Arguments = @"/path:C:\Users\slyly\Desktop\Calcs\Calcs /port:63818";
            // определение локальной директории проекта с веб-приложением можно/нужно переделать?
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 18) + @"\Calcs";

            Server.StartInfo.Arguments = @"/path:C:\Users\slyly\Desktop\Calcs\Calcs /port:63818";
            Server.Start();

            web = new ChromeDriver();

            web.Navigate().GoToUrl("http://localhost:63818/Home/CalcButtons");
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            web.Navigate().Refresh();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Server.Kill();

            web.Quit();
        }

        [Given(@"Enter first number (.*)")]
        public void GivenEnterFirstNumber(int n1)
        {
            web.FindElement(By.Id("num"+n1)).Click();
        }
        
        [Given(@"Press add")]
        public void GivenPressAdd()
        {
            web.FindElement(By.Id("op_plus")).Click();
        }
        
        [Given(@"Enter second number (.*)")]
        public void GivenEnterSecondNumber(int n2)
        {
            web.FindElement(By.Id("num"+n2)).Click();
        }
        
        [When(@"Press =")]
        public void WhenPress()
        {
            web.FindElement(By.Id("calculate")).Click();
        }

        [Then(@"Expect (.*) on screen")]
        public void ThenExpectOnScreen(int result)
        {
            int res = Convert.ToInt32(web.FindElement(By.Id("answer")).GetAttribute("value"));
            Assert.AreEqual(result, res);
        }

        [Given(@"Press Sub")]
        public void GivenPressSub()
        {
            web.FindElement(By.Id("op_minus")).Click();
        }

        [Given(@"Press mul")]
        public void GivenPressMul()
        {
            web.FindElement(By.Id("op_multiply")).Click();
        }

        [Given(@"Press div")]
        public void GivenPressDiv()
        {
            web.FindElement(By.Id("op_divide")).Click();
        }

    }
}
