using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
		public IWebElement LastEditButton => AllMovies.Last().FindElement(By.XPath(".//a[text()='Edit']")); //i would do this with a cycle
		public IWebElement LastDeleteButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-danger']")); 
		public IWebElement LastMarkButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-info']"));



		/// <summary>
		/// Here are the additional methods
		/// </summary>
		public IReadOnlyCollection<IWebElement> WatchedMovies => driver.FindElements(By.XPath("//div[@class='col-lg-4']"));

		public string GetName(IWebElement movie) => movie.FindElement(By.TagName("h2")).Text; //get the name of the element

		public ReadOnlyDictionary<string, IWebElement> GetButtons(IWebElement movie)
		{
			var elements = movie.FindElements(By.XPath(".//div[@class='col-lg-4']/div/a"));
			var dict = elements.ToDictionary(x => x.Text, x => x);
			return new ReadOnlyDictionary<string, IWebElement>(dict); //Remember to create a new read only list and how the ToDictionary works
		}


		public void NavigateToLastPage()
		{
			PageIndxes.Last().Click();
		}
	}
}
