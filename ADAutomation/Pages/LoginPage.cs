using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using loginPage.Helpers;
using System.Threading;
using NUnit.Framework;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace loginPage.Pages
{
    class HomePage
    {
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _driver;
    
        //initiating chrome driver
        public HomePage(IWebDriver driver)
        {
            //PageFactory.InitElements(driver, this);
            this._driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
        }

        //UI Elements 
        private IWebElement Heading => _driver.FindElement(By.ClassName("heading"));
 
        private IWebElement Link => _driver.FindElement(By.LinkText("Form Authentication"));

        private IWebElement ScrollLink => _driver.FindElement(By.CssSelector("[href='/infinite_scroll']"));

        private IWebElement KeyPressesLink => _driver.FindElement(By.CssSelector("[href='/key_presses']")); 

        private IWebElement LoginPage => _driver.FindElement(By.ClassName("example"));

        private IWebElement TxtUserName => _driver.FindElement(By.CssSelector("#username"));
         
        private IWebElement TxtPassword => _driver.FindElement(By.CssSelector("#password"));
    
        private IWebElement BtnLogin => _driver.FindElement(By.CssSelector(".fa.fa-2x.fa-sign-in"));

        private IWebElement MessageField => _driver.FindElement(By.Id("flash"));

        private IWebElement MessageTextField => _driver.FindElement(By.Id("result"));

        private IWebElement LogoutButton => _driver.FindElement(By.LinkText("Logout")); 

        private IWebElement InfiniteTitle => _driver.FindElement(By.XPath("//*[@id='content']/div/h3")); 

        //page heading check
        public void IAssertHeading()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("heading")));
            Assert.IsTrue(Heading.Displayed);
            Assert.AreEqual(_driver.Title, "The Internet");
        }

        //Navigating to the form authentication page
        public void IClickFormAuthentication()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Link));
            Link.Click();
        }

        //Navigating to the infinite scroll page
        public void IClickInfiniteScroll()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ScrollLink));
            ScrollLink.Click();
        }

        //Navigating to the key presses page
        public void IClickKeyPresses()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(KeyPressesLink));
            KeyPressesLink.Click();
        }

        //Scrolling dowm twice scroll back to top in the infinite sroll page  
        public void scrollTwice()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("http://the-internet.herokuapp.com/infinite_scroll"));
            Thread.Sleep(5000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollBy(0, 200)");
            js.ExecuteScript("window.scrollBy(0, 100)");
            Thread.Sleep(2000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", InfiniteTitle);
        }

        //login page display check  
        public void IAssertLoginPage()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(TxtUserName));
            Assert.AreEqual(_driver.Title, "Login Page");
        }

        //entering username 
        public void EnterUsername(string userName)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(TxtUserName));
            TxtUserName.SendKeys(userName);
        }

        //entering password 
        public void EnterPassword(string pword)
        {
            TxtPassword.SendKeys(pword);
        }

        //clicking login button
        public void ClickLoginButton()
        {
            BtnLogin.Submit();
        }

        //checking  login page messages
        public void IAssertMessage(string msg)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("flash")));
            Assert.IsTrue(MessageField.Text.Contains(msg));
        }

        //clicking logout button
        public void IClickLogoutButton()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(LogoutButton));
            LogoutButton.Click();
        }

        //key presses page
        public void IAssertKeyPressesPage()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='content']/div/h3")));
            Assert.AreEqual(_driver.Title, "Key Presses");
        }
        
        //entering key presses
        public void InputKeyPress(string key)
        {
            Actions act = new Actions(_driver);
            act.SendKeys(key).Perform();
            Thread.Sleep(1000);
        }

        //checking key press output
        public void IAssertTextMessage(string msg)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("result")));
            Assert.IsTrue(MessageTextField.Text.Contains(msg));
        }
    }
}
