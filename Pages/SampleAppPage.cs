using OpenQA.Selenium;

namespace UIAutomationTests.Pages
{
    public class SampleAppPage
    {
        private readonly IWebDriver _driver;

        // Locators based on requirements 
        private readonly By _username = By.Name("UserName");
        private readonly By _password = By.Name("Password");
        private readonly By _loginButton = By.Id("login");
        private readonly By _statusMessage = By.Id("loginstatus");

        public SampleAppPage(IWebDriver driver) => _driver = driver;

        // Verification for TC002_1
        public bool IsLoginPageDisplayed()
        {
            return _driver.FindElement(_username).Displayed &&
                   _driver.FindElement(_password).Displayed &&
                   _driver.FindElement(_loginButton).Displayed;
        }

        public void Login(string user, string pass)
        {
            _driver.FindElement(_username).Clear();
            _driver.FindElement(_username).SendKeys(user);
            _driver.FindElement(_password).Clear();
            _driver.FindElement(_password).SendKeys(pass);
            _driver.FindElement(_loginButton).Click();
        }

        public string GetStatusText() => _driver.FindElement(_statusMessage).Text;
    }
}