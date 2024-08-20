using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MovieCatalogTests.Pages
{
	public class BasePage
	{
		protected IWebDriver driver;
		protected WebDriverWait wait;
		public string BaseUrl => "http://moviecatalog-env.eba-ubyppecf.eu-north-1.elasticbeanstalk.com";

		public BasePage(WebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		}

		public IWebElement FindElement(By by) => driver.FindElement(by);
		public IWebElement LoginLink => driver.FindElement(By.XPath("//*[@id='login']"));
		public IWebElement Login => driver.FindElement(By.XPath("//a[text()='Login']"));
		public IWebElement AddMovie => driver.FindElement(By.XPath("//a[text()='Add Movie']"));
		public IWebElement AllMovies => driver.FindElement(By.XPath("//a[text()='All Movies']"));
		public IWebElement WatchedMovies => driver.FindElement(By.XPath("//a[text()='Watched Movies']"));
		public IWebElement UnwatchedMovies => driver.FindElement(By.XPath("//a[text()='Unwatched Movies']"));
		public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[text()='Logout']"));
	}
}
