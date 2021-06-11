using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Exercise1_Automation_C
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=en-US");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        #region FacebookLocators
        //Enable this selector if is necessary
        //By Language = By.XPath("//a[contains(text(),'English (US)')]");
        By FalseElement = By.XPath("//*[@class='holamundo']");
        By CreateNewAccount = By.XPath("//div[@class='_6ltg']//child::a[@role='button']");
        By FirstName = By.Name("firstname");
        By LastName = By.Name("lastname");
        By MobileNumber = By.Name("reg_email__");
        By NewPassword = By.XPath("//input[@name='reg_email__']//following::input[@name='reg_passwd__']");
        By TermsLink = By.Id("terms-link");
        By TermsOfService = By.XPath("//h2[contains(text(), 'Terms')]");
        By ServicesProvided = By.XPath("//a[contains(text(),'1. The services we provide')]");
        By HowServices = By.XPath("//a[contains(text(),'2. How our services are funded')]");
        By Commitments = By.XPath("//a[contains(text(),'3. Your commitments to Facebook and our community')]");
        By Additional = By.XPath("//a[contains(text(),'4. Additional provisions')]");
        By OtherTerms = By.XPath("//a[contains(text(),'5. Other terms and policies that may apply to you')]");
        #endregion
        static void Main(string[] args)
        {
            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUp();
            Browser.Url = "https://www.facebook.com/";
            /*
             * Enable this if necessary
             * element = Browser.FindElement(program.Language);
            program.Click(element);
            */
            #region First Test Case
            try
            {
                String connectText = "Connect with friends and the world around you on Facebook.";
                //String connectText = "Facebook te ayuda a comunicarte y compartir con las personas que forman parte de tu vida.";
                bool textPresent = Browser.PageSource.Contains(connectText);
                //Assert Text.
                Assert.IsTrue(textPresent);
                //False Element
                element = Browser.FindElement(program.FalseElement);
                program.Click(element);
            }catch(NoSuchElementException e)
            {
                Console.WriteLine("Element does not exist.");
            }
            //Click on Create New Account
            element = Browser.FindElement(program.CreateNewAccount);
            program.Click(element);
            //First Name
            element = Browser.FindElement(program.FirstName);
            program.SendText(element, "Juanito");
            //Last Name
            element = Browser.FindElement(program.LastName);
            program.SendText(element, "Perez");
            //Mobile Number
            element = Browser.FindElement(program.MobileNumber);
            program.SendText(element, "9612380995");
            //Password
            element = Browser.FindElement(program.NewPassword);
            program.SendText(element, "1029384756");
            #endregion
            #region Second Test Case
            //Click on Terms
            element = Browser.FindElement(program.TermsLink);
            program.Click(element);
            //Assert is True for Terms of Service
            Browser.SwitchTo().Window(Browser.WindowHandles.Last());
            element = Browser.FindElement(program.TermsOfService);
            Assert.IsTrue(element.Displayed);
            //Assert is Displayed for List of 5 elements
            element = Browser.FindElement(program.ServicesProvided);
            Assert.IsTrue(element.Displayed);
            element = Browser.FindElement(program.HowServices);
            Assert.IsTrue(element.Displayed);
            element = Browser.FindElement(program.Commitments);
            Assert.IsTrue(element.Displayed);
            element = Browser.FindElement(program.Additional);
            Assert.IsTrue(element.Displayed);
            element = Browser.FindElement(program.OtherTerms);
            Assert.IsTrue(element.Displayed);
            #endregion
        }
    }
}
