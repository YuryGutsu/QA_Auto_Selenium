using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DevByVacancies;

public class HomePage
{
    IWebDriver _driver;

    IWebElement _javaVacanciesElement;
    IWebElement _javaJobPageVacanciesElement;
    IWebElement _javaMainPageVacanciesElement;

    const string JAVA_MAIN_PAGE_VACANCIES_XPATH = "//a[contains(text(), 'Java')]/following-sibling::div";
    const string JAVA_JOB_Page_VACANCIES_XPATH = "//h1[@class='vacancies-list__header-title']";
    const string JAVA_VACANCIES_XPATH =
        "//a[@href='https://jobs.dev.by/?filter[specialization_title]=Java'][@title= 'Java']";

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
        _driver.Url = "https://devby.io/";
        _driver.Manage().Window.Maximize();
    }

    public int GetMainPageJavaVacancies()
    {
        _javaMainPageVacanciesElement = WaitUtil.FindWithDelay(_driver, JAVA_MAIN_PAGE_VACANCIES_XPATH);
        string[] vacancies = _javaMainPageVacanciesElement.Text.Split(' ');
        return int.Parse(vacancies[0]);
    }

    public int GetJobPageJavaVacancies()
    {
        _javaJobPageVacanciesElement = _driver.FindElement(By.XPath(JAVA_VACANCIES_XPATH));
        IfElementNotInVision(_javaJobPageVacanciesElement);
        var windowHandles = _driver.WindowHandles;
        _driver.SwitchTo().Window(windowHandles[1]);

        _javaVacanciesElement = WaitUtil.FindWithDelay(_driver, JAVA_JOB_Page_VACANCIES_XPATH);

        string[] javaVacancies = _javaVacanciesElement.Text.Split(" ");
        return int.Parse(javaVacancies[0]);
    }

    public void IfElementNotInVision(IWebElement element)
    {
        Actions action = new Actions(_driver);
        action.MoveToElement(element);
        action.Perform();
        element.Click();
    }
}
