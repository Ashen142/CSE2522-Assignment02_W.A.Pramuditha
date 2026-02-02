using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSE2522_Assignment02.Pages
{
    public class ClientSideDelayPage
    {
        IWebDriver driver;

        public ClientSideDelayPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement button => driver.FindElement(By.Id("ajaxButton"));
        IWebElement label => driver.FindElement(By.ClassName("bg-success"));

        public void Open()
        {
            driver.Navigate().GoToUrl("https://uitestingplayground.com/clientdelay");
        }

        public void ClickButton()
        {
            button.Click();
        }

        public string GetResult()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(By.ClassName("bg-success"));
                    return el.Displayed && !string.IsNullOrEmpty(el.Text);
                }
                catch
                {
                    return false;
                }
            });

            return driver.FindElement(By.ClassName("bg-success")).Text;
        }
    }
}
