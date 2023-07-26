using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SpecflowSelenium.Utils;
using SwagLabAssessment2.Drivers;
using SwagLabAssessment2.Pages;
using System.Configuration;


namespace SwagLabAssessment2.StepDefinitions
{
   
    [Binding]
    public sealed class SwagLabsStepDefinitions:DriverClass
    {
        private readonly ConfigurationReader configuration;
        public SwagLabsStepDefinitions()
        {
            configuration = new ConfigurationReader("C:\\ZLenovo\\Asoftware\\SpecflowSelenium\\SpecflowSelenium\\configuration.properties");
        }


        readonly SwagLabPage swagLab = new();
    
        
        [Given(@"open the website")]
        public void GivenOpenTheWebsite()
        {
            string baseUrl = configuration.GetValue("app.url");
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(baseUrl);
            Driver.Manage().Window.Maximize();
        }



        [Given(@"enter your username ""([^""]*)""")]
        public void GivenEnterYourUsername(string username)
        {
            swagLab.typeInTheUsername(username);

        }

        [Given(@"enter the password ""([^""]*)""")]
        public void GivenEnterThePassword(string password)
        {
            swagLab.typeInThePassword(password);
        }

        [Then(@"verify that the user is not able to log in the ""([^""]*)""")]
        public void ThenVerifyThatTheUser›sNotAbleToLog›nThe(string webpage)
        {
            if (webpage.Equals("swaglabs"))
            {
                String expectedUrl = "https://www.saucedemo.com/inventory.html";
                String actualUrl = Driver.Url;

                Assert.IsFalse(actualUrl.Equals(expectedUrl));
            }

        }

        [Then(@"just wait a second")]
        public void ThenJustWaitASecond()
        {
            Thread.Sleep(3000);
        }





        [Then(@"verify that the product is not available in the cart")]
        public void ThenVerifyThatTheProduct›sNotAvailable›nTheCart()
        {
            swagLab.AssertThatIsNotVisible();
        }

        [Then(@"select an option of sorting product by ""(.*)""")]
        public void ThenSelectAnOptionOfSortingProductBy(string value)
        {
            swagLab.selectAnOption(value);
        }




        [Then(@"click the ""([^""]*)""")]
        public void ThenClickThe(string element)
        {
            
            swagLab.clicking(element);
        }

        [Then(@"verify the step ""([^""]*)""")]
        public void ThenVerifyTheStep(string step)
        {
            if(step.Equals("loggedOut"))
            {
                swagLab.clicking(step);
                Assert.That(swagLab.loginBtn.Displayed);
            }
                

            if (step.Equals("about"))
            {
                swagLab.clicking(step);
                String url = Driver.Url;
                Assert.That(url.Contains(step));
            }
            if (step.Equals("loggedIn"))
            {
                String expectedUrl = "https://www.saucedemo.com/inventory.html";
                String actualUrl = Driver.Url;

                Assert.IsTrue(actualUrl.Equals(expectedUrl));
            }

            if (step.Equals("za"))
            {
                swagLab.sortingProducts(step);
            }
               
            if (step.Equals("lohi"))
            {
                swagLab.sortingProducts(step);
            }
                
            if (step.Equals("hilo"))
            {
                swagLab.sortingProducts(step);
            }

        }













    }
}