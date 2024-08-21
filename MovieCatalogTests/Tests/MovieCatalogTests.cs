namespace MovieCatalogTests.Tests

{
	using global::MovieCatalogTests.Tests.Test;


	using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    public class MovieCatalogTests : BaseTest
    {

		public string LastCreatedTitle { get; set; }
		public string LastUpdatedTitle { get; set;}

		[Test, Order(1)]
        public void AddMovieWithoutTitle()
        {
            addMoviePage.OpenPage();//opening the page from here
            addMoviePage.TitleInput.Clear();
			PauseAndScroll();
			addMoviePage.AddButton.Click();
            addMoviePage.AssertEmptyTitleError();//here is the assertion

		}
		[Test, Order(2)]
		public void AddMovieWithoutDescription()
		{
            var randomTitle =  GenerateRandomName();
			addMoviePage.OpenPage();//opening the page from here
            addMoviePage.TitleInput.SendKeys(randomTitle);
			addMoviePage.DescInput.Clear();
			PauseAndScroll();
			addMoviePage.AddButton.Click();
        
			addMoviePage.AssertEmptyDescriptionError();//here is the assertion

		}
		[Test, Order(3)]
		public void AddMovieWithTitleAndDescription()
		{
			
			var randomTitle = GenerateRandomName();
			addMoviePage.OpenPage();//opening the page from here
			 PauseAndScroll(); //dedicated method to sleep and scroll down when needed, initialized in BaseTest
			addMoviePage.AddMovie(randomTitle, "Description for" + randomTitle);
			LastCreatedTitle = randomTitle; // Storing the created title in a variable
		}
		[Test, Order(4)]
		public void EditLastCreatedMovie()
		{
			allMoviesPage.OpenPage();
			allMoviesPage.NavigateToLastPage();
			
			if (allMoviesPage.AllMovies.Count > 0)
			{ Console.WriteLine("There are movies on the page"); }
			else {
				throw new ArgumentException("No movies on this page");
			}
			
			allMoviesPage.LastEditButton.Click();
			var genericName = GenerateRandomName();
			var wait= new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			PauseAndScroll();
			IWebElement element = wait.Until(drv => drv.FindElement(By.Name("Title")).Displayed ? drv.FindElement(By.Name("Title")) : null);
		
			//Assert.That(element.Text, Is.EqualTo(LastCreatedTitle));
			//Edit a page
			editMoviePage.EditMovie(genericName);
			LastUpdatedTitle = "Edited" + genericName;

			allMoviesPage.OpenPage();
			allMoviesPage.NavigateToLastPage();
			var lastMovie = allMoviesPage.AllMovies.Last();
			var movieName = watchedMoviesPage.GetName(lastMovie);
			Assert.That(movieName.ToLower(), Is.EqualTo(LastUpdatedTitle.ToLower()));
;		}
		[Test, Order(7)]
		public void DeleteLastCreatedMovie()
		{
			allMoviesPage.OpenPage();
			allMoviesPage.NavigateToLastPage();
			allMoviesPage.LastDeleteButton.Click();
			PauseAndScroll();
			driver.FindElement(By.XPath("//*[@class='btn warning']")).Click(); //Delete confirmation button
			//Add confirmation
			allMoviesPage.NavigateToLastPage();
			var moviesOnPage = allMoviesPage.AllMovies;

			Assert.That(moviesOnPage.Last().Text.ToLower(), Is.Not.EqualTo(LastUpdatedTitle.ToLower()));//Comparing the name of the last movie from the collection with the stored variable

		}
		[Test, Order(5)]
		public void MarkLastCreatedMovie()
		{

			allMoviesPage.OpenPage();
			allMoviesPage.NavigateToLastPage();
			allMoviesPage.LastMarkButton.Click();
			//Assert
			basePage.WatchedMovies.Click();
			try
			{
				if (allMoviesPage.PageIndxes.Count > 1)
				{
					allMoviesPage.NavigateToLastPage();
				}

			var movie = driver.FindElement(By.XPath($"//*[text()='{LastUpdatedTitle}"));
			var title = watchedMoviesPage.GetName(movie);
				Assert.That(allMoviesPage.AllMovies.Count > 0, Is.True);
				Assert.That(title, Is.EqualTo(LastUpdatedTitle));

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}