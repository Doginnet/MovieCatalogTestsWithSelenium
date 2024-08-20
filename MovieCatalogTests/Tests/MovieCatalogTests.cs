namespace MovieCatalogTests.Tests

{
	using global::MovieCatalogTests.Tests.Test;
	//using MovieCatalogTests.Tests.Test;
	using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    public class MovieCatalogTests : BaseTest
    {
      
        

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

		}
	}
}