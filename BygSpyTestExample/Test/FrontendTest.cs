using BygSpyTestExample.Model;
using BygSpyTestExample.Services;
using FluentAssertions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Xunit;

namespace BygSpyTestExample
{
    public class FrontendTest
    {
        [Fact]
        public void TestLogin()
        {
            // Set up WebDriver (Chrome in this example)
            using (var driver = new ChromeDriver())
            {
                // Navigate to your Blazor app
                driver.Navigate().GoToUrl("https://localhost:7289/");

                // Find the email input field and enter the email
                var emailField = driver.FindElement(By.Id("email"));
                emailField.SendKeys("esb@mail.com");

                // Find the password input field and enter the password
                var passwordField = driver.FindElement(By.Id("password"));
                passwordField.SendKeys("5678");

                // Find the login button and click it
                var loginButton = driver.FindElement(By.Id("login"));
                loginButton.Click();

                // Optionally, verify the navigation or check for successful login
                // For example, you can check if the navigation to the index page happened
                Assert.True(driver.Url.Contains("/Index"));

                // Optionally, you can verify some element on the new page to confirm successful login
                // var element = driver.FindElement(By.Id("someElementId"));
                // Assert.Equal("Expected Text", element.Text);
            }
        }
    }
}
