using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Selenium_Automation
{
    class Program
    {
        // Create a reference to google chrome
        IWebDriver driver = new ChromeDriver();

        static void Main(string[] args)
        {

        }

        [SetUp]
        public void Initialize()
        {
            // Go to Swag Labs page
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Make the browser full screen
            driver.Manage().Window.Maximize();
        }

        [Test] //TSCS1
        public void LoginTest()
        {
            // Fills in the "Username" field
            IWebElement UsernameField = driver.FindElement(By.Id("user-name"));
            UsernameField.SendKeys("standard_user");

            // Fills in the "Password" field
            IWebElement PasswordField = driver.FindElement(By.Id("password"));
            PasswordField.SendKeys("secret_sauce");

            // Click the "Login" button
            IWebElement LoginButton = driver.FindElement(By.Id("login-button"));
            LoginButton.Click();
        }

        [Test] //TSCS2
        public void FailedToLoginTest()
        {
            // Fills in the "Username" field
            IWebElement UsernameField = driver.FindElement(By.Id("user-name"));
            UsernameField.SendKeys("random_user");

            // Fills in the "Password" field
            IWebElement PasswordField = driver.FindElement(By.Id("password"));
            PasswordField.SendKeys("secret_sauce");

            // Click the "Login" button
            IWebElement LoginButton = driver.FindElement(By.Id("login-button"));
            LoginButton.Click();

            // Check the error message
            IWebElement ErrorMessage = driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]"));
            string ActualErrorMessageText = ErrorMessage.Text;
            string ExpectedErrorMessageText = "Epic sadface: Username and password do not match any user in this service";
            Assert.That(Equals(ActualErrorMessageText, ExpectedErrorMessageText));

            // Print the error message
            Console.WriteLine("Actual message text is: " + ActualErrorMessageText);
            Console.WriteLine("Expected message text is: " + ExpectedErrorMessageText);
        }

        [Test] //TSCS3
        public void AddItemToCart()
        {
            // Call the "LoginTest" method
            LoginTest();

            // Click the "Add to cart" button
            IWebElement AddToCart = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            AddToCart.Click();
        }

        [Test] //TSCS4
        public void CancelItemToCart()
        {
            // Call the "AddItemToCart" method
            AddItemToCart();

            // Cancel the item to saved in cart
            IWebElement CancelToCart = driver.FindElement(By.Id("remove-sauce-labs-backpack"));
            CancelToCart.Click();
        }

        [Test] //TSCS5
        public void PurchaseItem()
        {
            // Call the AddItemToCart method
            AddItemToCart();

            // Click the "Cart" symbol
            IWebElement CartSymbol = driver.FindElement(By.ClassName("shopping_cart_link"));
            CartSymbol.Click();

            // Click the "Checkout" button
            IWebElement CheckoutButton = driver.FindElement(By.Id("checkout"));
            CheckoutButton.Click();

            // Fills in the "First Name" field
            IWebElement FirstNameField = driver.FindElement(By.Id("first-name"));
            FirstNameField.SendKeys("Natalie");

            // Fills in the "Last Name" field
            IWebElement LastNameField = driver.FindElement(By.Id("last-name"));
            LastNameField.SendKeys("Decatoi");

            // Fills in the "Zip/PostalCode" field
            IWebElement ZipField = driver.FindElement(By.Id("postal-code"));
            ZipField.SendKeys("7866");

            // Click the "Continue" button
            IWebElement ContinueButton = driver.FindElement(By.Id("continue"));
            ContinueButton.Click();

            // Click the "Finish" button
            IWebElement FinishButton = driver.FindElement(By.Id("finish"));
            FinishButton.Click();
        }

        [Test] //TSCS6
        public void RemoveItemFromCart()
        {
            // Call the "AddItemToCart" method
            AddItemToCart();

            // Click the "Cart" symbol
            IWebElement CartSymbol = driver.FindElement(By.ClassName("shopping_cart_link"));
            CartSymbol.Click();

            // Click the "Remove" button
            IWebElement RemoveButton = driver.FindElement(By.Id("remove-sauce-labs-backpack"));
            RemoveButton.Click();
        }

        [Test] //TSCS7
        public void UsingFilter()
        {
            // Call the "LoginTest" method
            LoginTest();

            // Click the "Filter" symbol and choose the filter
            IWebElement Filter = driver.FindElement(By.ClassName("product_sort_container"));
            var selectElementFilter = new SelectElement(Filter);
            selectElementFilter.SelectByValue("hilo");
        }

        [Test] //TSCS8
        public void LogoutTest()
        {
            // Call the "LoginTest" method
            LoginTest();

            // Click the "Menu Bar"
            IWebElement MenuBar = driver.FindElement(By.Id("react-burger-menu-btn"));
            MenuBar.Click();

            // Click the "Logout" menu
            IWebElement LogoutMenu = driver.FindElement(By.XPath("//*[@id=\"logout_sidebar_link\"]"));
            LogoutMenu.Click();
        }


        [TearDown]
        public void CloseTest()
        {
            // Break for 3 sec.
            Thread.Sleep(3000);

            // Close the browser
            driver.Quit();
        }
    }
}