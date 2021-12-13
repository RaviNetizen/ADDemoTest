using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using loginPage.Pages;
using loginPage.Helpers;

namespace loginPage.StepDefinitions
{
    [Binding]
    public class HomePageSteps : IDisposable
    {
        IWebDriver driver = null;
        string baseUrl = "http://the-internet.herokuapp.com/";

        [Given(@"I open the Home Page")]
        public void GivenIOpenTheHomePage()
        {
            driver = Browser.Startbrowser("chrome", baseUrl);
        }

        [Given(@"the page title is displayed")]
        public void ThenThePageTitleIsDisplayed()
        {
            HomePage home = new HomePage(driver);
            home.IAssertHeading();
        }

        [Given(@"I select the Form Authentication on menu")]
        public void WhenSelectTheFormAuthenticationOnMenu()
        {
            HomePage home = new HomePage(driver);
            home.IClickFormAuthentication();
        }

        [Given(@"the Login Page is displayed")]
        public void ThenTheLoginPageIsDisplayed()
        {
            HomePage loginPage = new HomePage(driver);
            loginPage.IAssertLoginPage();
        }
        
        [When(@"I enter (.*)")]
        public void WhenIEnter(string p0)
        {
            HomePage loginPage = new HomePage(driver);
            loginPage.EnterUsername(p0);
        }

        [When(@"I input (.*)")]
        public void WhenIInput(string p0)
        {
            HomePage loginPage = new HomePage(driver);
            loginPage.EnterPassword(p0);
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            HomePage loginPage = new HomePage(driver);
            loginPage.ClickLoginButton();
        }

        [Then(@"the (.*) is displayed")]
        public void ThenTheIsDisplayed(string p0)
        {
            HomePage loginPage = new HomePage(driver);
            loginPage.IAssertMessage(p0);
        }

        [Then(@"I clicked the logout button")]
        public void ThenIClickedTheLogoutButton()
        {

            HomePage loginPage = new HomePage(driver);
            loginPage.IClickLogoutButton();
        }

        [Then(@"I assert a log out message is displayed")]
        public void ThenIAssertALogOutMessageIsDisplayed()
        {

            HomePage loginPage = new HomePage(driver);
            loginPage.IAssertMessage("You logged out of the secure area!");
        }

        [Given(@"I select the Infinite Scroll on menu")]
        public void GivenISelectTheInfiniteScrollOnMenu()
        {
            HomePage loginPage = new HomePage(driver);
            loginPage.IClickInfiniteScroll();
        }

        [Then(@"I am navigated to the infinite scroll page")]
        public void ThenIAmNavigatedToTheInfiniteScrollPage()
        {
            HomePage loginPage = new HomePage(driver);
            loginPage.scrollTwice();
        }

        [Given(@"I select the Key Presses on menu")]
        public void WhenISelectTheKeyPressesonOnMenu()
        {
            HomePage loginPage = new HomePage(driver);
            loginPage.IClickKeyPresses();
        }

        [When(@"I press (.*)")]
        public void WhenIPress(string p0)
        {
            HomePage loginPage = new HomePage(driver);
            loginPage.InputKeyPress(p0);
        }

       [Then(@"You entered: (.*) is displayed")]
       public void ThenYouEnteredIsDisplayed(string p0)
       {
            HomePage loginPage = new HomePage(driver);
            loginPage.IAssertTextMessage(p0);
        }
        
        public void Dispose()
        {
            if (driver != null) 
            {
                driver.Dispose();
                driver = null;
            }
        }
    }

}
