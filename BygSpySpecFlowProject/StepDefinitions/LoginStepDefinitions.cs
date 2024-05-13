using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BygSpySpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private readonly IWebDriver driver;

        public LoginStepDefinitions()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Navigate().GoToUrl("");
        }

        [When(@"I enter my username ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterMyUsernameAndPassword(string username, string password)
        {
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            driver.FindElement(By.Id("loginButton")).Click();
        }

        [Then(@"I should be redirected to the dashboard page")]
        public void ThenIShouldBeRedirectedToTheDashboardPage()
        {
            driver.Url.Should().Be("https://yourwebsite.com/dashboard");
        }

        [Then(@"I should see the welcome message ""(.*)""")]
        public void ThenIShouldSeeTheWelcomeMessage(string expectedMessage)
        {
            driver.FindElement(By.XPath("//h1[contains(text(),'" + expectedMessage + "')]")).Displayed.Should().BeTrue();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
