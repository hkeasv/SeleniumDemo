using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest;

public class CalculatorTest : IDisposable
{
    private readonly IWebDriver driver;

    // Remember that the web application under test should be running and
    // listening on the baseURL before running the selenium test.
    private readonly string baseURL = @"https://localhost:7022/";

    public CalculatorTest()
    {
        // We specify that the Chrome browser should run in headless mode
        // (i.e. without a user interface).
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("headless");

        // Notice the Environment.CurrentDirectory parameter. It specifies the
        // path where the driver can find the chromedriver.exe file. It was
        // added automatically to the bin folder by the Nuget package.
        driver = new ChromeDriver(Environment.CurrentDirectory,options);
    }

    public void Dispose()
    {
        driver.Quit();
    }

    [Fact]
    public void Add_30_and_20_Expect_50()
    {
        driver.Navigate().GoToUrl(baseURL);
        driver.FindElement(By.Id("FirstNumber")).Click();
        driver.FindElement(By.Id("FirstNumber")).Clear();
        driver.FindElement(By.Id("FirstNumber")).SendKeys("30");

        driver.FindElement(By.Id("SecondNumber")).Click();
        driver.FindElement(By.Id("SecondNumber")).Clear();
        driver.FindElement(By.Id("SecondNumber")).SendKeys("20");

        driver.FindElement(By.XPath("//input[@value='Calculate']")).Click();
        Assert.Equal("50", driver.FindElement(By.Id("result")).Text);
    }

}
