using NUnit.Framework;
using System.Threading;
using CSE2522_Assignment02.Base;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class ClientSideDelayTests : TestBase
    {
        [Test(Description = "TC_ClientDelay_01_WaitForText")]
        public void WaitForText()
        {
            Assert.That(driver, Is.Not.Null, "WebDriver instance 'driver' must not be null.");

            var page = new ClientSideDelayPage(driver!);
            page.Open();

            page.ClickButton();

            Thread.Sleep(6000); // simple wait (good enough for assignment)

            Assert.That(page.GetResult(), Is.EqualTo("Data calculated on the client side."));
        }
    }
}
