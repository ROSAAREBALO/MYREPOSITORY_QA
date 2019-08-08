using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstClass1
{
    [TestClass]
    public class Class1
    {
        IWebDriver webDriver;

        public Class1(){

            webDriver = new ChromeDriver(@"C:\selenumWebDriver");
        }

        [TestMethod]
        public void MyFirstTest() {
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            //captura contact-us-button
            IWebElement contactUsButton = webDriver.FindElement(By.Id("contact-link"));
            contactUsButton.Click();

            //capture subjet heading combo box
           IWebElement subjectHeading = webDriver.FindElement(By.Id("id_contact"));
           SelectElement subjectHeadingComboBox = new SelectElement(subjectHeading);
           subjectHeadingComboBox.SelectByText("Customer service");

            //capture email address input
            IWebElement emailAddressInput = webDriver.FindElement(By.Name("from"));
            emailAddressInput.SendKeys("daniel.terceros.b@gmail.com");

            //id-order
            IWebElement orderReferenceInput = webDriver.FindElement(By.Name("id_order"));
            orderReferenceInput.SendKeys("1234");

            //capture attach file
            IWebElement attachFile = webDriver.FindElement(By.Id("fileUpload"));
            attachFile.SendKeys(@"D:\prueba\FilePlano.txt");
            //  attachFile.SendKeys(@"C:\Users\AREBALO\Desktop\CROQUIS.pdf");
            // attachFile.SendKeys(@"D:\prueba\CertificadoNoRegistro.pdf");

            //capture menssage
            IWebElement messageInput = webDriver.FindElement(By.Id("message"));
            messageInput.SendKeys("Test messaggeee");

            //capture send
            IWebElement SendButton = webDriver.FindElement(By.Id("submitMessage"));
            SendButton.Click();

            //capture text envio confirmado
            // Your message has been successfully sent to our team.
            //  p[class='alert alert-success']

            
            IWebElement confirmatioLabel = webDriver.FindElement(By.XPath("//p[@class='alert alert-success']"));
            string actualMessage = confirmatioLabel.Text;
            string expectedMessage = "Your message has been successfully sent to our team.";

            Assert.AreEqual(expectedMessage, actualMessage);


        }
        
    }
}
