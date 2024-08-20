using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogTests.Pages
{

	public class LoginPage : BasePage
	{
		public LoginPage(WebDriver driver) : base(driver)
		{
		}
		public string Url => BaseUrl + "/User/Login";

		public IWebElement EmailInput
		{
			get =>  driver.FindElement(By.Id("form2Example17"));
			}
		public IWebElement PasswordInput => driver.FindElement(By.Id("form2Example27")); // two different ways of doing the same thing
		public IWebElement LoginButton => driver.FindElement(By.XPath("//button[text()='Login']")); 

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(Url);
		}

		public void PerformLogin(string email, string password)
		{
			EmailInput.Clear();
			PasswordInput.Clear();
			EmailInput.SendKeys(email);
			PasswordInput.SendKeys(password);
			LoginButton.Click();
		}
	}
}
