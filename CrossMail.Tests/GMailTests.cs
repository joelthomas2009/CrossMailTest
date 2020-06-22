//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

namespace CrossMail.Tests
{
    [Collection("Gmail Test Class")]
    public class GMailTests : IDisposable
    {
        public static Dashboard dashboard;
        public static LoginPage loginpage;
        //public static ExtentTest testForReporting;
        //public static ExtentReports extent;
        public IWebDriver _browserDriver;
        public IConfiguration _config;
        public WebDriverWait wait;
        public DateTime dateTime;
        public GMailTests()
        {
            dateTime = DateTime.Now;
            _browserDriver = new ChromeDriver(@"C:\Users\joelt\OneDrive\Documents\CROSSOVER");
            _config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
        }

        public void Dispose()
        {
            _browserDriver.Quit();
        }

        internal void ClickOnElement(IWebElement webElement)
        {
            Actions actions = new Actions(_browserDriver);
            actions.MoveToElement(webElement).Perform();
            actions.MoveToElement(webElement).Click().Perform();
        }
        internal void SelectLabel(string label)
        {
            ClickOnElement(_browserDriver.FindElement(LoginPage.SocialLabelElementOne));
            ClickOnElement(_browserDriver.FindElement(LoginPage.SocialLabelElementTwo));
            ClickOnElement(_browserDriver.FindElement(By.XPath($"//div[contains(text(),'{label}')]//div")));
            ClickOnElement(_browserDriver.FindElement(LoginPage.SocialLabelElementThree));
        }
        internal void WaitForElementPresent(By element)
        {
            wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(20))
            {
                PollingInterval = TimeSpan.FromSeconds(5)
            };
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
        internal void ClickOnSocialTabAndMailVerification()
        {
            ClickOnElement(_browserDriver.FindElement(LoginPage.DropList));
            WaitForElementPresent(By.XPath($"//html//body//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//table//tbody//tr//td//div//div//div//span//span[contains(text(),'{_config["subject"]}')]"));
            //testForReporting.Log(Status.Info, "Verified email subject");
            Thread.Sleep(5000);
            string bodyText = _browserDriver.FindElement(LoginPage.BodyText).Text.Replace("\r\n", "");
            bool status = bodyText.Contains(_config["body"]);
            if (!status)
            {
                throw new Exception("required mail not found!");
            }
            //testForReporting.Log(Status.Info, "Email verification in social tab is completed!");
            //testForReporting.Log(Status.Pass, "GMail Functionality Test Completed.");
        }
        internal void UserLogin()
        {
            //testForReporting.Log(Status.Info, "User login started!");
            _browserDriver.Manage().Window.Maximize();
            _browserDriver.Navigate().GoToUrl(_config["url"]);
            WaitForElementPresent(LoginPage.SignIn);
            var userElement = _browserDriver.FindElement(LoginPage.IdentifierId);
            userElement.SendKeys(_config["username"]);
            ClickOnElement(_browserDriver.FindElement(LoginPage.IdentifierNext));
            WaitForElementPresent(LoginPage.ForgetPassword);
            ClickOnElement(_browserDriver.FindElement(LoginPage.Password));
            _browserDriver.FindElement(By.Name("password")).SendKeys(_config["password"]);
            ClickOnElement(_browserDriver.FindElement(LoginPage.PasswordNext));
            WaitForElementPresent(LoginPage.Searchmail);
            //testForReporting.Log(Status.Info, "User login completed!");
        }
        internal void SendEmail()
        {
            ClickOnElement(_browserDriver.FindElement(LoginPage.ComposeButton));
            WaitForElementPresent(LoginPage.EmailTemplate);
            _browserDriver.SwitchTo().ActiveElement();
            _browserDriver.FindElement(LoginPage.To).Clear();
            _browserDriver.FindElement(LoginPage.To).SendKeys($"{_config["username"]}@gmail.com");
            _browserDriver.FindElement(LoginPage.SubjectBox).SendKeys($"{_config["subject"]}" + dateTime.ToString("MMMM dd"));
            _browserDriver.FindElement(LoginPage.EmailTemplate).SendKeys($"{_config["body"]}" + dateTime.ToString("MMMM dd"));
            SelectLabel(_config["label"]);
            //testForReporting.Log(Status.Info, $"Email label selected as {_config["label"]}");
            ClickOnElement(_browserDriver.FindElement(LoginPage.Send));
            //testForReporting.Log(Status.Info, "Email sent successfully!");
        }
        [Fact]
        public void Should_Send_Email()
        {
            UserLogin();
            SendEmail();
            ClickOnSocialTabAndMailVerification();
        }
    }
}
