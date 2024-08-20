using OpenQA.Selenium;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace MovieCatalogTests.Pages
{
	public class AddMoviePage : BasePage
	{
		public AddMoviePage(WebDriver driver) : base(driver)
		{
		}

		public  string Url => BaseUrl + "/Catalog/Add"; //providing the url 

		public IWebElement TitleInput => driver.FindElement(By.Id("form2Example17"));
		public IWebElement DescInput => driver.FindElement(By.XPath("//textarea[@name='Description']"));
		public IWebElement PosterUrl => driver.FindElement(By.XPath("//textarea[@name='PosterUrl']"));
		public IWebElement TrailerLink => driver.FindElement(By.XPath("//textarea[@name='TrailerLink']"));
		public IWebElement MarkedAsWatched => driver.FindElement(By.Id("flexCheckDefault"));
		public IWebElement AddButton => driver.FindElement(By.XPath("//button[text()='Add']"));
		public IWebElement CancelButton => driver.FindElement(By.XPath("//button[text()='Cancel']"));
		public IWebElement ToastMessage => driver.FindElement(By.XPath("//div[@class='toast-message']"));



		public void AssertEmptyTitleError() 
		{
			Assert.That(ToastMessage.Text.Trim(), Is.EqualTo("The Title field is required."), "Message did not appear");
		}public void AssertEmptyDescriptionError()
		{
			
			Assert.That(ToastMessage.Text.Trim(), Is.EqualTo("The Description field is required."), "Message did not appear");
		}

		public void AddMovie(string name, string description)
		{
			TitleInput.SendKeys(name);
			DescInput.SendKeys(description);
		
			
			
			AddButton.Click();
		}
		public void OpenPage() { 
		driver.Navigate().GoToUrl(Url);
			
				}
	}
}
