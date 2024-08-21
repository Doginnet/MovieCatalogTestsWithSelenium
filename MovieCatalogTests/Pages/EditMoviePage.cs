using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogTests.Pages
{
	public class EditMoviePage : AddMoviePage

	{
		public EditMoviePage(WebDriver driver) : base(driver)
		{
		} 
		  
		public IWebElement Title => driver.FindElement(By.XPath("//*[@id=\"form2Example17\"]"));
		public IWebElement Description => driver.FindElement(By.Name("Description"));
		public IWebElement EditBtn => driver.FindElement(By.XPath("//button[text()='Edit']"));
		
		//Methods
		public void OpenPage()
		{

		}
		public void EditMovie(string genericName)
		{
			Title.Clear();
			Title.SendKeys( "Edited" + genericName);
			EditBtn.Click();
		}
	}
}
