using BygSpy.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BygSpy.specs.Drivers
{
    public class NewUser
    {
        
            private readonly IWebDriver _driver;

            public NewUser(IWebDriver driver)
            {
                _driver = driver;
            }

            public void NavigateTo()
            {
                _driver.Navigate().GoToUrl("url/to/NewUser/page");
            }

            public void FillOutNewUserForm(User user)
            {
                // Fill out the registration form fields using the provided user data
                _driver.FindElement(By.Id("Name")).SendKeys(user.Name);
            }

            public void SubmitNewUserForm()
            {
                // Submit the registration form
                _driver.FindElement(By.Id("submitButton")).Click();
            }

            public User GetCreatedUser()
            {
                // Retrieve information about the created user from the page
                 return new User { Name = "...",  Email = "..." };
            }

    }
}
