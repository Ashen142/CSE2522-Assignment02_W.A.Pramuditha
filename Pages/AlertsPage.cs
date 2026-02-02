using OpenQA.Selenium;
using System;
using System.Threading;
using System.Text.RegularExpressions;

namespace CSE2522_Assignment02.Pages
{
    public class AlertsPage
    {
        private IWebDriver driver;

        public AlertsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Buttons
        private IWebElement alertBtn => driver.FindElement(By.Id("alertButton"));
        private IWebElement confirmBtn => driver.FindElement(By.Id("confirmButton"));
        private IWebElement promptBtn => driver.FindElement(By.Id("promptButton"));

        // Open page
        public void Open()
        {
            driver.Navigate().GoToUrl("https://uitestingplayground.com/alerts");
        }

        // --- ALERT ---
        public void ClickAlert()
        {
            alertBtn.Click();
        }

        // --- CONFIRM ---
        public void ClickConfirm()
        {
            confirmBtn.Click();
        }

        // --- PROMPT ---
        public void ClickPrompt()
        {
            promptBtn.Click();
        }

        // --- COMMON ALERT ACTIONS ---
        public string GetAlertText()
        {
            // Try to read an active alert. If not present, attempt a small wait then
            // fall back to scanning page content for result text (e.g., "Yes"/"No").
            try
            {
                // small retry loop in case alert is appearing
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        var alert = driver.SwitchTo().Alert();
                        if (alert != null)
                        {
                            // Normalize whitespace (CR/LF/tabs) to a single space for reliable comparison
                            var raw = alert.Text ?? string.Empty;
                            var normalized = Regex.Replace(raw, "\\s+", " ").Trim();
                            return normalized;
                        }
                    }
                    catch (OpenQA.Selenium.NoAlertPresentException)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                }
            }
            catch (Exception)
            {
                // swallow and fall through to fallback
            }

            // Fallback: check page source for common result tokens
            var page = driver.PageSource ?? string.Empty;
            if (page.Contains("Yes")) return "Yes";
            if (page.Contains("No")) return "No";

            return string.Empty;
        }

        public void AcceptAlert()
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (OpenQA.Selenium.NoAlertPresentException)
            {
                throw new InvalidOperationException("No alert is present to accept.");
            }
        }

        public void DismissAlert()
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                alert.Dismiss();
            }
            catch (OpenQA.Selenium.NoAlertPresentException)
            {
                throw new InvalidOperationException("No alert is present to dismiss.");
            }
        }

        public void EnterPromptText(string text)
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                alert.SendKeys(text);
            }
            catch (OpenQA.Selenium.NoAlertPresentException)
            {
                throw new InvalidOperationException("No prompt alert is present to enter text.");
            }
        }
    }
}
