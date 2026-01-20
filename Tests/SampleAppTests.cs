using CSE2522_Assignment02.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using UIAutomationTests.Pages;

namespace UIAutomationTests.Tests
{
    [TestFixture] // Requirement 
    public class SampleAppTests : TestBase
    {
        [Test]
        [Property("TestName", "TC002_1 - Sample App - Verification of the sample app page")]
        public void TC002_1_VerifyPageElements()
        {
            var sampleAppLink =         driver.FindElement(By.LinkText("Sample App"));
            Assert.That(sampleAppLink, Is.Not.Null, "Sample App link was not found.");
            sampleAppLink.Click();
            var appPage = new SampleAppPage(driver);

            // Verify expected outcome: fields and button are appearing 
            Assert.That(appPage.IsLoginPageDisplayed(), Is.True, "Login elements were not displayed on the page.");
        }

        [Test]
        [Property("TestName", "TC002_2 - Sample App - Verification of a successful login")]
        public void TC002_2_VerifySuccessfulLogin()
        {
            var sampleAppLink = driver.FindElement(By.LinkText("Sample App"));
            Assert.That(sampleAppLink, Is.Not.Null, "Sample App link was not found.");
            sampleAppLink.Click();
            var appPage = new SampleAppPage(driver);

            appPage.Login("JohnDoe", "pwd");
            Assert.That(appPage.GetStatusText(), Does.Contain("Welcome, JohnDoe!"), "Success message did not appear.");
        }

        [Test]
        [Property("TestName", "TC002_3 - Sample App - Verification of an unsuccessful login")]
        public void TC002_3_VerifyUnsuccessfulLogin()
        {
            var sampleAppLink = driver.FindElement(By.LinkText("Sample App"));
            Assert.That(sampleAppLink, Is.Not.Null, "Sample App link was not found.");
            sampleAppLink.Click();
            var appPage = new SampleAppPage(driver);

            appPage.Login("JohnDoe", "wrong_password");
            Assert.That(appPage.GetStatusText(), Is.EqualTo("Invalid username/password"), "Error message mismatch.");
        }
    }
}