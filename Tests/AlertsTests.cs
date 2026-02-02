using NUnit.Framework;
using CSE2522_Assignment02.Base;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class AlertsTests : TestBase
    {
        // TC004_1 - Alerts - Verification of the Alerts page
        [Test, Property("TestName", "TC004_1_Alerts_Page_Verification")]
        public void VerifyAlertsPage()
        {
            Assert.That(driver, Is.Not.Null, "WebDriver instance 'driver' must not be null.");
            var page = new AlertsPage(driver!);
            page.Open();

            Assert.That(driver.PageSource, Does.Contain("Alerts"),
                "Alerts page is not displayed properly");
        }

        // TC004_2 - Alerts - Verification of the Alert text
        [Test, Property("TestName", "TC004_2_Alert_Text_Verification")]
        public void VerifySimpleAlertText()
        {
            Assert.That(driver, Is.Not.Null, "WebDriver instance 'driver' must not be null.");
            var page = new AlertsPage(driver!);
            page.Open();

            page.ClickAlert();

            string alertText = page.GetAlertText();
            Assert.That(alertText, Is.EqualTo("Today is a working day or less likely a holiday"),
                "Alert text does not match");

            page.AcceptAlert();
        }

        // TC004_3 - Alerts - Verification of the Confirm alert (ACCEPT)
        [Test, Property("TestName", "TC004_3_Confirm_Alert_Accept")]
        public void VerifyConfirmAlertAccept()
        {
            Assert.That(driver, Is.Not.Null, "WebDriver instance 'driver' must not be null.");
            var page = new AlertsPage(driver!);
            page.Open();

            page.ClickConfirm();

            var confirmText = page.GetAlertText();
            Assert.That(confirmText, Is.EqualTo("Today is Friday. Do you agree?").IgnoreCase,
                "Confirm alert text mismatch");

            page.AcceptAlert();

            Assert.That(page.GetAlertText(), Is.EqualTo("Yes"),
                "Result alert text should be Yes");

            page.AcceptAlert();
        }

        // TC004_3 - Alerts - Verification of the Confirm alert (DECLINE)
        [Test, Property("TestName", "TC004_3_Confirm_Alert_Decline")]
        public void VerifyConfirmAlertDecline()
        {
            Assert.That(driver, Is.Not.Null, "WebDriver instance 'driver' must not be null.");
            var page = new AlertsPage(driver!);
            page.Open();

            page.ClickConfirm();

            var confirmText = page.GetAlertText();
            Assert.That(confirmText, Is.EqualTo("Today is Friday. Do you agree?").IgnoreCase,
                "Confirm alert text mismatch");

            page.DismissAlert();

            Assert.That(page.GetAlertText(), Is.EqualTo("No"),
                "Result alert text should be No");

            page.AcceptAlert();
        }

        // TC004_4 - Alerts - Verification of the Prompt alert (ACCEPT)
        [Test, Property("TestName", "TC004_4_Prompt_Accept")]
        public void VerifyPromptAccept()
        {
            Assert.That(driver, Is.Not.Null, "WebDriver instance 'driver' must not be null.");
            var page = new AlertsPage(driver!);
            page.Open();

            page.ClickPrompt();
            page.EnterPromptText("Ashen");
            page.AcceptAlert();

            Assert.That(page.GetAlertText(), Is.EqualTo("User value: Ashen"),
                "Prompt result text mismatch");

            page.AcceptAlert();
        }

        // TC004_4 - Alerts - Verification of the Prompt alert (DECLINE)
        [Test, Property("TestName", "TC004_4_Prompt_Decline")]
        public void VerifyPromptDecline()
        {
            Assert.That(driver, Is.Not.Null, "WebDriver instance 'driver' must not be null.");
            var page = new AlertsPage(driver!);
            page.Open();

            page.ClickPrompt();
            page.EnterPromptText("Ashen");
            page.DismissAlert();

            Assert.That(page.GetAlertText(), Is.EqualTo("User value: No answer").IgnoreCase,
                "Prompt decline result text mismatch");

            page.AcceptAlert();
        }
    }
}
