using Reqnroll;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowCalculator.Specs.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly IWebDriver driver;

        // Remember that the web application under test should be running and
        // listening on the baseURL before running the selenium test.
        private readonly string baseURL = @"https://localhost:7022/";

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            // We specify that the Chrome browser should run in headless mode
            // (i.e. without a user interface).
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");

            // Notice the Environment.CurrentDirectory parameter. It specifies the
            // path where the driver can find the chromedriver.exe file. It was
            // added automatically to the bin folder by the Nuget package.
            driver = new ChromeDriver(Environment.CurrentDirectory, options);

            driver.Navigate().GoToUrl(baseURL);
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            driver.FindElement(By.Id("FirstNumber")).Click();
            driver.FindElement(By.Id("FirstNumber")).Clear();
            driver.FindElement(By.Id("FirstNumber")).SendKeys(number.ToString());
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            driver.FindElement(By.Id("SecondNumber")).Click();
            driver.FindElement(By.Id("SecondNumber")).Clear();
            driver.FindElement(By.Id("SecondNumber")).SendKeys(number.ToString());
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            driver.FindElement(By.XPath("//input[@value='Calculate']")).Click();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(decimal result)
        {
            string resultString = driver.FindElement(By.Id("result")).Text;
            Assert.Equal(result.ToString(), resultString);
        }    
    }
}