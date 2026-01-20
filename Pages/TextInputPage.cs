using OpenQA.Selenium;

namespace CSE2522_Assignment02.Pages
{
    public class TextInputPage
    {
        IWebDriver driver;

        public TextInputPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement inputBox => driver.FindElement(By.Id("newButtonName"));
        IWebElement button => driver.FindElement(By.Id("updatingButton"));

        public void Open()
        {
            driver.Navigate().GoToUrl("https://uitestingplayground.com/textinput");
        }

        public void EnterText(string text)
        {
            inputBox.Clear();
            inputBox.SendKeys(text);
        }

        public void ClickButton()
        {
            button.Click();
        }

        public string GetButtonText()
        {
            return button.Text;
        }
    }
}
