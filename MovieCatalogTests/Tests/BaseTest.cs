using MovieCatalogTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogTests.Tests.Test
{
	public class BaseTest
	{
		public WebDriver driver;
		public LoginPage loginPage; //Here all the pages are declared, and then invoked lower down
		public AddMoviePage addMoviePage;
		public AllMoviesPage allMoviesPage;
		public BasePage basePage;
		public WatchedMoviesPage watchedMoviesPage;
		public EditMoviePage editMoviePage;

		[OneTimeSetUp]
		public void Setup()
		{
			var driverOptions = new ChromeOptions();
			driverOptions.AddUserProfilePreference("profile.password_manager_enabled", false); //not allowing save password pop-ups
			driverOptions.AddArgument("--disable-search-engine-choice-screen");//disables asking for default engine

			driver = new ChromeDriver(driverOptions);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Manage().Window.Maximize(); //maximise to full screen

			loginPage = new LoginPage(driver);
			addMoviePage = new AddMoviePage(driver);
			allMoviesPage = new AllMoviesPage(driver);
			basePage = new BasePage(driver);
			editMoviePage = new EditMoviePage(driver);
			watchedMoviesPage = new WatchedMoviesPage(driver);

			loginPage.OpenPage(); //Login is made in the one time setup, since all tests are for logged users
			loginPage.PerformLogin("test@abv.com", "123456");

		}


		[OneTimeTearDown]
		public void TearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		protected string GenerateRandomName()
		{
			var random = new Random();
			return "Title_" + random.Next(100, 1000);

		}
		protected void PauseAndScroll() //this method needs to be used when elements are out of bounds
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
			System.Threading.Thread.Sleep(1000);
		}
	}
}