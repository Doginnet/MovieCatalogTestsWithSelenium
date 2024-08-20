using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogTests.Pages
{
	public class AllMoviesPage : BasePage
	{
		public AllMoviesPage(WebDriver driver) : base(driver)
		{
		}

		public string Url => BaseUrl + "/Catalog/All#all";

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(Url);
		}
		public IReadOnlyCollection<IWebElement> PageIndxes => driver.FindElements(By.XPath("//a[@class='page-link']")); // property of collections
		public IReadOnlyCollection<IWebElement> AllMovies => driver.FindElements(By.XPath("//div[@class='col-lg-4']"));

		public IWebElement LastMovieTitle => AllMovies.Last().FindElement(By.XPath(".//"));
		public IWebElement LastEditButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn tbn-outline-success']")); //i would do this with a cycle
		public IWebElement LastDeleteButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-danger']")); 
		public IWebElement LastMarkButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-info']")); 

		public void NavigateToLastPage()
		{
			PageIndxes.Last().Click();
		}
	}
}
