using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CrossMail.Tests
{
    [Collection("Dashboard")]
    public class LoginPage
    {
        public static By SignIn = By.XPath("//span[contains(text(),'Sign in')]");
        public static By IdentifierId = By.Id("identifierId");
        public static By IdentifierNext = By.Id("identifierNext");
        public static By ForgetPassword = By.XPath("//span[contains(text(),'Forgot password?')]");
        public static By Password = By.Id("password");
        public static By PasswordNext = By.Id("passwordNext");
        public static By Searchmail = By.XPath("//input[@placeholder='Search mail']");
        public static By ComposeButton = By.XPath("//*[@role='button' and text()='Compose']");
        public static By EmailTemplate = By.XPath("//table//div//div//div//div//table//div[2]//div[1]");
        public static By SubjectBox = By.Name("subjectbox");
        public static By To = By.Name("to");
        public static By Send = By.XPath("//*[@role='button' and text()='Send']");
        public static By DropList = By.XPath("//body/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/table/tbody/tr/td[2]/div[1]");
        public static By BodyText = By.XPath("//body[1]/div[7]/div[3]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[2]/div[3]/div[1]/table[1]/tbody[1]/tr[1]/td[6]/div[1]/div[1]/span[1]");
        public static By SocialLabelElementOne = By.XPath("//body//table//table//table//div//div//div//div[2]");
        public static By SocialLabelElementTwo = By.XPath("//html//body//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div[contains(text(),'Label')]");
        public static By SocialLabelElementThree = By.XPath("//div[contains(text(),'Apply')]");


    }
}
