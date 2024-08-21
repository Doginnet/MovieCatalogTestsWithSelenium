using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogTests.Pages
{
	public class WatchedMoviesPage : AllMoviesPage
	{
		public WatchedMoviesPage(WebDriver driver) : base(driver)
		{
		}
		/*
		public IReadOnlyCollection<IWebElement> Movies => driver.FindElements(By.XPath("//div[@class='col-lg-4']"));

		public string GetName(IWebElement movie) => movie.FindElement(By.TagName("h2")).Text; //get the name of the element

		public ReadOnlyDictionary<string, IWebElement> GetButtons(IWebElement movie)
		{
			var elements = movie.FindElements(By.XPath(".//div[@class='col-lg-4']/div/a"));
				var dict = elements.ToDictionary(x => x.Text, x => x);
			return new ReadOnlyDictionary<string, IWebElement>(dict); //Remember to create a new read only list and how the ToDictionary works
		}
		*/
	

		
	}
}
