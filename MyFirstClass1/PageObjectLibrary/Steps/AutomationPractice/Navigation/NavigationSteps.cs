using OpenQA.Selenium;
using PageObjectLibrary.PageObject.AutomationPractice.ContactUs;
using PageObjectLibrary.PageObject.AutomationPractice.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectLibrary.Steps.AutomationPractice.Navigation
{
   public   class NavigationSteps
    {
        IWebDriver webDriver;

        public NavigationSteps(IWebDriver webDriver) {
            this.webDriver = webDriver;
        }

        public ContactUsPage NavigateContactUs() {
            MenuPage menuPagine = new MenuPage(webDriver);
            ContactUsPage contactUsPage = menuPagine.ClickContactUs();
            return contactUsPage;

        }
    }
}
