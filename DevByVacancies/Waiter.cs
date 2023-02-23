using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DevByVacancies;

public static class WaitUtil
{
    public static IWebElement FindWithDelay(IWebDriver _driver, string xpath, int seconds = 5)
    {
        return new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds))
        .Until(_driver => _driver.FindElement(By.XPath(xpath)));
    }
}
