using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AutomationExercise
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
            // Go to AutomationExercise page
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");

            // Make the browser full screen
            driver.Manage().Window.Maximize();
        }

        [Test] //TSCS1
        public void Register()
        {
            // Click the "Signup / Login" button
            IWebElement SignUp = driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[4]/a"));
            SignUp.Click();

            // Fills in the "Name" field on 'New User Signup!' space
            IWebElement Name = driver.FindElement(By.Name("name"));
            Name.SendKeys("DummyTest");

            // Fills in the "Email Address" field on 'New User Signup!' space
            IWebElement EmailAddress = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[3]/div/form/input[3]"));
            EmailAddress.SendKeys("dummytestxxx@gmail.com");

            // Click the "Signup" button
            IWebElement SignUpButton = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[3]/div/form/button"));
            SignUpButton.Click();

            // Choose the "Title"
            IWebElement Title = driver.FindElement(By.Id("id_gender2"));
            Title.Click();

            // Fills in the "Password" field
            IWebElement Password = driver.FindElement(By.Id("password"));
            Password.SendKeys("DummyTest.");

            // Choose the "Day" in 'Date of Birth'
            IWebElement Day = driver.FindElement(By.Id("days"));
            var selectElementDay = new SelectElement(Day);
            selectElementDay.SelectByValue("10");

            // Choose the "Month" in 'Date of Birth'
            IWebElement Month = driver.FindElement(By.Id("months"));
            var selectElementMonth = new SelectElement(Month);
            selectElementMonth.SelectByValue("7");

            // Choose the "Year" in 'Date of Birth'
            IWebElement Year = driver.FindElement(By.Id("years"));
            var selectElementYear = new SelectElement(Year);
            selectElementYear.SelectByValue("2001");

            // Fills in the "First Name" field for 'Address Information'
            IWebElement FirstName = driver.FindElement(By.Id("first_name"));
            FirstName.SendKeys("Dummy");

            // Fills in the "Last Name" field for 'Address Information'
            IWebElement LastName = driver.FindElement(By.Id("last_name"));
            LastName.SendKeys("Test");

            // Fills in the "Company" field for 'Address Information'
            IWebElement Company = driver.FindElement(By.Id("company"));
            Company.SendKeys("Dummy's Company");

            // Fills in the "Address" field for 'Address Information'
            IWebElement Address = driver.FindElement(By.Id("address1"));
            Address.SendKeys("Dummy Streets");

            // Choose the "Country"
            IWebElement Country = driver.FindElement(By.Id("country"));
            var selectElementCountry = new SelectElement(Country);
            selectElementCountry.SelectByValue("Canada");

            // Fills in the "State" field for 'Address Information'
            IWebElement State = driver.FindElement(By.Id("state"));
            State.SendKeys("Alberta");

            // Fills in the "City" field for 'Address Information'
            IWebElement City = driver.FindElement(By.Id("city"));
            City.SendKeys("Fort McMurray");

            // Fills in the "Zipcode" field for 'Address Information'
            IWebElement Zipcode = driver.FindElement(By.Id("zipcode"));
            Zipcode.SendKeys("49240");

            // Fills in the "Mobile Number" field for 'Address Information'
            IWebElement MobileNumber = driver.FindElement(By.Id("mobile_number"));
            MobileNumber.SendKeys("+16470087");

            // Click the "Create Account" button
            IWebElement CreateAccount = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div/div/form/button"));
            CreateAccount.Click();
        }

        [Test] //TSCS2
        public void RegisterEmailExist()
        {
            // Click the "Signup / Login" button
            IWebElement SignUp = driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[4]/a"));
            SignUp.Click();

            // Fills in the "Name" field on 'New User Signup!' space
            IWebElement Name = driver.FindElement(By.Name("name"));
            Name.SendKeys("DummyTest");

            // Fills in the "Email Address" field on 'New User Signup!' space
            IWebElement EmailAddress = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[3]/div/form/input[3]"));
            EmailAddress.SendKeys("dummytestxxx@gmail.com");

            // Click the "Signup" button
            IWebElement SignUpButton = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[3]/div/form/button"));
            SignUpButton.Click();

            // Check the error message
            IWebElement ErrorMessage = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[3]/div/form/p"));
            string ActualErrorMessageText = ErrorMessage.Text;
            string ExpectedErrorMessageText = "Email Address already exist!";
            Assert.That(Equals(ActualErrorMessageText, ExpectedErrorMessageText));

            // Print the error message
            Console.WriteLine("Actual message text is: " + ActualErrorMessageText);
            Console.WriteLine("Expected message text is: " + ExpectedErrorMessageText);
        }

        [Test] //TSCS3
        public void LoginSucc()
        {
            // Click the "Signup / Login" button
            IWebElement SignUp = driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[4]/a"));
            SignUp.Click();

            // Fills in the “Email Address” field
            IWebElement EmailAddress = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/input[2]"));
            EmailAddress.SendKeys("dummytestxxx@gmail.com");

            // Fills in the “Password” field
            IWebElement Password = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/input[3]"));
            Password.SendKeys("DummyTest.");

            // Click the “Login” button
            IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/button"));
            LoginButton.Click();
        }

        [Test] //TSCS4
        public void LoginFailed()
        {
            // Click the "Signup / Login" button
            IWebElement SignUp = driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[4]/a"));
            SignUp.Click();

            // Fills in the “Email Address” field with the wrong email address
            IWebElement EmailAddress = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/input[2]"));
            EmailAddress.SendKeys("dummytestxxxz@gmail.com");

            // Fills in the “Password” field with the wrong password
            IWebElement Password = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/input[3]"));
            Password.SendKeys("DummyTest..");

            // Click the “Login” button
            IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/button"));
            LoginButton.Click();

            // Check the error message
            IWebElement ErrorMessage = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/p"));
            string ActualErrorMessageText = ErrorMessage.Text;
            string ExpectedErrorMessageText = "Your email or password is incorrect!";
            Assert.That(Equals(ActualErrorMessageText, ExpectedErrorMessageText));

            // Print the error message
            Console.WriteLine("Actual message text is: " + ActualErrorMessageText);
            Console.WriteLine("Expected message text is: " + ExpectedErrorMessageText);
        }

        [Test] //TSCS5
        public void Logout()
        {
            // Call the "LoginSucc" method
            LoginSucc();

            // Click the "Logout" menu
            IWebElement Logout = driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[4]/a"));
            Logout.Click();
        }

        [Test] //TSCS6
        public void ContactUs()
        {
            // Click the "Contact us" menu
            IWebElement ContactUs = driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[8]/a"));
            ContactUs.Click();

            // Fills in the "Name" field
            IWebElement Name = driver.FindElement(By.Name("name"));
            Name.SendKeys("DummyTest");

            // Fills in the "Email" field
            IWebElement Email = driver.FindElement(By.Name("email"));
            Email.SendKeys("dummytestxxx@gmail.com");

            // Fills in the "Subject" field
            IWebElement Subject = driver.FindElement(By.Name("subject"));
            Subject.SendKeys("Feedback");

            // Fills in the "Your Message Here" field with users problem or feedback
            IWebElement Message = driver.FindElement(By.Id("message"));
            Message.SendKeys("Hi! I just want to tell you that this website is good.");

            // Upload a file attachments by clicking the "Choose File" button
            IWebElement ChooseFile = driver.FindElement(By.Name("upload_file"));
            ChooseFile.SendKeys("D:\\download.jfif");

            // Click the "Submit" button
            IWebElement Submit = driver.FindElement(By.Name("submit"));
            Submit.Click();

            // Wait for the pop up
            Thread.Sleep(2000);

            // Switch to confirmation pop-up
            IAlert Confirmation = driver.SwitchTo().Alert();

            // Click "OK" for confirmation
            Confirmation.Accept();

            // Check the error message
            IWebElement ErrorMessage = driver.FindElement(By.XPath("//*[@id=\"contact-page\"]/div[2]/div[1]/div/div[2]"));
            string ActualErrorMessageText = ErrorMessage.Text;
            string ExpectedErrorMessageText = "Success! Your details have been submitted successfully.";
            Assert.That(Equals(ActualErrorMessageText, ExpectedErrorMessageText));

            // Print the error message
            Console.WriteLine("Actual message text is: " + ActualErrorMessageText);
            Console.WriteLine("Expected message text is: " + ExpectedErrorMessageText);
        }

        [Test] //TSCS7
        public void AddItemToCart()
        {
            // Call the "LoginSucc" method
            LoginSucc();

            // Get item by using "data-product-id"
            IReadOnlyCollection<IWebElement> Items = driver.FindElements(By.CssSelector(".features_items [data-product-id]"));

            // Click "Add to Cart" button for each item
            foreach (var AddtoCart in Items)
            {
                try
                {
                    // Click the "Add to cart" button 
                    AddtoCart.Click();

                    // Wait the pop-up 
                    Thread.Sleep(3000);

                    // Click the "Continue Shopping" button
                    IWebElement ContinueShoppingButton = driver.FindElement(By.XPath("//*[@id=\"cartModal\"]/div/div/div[3]/button"));
                    ContinueShoppingButton.Click();

                    // Break
                    Thread.Sleep(3000);
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to add product to cart: {ex.Message}");
                }
            }
        }

        [Test] //TSCS8
        public void ViewCart()
        {
            // Call the "LoginSucc" method
            LoginSucc();

            // Click the "Cart" menu
            IWebElement Cart = driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[3]/a"));
            Cart.Click();
        }

        [Test] //TSCS9
        public void DeleteItem()
        {
            // Call the "LoginSucc" method
            LoginSucc();

            // Click the "Cart" menu
            IWebElement Cart = driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[3]/a"));
            Cart.Click();

            // Click the 'x' button in the item that user want to delete
            // Get item by using "data-product-id"
            IReadOnlyCollection<IWebElement> Items = driver.FindElements(By.CssSelector(".container [data-product-id]"));

            // Delete item
            foreach (var Delete in Items)
            {
                try
                {
                    // Click the "Delete" button 
                    Delete.Click();

                    // Break
                    Thread.Sleep(3000);
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to delete product in cart: {ex.Message}");
                }
            }
        }

        [Test] //TSCS10
        public void Checkout()
        {
            // Call the "LoginSucc" method
            LoginSucc();

            // Click the "Cart" menu
            IWebElement Cart = driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[3]/a"));
            Cart.Click();

            // Click the "Proceed To Checkout" button
            IWebElement ProceedToCheckout = driver.FindElement(By.XPath("//*[@id=\"do_action\"]/div[1]/div/div/a"));
            ProceedToCheckout.Click();

            // Write comment about the orders in the "If you would like to add a comment about your order, pleasee write in the field below" section
            IWebElement Comment = driver.FindElement(By.Name("message"));
            Comment.SendKeys("Please, make sure i get the right item. Thank you!");

            // Click the "Place Order" button
            IWebElement PlaceOrder = driver.FindElement(By.XPath("//*[@id=\"cart_items\"]/div/div[7]/a"));
            PlaceOrder.Click();

            // Fills in the "Name on Card" field
            IWebElement NameOnCard = driver.FindElement(By.Name("name_on_card"));
            NameOnCard.SendKeys("Dummy Test");

            // Fills in the "Card Number" field
            IWebElement CardNumber = driver.FindElement(By.Name("card_number"));
            CardNumber.SendKeys("5578");

            // Fills in the "CVC" field
            IWebElement CVC = driver.FindElement(By.Name("cvc"));
            CVC.SendKeys("311");

            // Fills in the "Expiration" field
            // Month field
            IWebElement MonthExp = driver.FindElement(By.Name("expiry_month"));
            MonthExp.SendKeys("10");

            // Year field
            IWebElement YearExp = driver.FindElement(By.Name("expiry_year"));
            YearExp.SendKeys("2025");

            // Click the "Pay and Confirm Order"
            IWebElement PayConOrder = driver.FindElement(By.Id("submit"));
            PayConOrder.Click();

            // Check the success message
            IWebElement SuccessMessage = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div/p"));
            string ActualSuccessMessageText = SuccessMessage.Text;
            string ExpectedSuccessMessageText = "Congratulations! Your order has been confirmed!";
            Assert.That(Equals(ActualSuccessMessageText, ExpectedSuccessMessageText));

            // Print the error message
            Console.WriteLine("Actual message text is: " + ActualSuccessMessageText);
            Console.WriteLine("Expected message text is: " + ExpectedSuccessMessageText);

            // Click the "Continue" button
            IWebElement ContinueButton = driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div/div/a"));
            ContinueButton.Click();
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