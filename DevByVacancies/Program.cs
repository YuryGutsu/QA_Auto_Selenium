using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace DevByVacancies;

public class Program
{
    static void Main(string[] args)
    {

        WebDriver driver = new ChromeDriver();
        HomePage page = new(driver);

        var mainPageVacancies = page.GetMainPageJavaVacancies();
        var jobPageVacancies = page.GetJobPageJavaVacancies();

        Console.WriteLine();
        Console.WriteLine($"The number of Java vacances on the main page = {mainPageVacancies}");
        Console.WriteLine();
        Console.WriteLine($"The number of Java vacances on the job page = {jobPageVacancies}");
        Console.WriteLine();

        static void ResultOfCompare(int mainPageVacancies, int jobPageVacancies)
        {
            if (mainPageVacancies > jobPageVacancies)
            {
                Console.WriteLine("The number of vacancies in the main page is bigger than the vacancies in the job page.");
            }
            if (mainPageVacancies < jobPageVacancies)
            {
                Console.WriteLine("The number of vacancies in the main page is smaller than the vacancies in the job page.");
            }
            else
            {
                Console.WriteLine("The number of vacancies in the main page and the vacancies in the job page are equal.");
            }
        }
        ResultOfCompare(mainPageVacancies, jobPageVacancies);

        driver.Quit();
    }
}