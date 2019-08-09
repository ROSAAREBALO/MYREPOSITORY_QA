using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectLibrary.PageObject.AutomationPractice.ContactUs
{
   public  class ContactUsPage
    {
        IWebDriver webDriver;

        public ContactUsPage(IWebDriver webDriver) {

            this.webDriver = webDriver;
        }

        public enum Options {
            ByText,
            ByValue,
            ByIndex
        }

        public void SelectHeadingComboBox(Options option, string value) {
            IWebElement subjectHeading = webDriver.FindElement(By.Id("id_contact"));
            SelectElement subjectHeadingComboBox = new SelectElement(subjectHeading);
            switch(option) {
                case Options.ByText:
                    subjectHeadingComboBox.SelectByText(value);
                    break;
                case Options.ByValue:
                    subjectHeadingComboBox.SelectByValue(value);
                    break;
                case Options.ByIndex:
                    subjectHeadingComboBox.SelectByIndex(int.Parse(value));
                    break;
            }

        }

     /*   public void FillContactUsForm(Options byText, string v1, string v2, string v3, string v4)
        {
            throw new NotImplementedException();
        }*/

        public void SetEmailAddress(string email) {
            IWebElement emailAddressInput = webDriver.FindElement(By.Name("from"));
            emailAddressInput.SendKeys(email);
             }

        public void SetOrderReference(string orderReference) {
            IWebElement orderReferenceInput = webDriver.FindElement(By.Name("id_order"));
            orderReferenceInput.SendKeys(orderReference);

        }

        public void SetAttachFile(string filePath) {
            IWebElement attachFile = webDriver.FindElement(By.Id("fileUpload"));
            attachFile.SendKeys(filePath);
        }

        public void SetMessage(string message) {
            IWebElement messageInput = webDriver.FindElement(By.Id("message"));
            messageInput.SendKeys(message);
        }

        public void ClickSend() {
            IWebElement SendButton = webDriver.FindElement(By.Id("submitMessage"));
            SendButton.Click();
        }

        // public void FillContactUsForm(Options option, string value, string email, string orderReference, string filePath, string message)
        public void FillContactUsForm(Options option,string value, string email, string orderReference, string filePath, string message) {
            SelectHeadingComboBox(option,value);
            SetEmailAddress(email);
            SetOrderReference(orderReference);
            SetAttachFile(filePath);
            SetMessage(message);
            ClickSend();
        }

        public string GetConfirmationMessage() {
            IWebElement confirmatioLabel = webDriver.FindElement(By.XPath("//p[@class='alert alert-success']"));
            string actualMessage = confirmatioLabel.Text;
            return actualMessage;
            }

          

    }
}
