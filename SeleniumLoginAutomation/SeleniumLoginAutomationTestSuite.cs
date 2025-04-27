using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

#pragma warning disable NUnit1032 // Disables the warning that enforces a specific way to tear down. Our current method of tear down works perfectly fine.

namespace SeleniumLoginAutomation;

public class Tests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless=new"); // Headless mode removes the need for a GUI
        options.AddArgument("--disable-gpu"); // Recommended for headless mode
        options.AddArgument("--window-size=1920,1080"); // Set the window size to avoid issues with headless mode

        driver = new ChromeDriver(options);
    }

    [Test]
    public void TestValidCredentialsLogin()
    {

        // Navigate to the login page
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

        // Wait for 1 second to make sure the page loads
        Thread.Sleep(1000);

        // Find the login form elements and fill them out
        driver.FindElement(By.Id("username")).SendKeys("tomsmith");
        driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");

        // Find the login button and click it (here we have to use the CSS selector to find the button since it has no ID)
        driver.FindElement(By.CssSelector("button[type='submit']")).Click();

        // Wait for 1 second for the login to process
        Thread.Sleep(1000);

        // Check if the flash message element is present after login
        var sucess = driver.FindElement(By.CssSelector(".flash.success"));

        Assert.That(sucess.Displayed, Is.True, "success message not found");

        // Take a screenshot of the page after the test has run
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile("TestValidCredentialsLogin.png");

    }

    [Test]
    public void TestInvalidCredentialsLogin()
    {

        // Navigate to the login page
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

        // Wait for 1 second to make sure the page loads
        Thread.Sleep(1000);

        // Find the login form elements and fill them out
        driver.FindElement(By.Id("username")).SendKeys("tomNOTsmith");
        driver.FindElement(By.Id("password")).SendKeys("SuperInvalidPassword!");

        // Find the login button and click it (here we have to use the CSS selector to find the button since it has no ID)
        driver.FindElement(By.CssSelector("button[type='submit']")).Click();

        // Wait for 1 second for the login to process
        Thread.Sleep(1000);

        // Check if the flash message element is present after login
        var failure = driver.FindElement(By.CssSelector(".flash.error"));

        Assert.That(failure.Displayed, Is.True, "error message not found");

        // Take a screenshot of the page after the test has run
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile("TestInvalidCredentialsLogin.png");

    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
