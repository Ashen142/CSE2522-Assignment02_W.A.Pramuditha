using NUnit.Framework;
using CSE2522_Assignment02.Base;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class TextInputTests : TestBase
    {
        [Test(Description = "TC_TextInput_01_ChangeButtonText")]
        public void ChangeButtonText()
        {
            Assert.That(driver, Is.Not.Null, "WebDriver instance 'driver' must not be null.");

            var page = new TextInputPage(driver!);
            page.Open();

            page.EnterText("My Button");
            page.ClickButton();

            Assert.That(page.GetButtonText(), Is.EqualTo("My Button"));
        }
    }
}
