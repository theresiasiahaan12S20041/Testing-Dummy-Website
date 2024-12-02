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
            // Go to Luma page
            driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/");

            // Make the browser full screen
            driver.Manage().Window.Maximize();
        }

        [Test] //TSCS1
        public void CreateAccount()
        {
            // Click the "Create an Account" on the top right corner
            IWebElement CreateAccount = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[3]/a"));
            CreateAccount.Click();

            // Fills in the "First Name" field
            IWebElement FirstNameField = driver.FindElement(By.Id("firstname"));
            FirstNameField.SendKeys("Dummy");

            // Fills in the "Last Name" field
            IWebElement LastNameField = driver.FindElement(By.Id("lastname"));
            LastNameField.SendKeys("Test");

            // Fills in the "Email" field
            IWebElement EmailField = driver.FindElement(By.Id("email_address"));
            EmailField.SendKeys("dummyytesttwebsitee1@gmail.com");

            // Fills in the "Password" field
            IWebElement PasswordField = driver.FindElement(By.Id("password"));
            PasswordField.SendKeys("Dummytest123321123.");

            // Fills in the "Confirm Password" field
            IWebElement ConfirmPasswordField = driver.FindElement(By.Id("password-confirmation"));
            ConfirmPasswordField.SendKeys("Dummytest123321123.");

            // Click the "Create an Account" button
            IWebElement CreateAccountButton = driver.FindElement(By.CssSelector("button.action.submit.primary"));
            CreateAccountButton.Click();
        }

        [Test] //TSCS2
        public void FailedCreateAccount() // Due to wrong email format
        {
            // Click the "Create an Account" on the top right corner
            IWebElement CreateAccount = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[3]/a"));
            CreateAccount.Click();

            // Fills in the "First Name" field
            IWebElement FirstNameField = driver.FindElement(By.Id("firstname"));
            FirstNameField.SendKeys("Dummy");

            // Fills in the "Last Name" field
            IWebElement LastNameField = driver.FindElement(By.Id("lastname"));
            LastNameField.SendKeys("Test");

            // Fills in the "Email" field
            IWebElement EmailField = driver.FindElement(By.Id("email_address"));
            EmailField.SendKeys("dummyytesttwebsitee.com");

            // Fills in the "Password" field
            IWebElement PasswordField = driver.FindElement(By.Id("password"));
            PasswordField.SendKeys("Dummytest123321123.");

            // Fills in the "Confirm Password" field
            IWebElement ConfirmPasswordField = driver.FindElement(By.Id("password-confirmation"));
            ConfirmPasswordField.SendKeys("Dummytest123321123.");

            // Click the "Create an Account" button
            IWebElement CreateAccountButton = driver.FindElement(By.CssSelector("button.action.submit.primary"));
            CreateAccountButton.Click();

            // Check the error message
            IWebElement ErrorMessage = driver.FindElement(By.Id("email_address-error"));
            string ActualErrorMessageText = ErrorMessage.Text;
            string ExpectedErrorMessageText = "Please enter a valid email address (Ex: johndoe@domain.com).";
            Assert.That(Equals(ActualErrorMessageText, ExpectedErrorMessageText));

            // Print the error message
            Console.WriteLine("Actual message text is: " + ActualErrorMessageText);
            Console.WriteLine("Expected message text is: " + ExpectedErrorMessageText);
        }

        [Test] //TSCS3
        public void PasswordTooShort() // Password is less than 8 char
        {
            // Click the "Create an Account" on the top right corner
            IWebElement CreateAccount = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[3]/a"));
            CreateAccount.Click();

            // Fills in the "First Name" field
            IWebElement FirstNameField = driver.FindElement(By.Id("firstname"));
            FirstNameField.SendKeys("Dummy");

            // Fills in the "Last Name" field
            IWebElement LastNameField = driver.FindElement(By.Id("lastname"));
            LastNameField.SendKeys("Test");

            // Fills in the "Email" field
            IWebElement EmailField = driver.FindElement(By.Id("email_address"));
            EmailField.SendKeys("dummyytesttwebsitee1@gmail.com");

            // Fills in the "Password" field
            IWebElement PasswordField = driver.FindElement(By.Id("password"));
            PasswordField.SendKeys("Dummy.");

            // Fills in the "Confirm Password" field
            IWebElement ConfirmPasswordField = driver.FindElement(By.Id("password-confirmation"));
            ConfirmPasswordField.SendKeys("Dummy.");

            // Click the "Create an Account" button
            IWebElement CreateAccountButton = driver.FindElement(By.CssSelector("button.action.submit.primary"));
            CreateAccountButton.Click();

            // Check the error message
            IWebElement ErrorMessage = driver.FindElement(By.Id("password-error"));
            string ActualErrorMessageText = ErrorMessage.Text;
            string ExpectedErrorMessageText = "Minimum length of this field must be equal or greater than 8 symbols. Leading and trailing spaces will be ignored.";
            Assert.That(Equals(ActualErrorMessageText, ExpectedErrorMessageText));

            // Print the error message
            Console.WriteLine("Actual message text is: " + ActualErrorMessageText);
            Console.WriteLine("Expected message text is: " + ExpectedErrorMessageText);
        }

        [Test] //TSCS4
        public void PasswordLackChar() // Password is lack of character
        {
            // Click the "Create an Account" on the top right corner
            IWebElement CreateAccount = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[3]/a"));
            CreateAccount.Click();

            // Fills in the "First Name" field
            IWebElement FirstNameField = driver.FindElement(By.Id("firstname"));
            FirstNameField.SendKeys("Dummy");

            // Fills in the "Last Name" field
            IWebElement LastNameField = driver.FindElement(By.Id("lastname"));
            LastNameField.SendKeys("Test");

            // Fills in the "Email" field
            IWebElement EmailField = driver.FindElement(By.Id("email_address"));
            EmailField.SendKeys("dummyytesttwebsitee1@gmail.com");

            // Fills in the "Password" field
            IWebElement PasswordField = driver.FindElement(By.Id("password"));
            PasswordField.SendKeys("dummytest123");

            // Fills in the "Confirm Password" field
            IWebElement ConfirmPasswordField = driver.FindElement(By.Id("password-confirmation"));
            ConfirmPasswordField.SendKeys("dummytest123");

            // Click the "Create an Account" button
            IWebElement CreateAccountButton = driver.FindElement(By.CssSelector("button.action.submit.primary"));
            CreateAccountButton.Click();

            // Check the error message
            IWebElement ErrorMessage = driver.FindElement(By.Id("password-error"));
            string ActualErrorMessageText = ErrorMessage.Text;
            string ExpectedErrorMessageText = "Minimum of different classes of characters in password is 3. Classes of characters: Lower Case, Upper Case, Digits, Special Characters.";
            Assert.That(Equals(ActualErrorMessageText, ExpectedErrorMessageText));

            // Print the error message
            Console.WriteLine("Actual message text is: " + ActualErrorMessageText);
            Console.WriteLine("Expected message text is: " + ExpectedErrorMessageText);
        }

        [Test] //TSCS5
        public void SignInTest()
        {
            // Click the "SignIn" on the left of "Create an Account"
            IWebElement SignIn = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[2]/a"));
            SignIn.Click();

            // Fills in the "Email" field
            IWebElement EmailField = driver.FindElement(By.Id("email"));
            EmailField.SendKeys("dummyytesttwebsitee1@gmail.com");

            // Fills in the "Password" field
            IWebElement PasswordField = driver.FindElement(By.Id("pass"));
            PasswordField.SendKeys("Dummytest123321123.");

            // Click the "Sign In" button
            IWebElement SignInButton = driver.FindElement(By.XPath("//*[@id=\"send2\"]/span"));
            SignInButton.Click();
        }

        [Test] //TSCS6
        public void NewestItemToCart()              // Save item to cart from the "What's New" menu on navbar
        {
            // Call the "SignInTest" method
            SignInTest();

            // Click the "What's New" menu on the navbar
            IWebElement NewestItem = driver.FindElement(By.Id("ui-id-3"));
            NewestItem.Click();

            // Select an item from a section and category
            IWebElement SecCatItem = driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[4]/div[2]/div/div/ul[1]/li[2]/a"));
            SecCatItem.Click();

            // Select the size of the item
            IWebElement ItemSize = driver.FindElement(By.Id("option-label-size-143-item-168"));
            ItemSize.Click();

            // Select the color of the item
            IWebElement ItemColor = driver.FindElement(By.Id("option-label-color-93-item-57"));
            ItemColor.Click();

            // Click the "Add to Cart" button
            IWebElement AddToCartButton = driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[3]/div[1]/div[3]/ol/li[1]/div/div/div[3]/div/div[1]/form/button/span"));
            AddToCartButton.Click();
        }

        [Test] //TSCS7
        public void WomenItemToCart()              // Save item to cart from the "Women" menu on navbar
        {
            // Call the "SignInTest" method
            SignInTest();

            // Click the "Women" menu on the navbar
            IWebElement WomenItem = driver.FindElement(By.Id("ui-id-4"));
            WomenItem.Click();

            // Select an items type from category
            IWebElement CatTypItem = driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[4]/div[2]/div[2]/div/ul[1]/li[1]/a"));
            CatTypItem.Click();

            // Select the size of the item
            IWebElement ItemSize = driver.FindElement(By.Id("option-label-size-143-item-167"));
            ItemSize.Click();

            // Select the color of the item
            IWebElement ItemColor = driver.FindElement(By.Id("option-label-color-93-item-59"));
            ItemColor.Click();

            // Click the "Add to Cart" button
            IWebElement AddToCartButton = driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[3]/div[1]/div[3]/ol/li[5]/div/div/div[3]/div/div[1]/form/button/span"));
            AddToCartButton.Click();
        }

        [Test] //TSCS8
        public void MenItemToCart()              // Save item to cart from the "Men" menu on navbar
        {
            // Call the "SignInTest" method
            SignInTest();

            // Click the "Men" menu on the navbar
            IWebElement MenItem = driver.FindElement(By.Id("ui-id-5"));
            MenItem.Click();

            // Select an items type from category
            IWebElement CatTypItem = driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[4]/div[2]/div[2]/div/ul[1]/li[1]/a"));
            CatTypItem.Click();

            // Select the size of the item
            IWebElement ItemSize = driver.FindElement(By.Id("option-label-size-143-item-170"));
            ItemSize.Click();

            // Select the color of the item
            IWebElement ItemColor = driver.FindElement(By.Id("option-label-color-93-item-53"));
            ItemColor.Click();

            // Click the "Add to Cart" button
            IWebElement AddToCartButton = driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[3]/div[1]/div[3]/ol/li[1]/div/div/div[3]/div/div[1]/form/button"));
            AddToCartButton.Click();
        }

        [Test] //TSCS9
        public void AddAddressBook()
        {
            // Call the "SignInTest" method
            SignInTest();

            // Click the drop-down
            IWebElement DropDown = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[2]/span/button"));
            DropDown.Click();

            // Click the "My Account" option
            IWebElement MyAccountMenu = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[2]/div/ul/li[1]/a"));
            MyAccountMenu.Click();

            // Click the "Address Book" menu
            IWebElement AddressBookMenu = driver.FindElement(By.XPath("//*[@id=\"block-collapsible-nav\"]/ul/li[6]/a"));
            AddressBookMenu.Click();

            // Fills in the "First Name" field-> this is optional, because it's automated fill by the data that we registered first
            IWebElement FirstName = driver.FindElement(By.Id("firstname"));
            FirstName.SendKeys("Dummy");

            // Fills in the "Last Name" field-> this is optional, because it's automated fill by the data that we registered first
            IWebElement LastName = driver.FindElement(By.Id("lastname"));
            LastName.SendKeys("Test");

            // Fills in the "Company" field
            IWebElement Company = driver.FindElement(By.Id("company"));
            Company.SendKeys("Dummy company");

            // Fills in the "Phone Number" field
            IWebElement PhoneNumber = driver.FindElement(By.Id("telephone"));
            PhoneNumber.SendKeys("82456123789");

            // Fills in the "Street Address" field
            IWebElement StreetAddress = driver.FindElement(By.Id("street_1"));
            StreetAddress.SendKeys("Dummy Test Street");

            // Fills in the "City" field
            IWebElement City = driver.FindElement(By.Id("city"));
            City.SendKeys("London");

            // Fills in the "State/Province" field
            IWebElement StateProvince = driver.FindElement(By.Id("region_id"));
            var selectElementStateProvince = new SelectElement(StateProvince);
            selectElementStateProvince.SelectByValue("1");

            // Fills in the "Zip/Postal Code" field
            IWebElement Zip = driver.FindElement(By.Id("zip"));
            Zip.SendKeys("12345");

            // Fills in the "Country" field
            IWebElement Country = driver.FindElement(By.Id("country"));
            var selectElementCountry = new SelectElement(Country);
            selectElementCountry.SelectByValue("GB");

            // Click the “Save Address” button
            IWebElement SaveAddressButton = driver.FindElement(By.XPath("//*[@id=\"form-validate\"]/div/div[1]/button"));
            SaveAddressButton.Click();
        }

        [Test] //TSCS10
        public void PurchaseItem()
        {
            // Call the "SignInTest" method
            SignInTest();

            // Break
            Thread.Sleep(5000);

            // Click the "Cart" symbol
            IWebElement CartSymbol = driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[1]/a"));
            CartSymbol.Click();

            // Wait until the pop-up appear
            Thread.Sleep(5000);

            // Click the "Proceed to Checkout" button
            IWebElement ProceedToCheckOut = driver.FindElement(By.Id("top-cart-btn-checkout"));
            ProceedToCheckOut.Click();

            // Break
            Thread.Sleep(5000);

            // Click the "Next" button
            IWebElement NextButton = driver.FindElement(By.XPath("//*[@id=\"shipping-method-buttons-container\"]/div/button"));
            NextButton.Click();

            // Break
            Thread.Sleep(5000);

            // Click the "Place Order" button
            IWebElement PlaceOrder = driver.FindElement(By.XPath("//*[@id=\"checkout-payment-method-load\"]/div/div/div[2]/div[2]/div[4]/div/button"));
            PlaceOrder.Click();
        }

        [Test] //TSCS11
        public void ViewEditCart()
        {
            // Call the "SignInTest" method
            SignInTest();

            // Break
            Thread.Sleep(5000);

            // Click the "Cart" symbol
            IWebElement CartSymbol = driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[1]/a"));
            CartSymbol.Click();

            // Click the "View and Edit Cart" hyperlink
            IWebElement ViewAndEditCart = driver.FindElement(By.XPath("//*[@id=\"minicart-content-wrapper\"]/div[2]/div[5]/div/a"));
            ViewAndEditCart.Click();

            // Edit the "Qty" item
            IWebElement Qty = driver.FindElement(By.Id("cart-427337-qty"));
            Qty.Clear();
            Qty.SendKeys("5");

            // Click the "Update Shopping Cart" button
            IWebElement UpdateShoppingCart = driver.FindElement(By.XPath("//*[@id=\"form-validate\"]/div[2]/button[2]"));
            UpdateShoppingCart.Click();
        }

        [Test] //TSCS12
        public void ViewOrder()
        {
            // Call the "SignInTest" method
            SignInTest();

            // Click the drop-down
            IWebElement DropDown = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[2]/span/button"));
            DropDown.Click();

            // Click the "My Orders" option
            IWebElement MyOrdersMenu = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[2]/div/ul/li[1]/a"));
            MyOrdersMenu.Click();

            // Click "View Order" hyperlink from one of the orders
            IWebElement ViewOrderHyperlink = driver.FindElement(By.XPath("//*[@id=\"my-orders-table\"]/tbody/tr[1]/td[6]/a[1]"));
            ViewOrderHyperlink.Click();
        }

        [Test] //TSCS13
        public void Reorder()
        {
            // Call the "SignInTest" method
            SignInTest();

            // Click the drop-down
            IWebElement DropDown = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[2]/span/button"));
            DropDown.Click();

            // Click the "My Orders" option
            IWebElement MyOrdersMenu = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[2]/div/ul/li[1]/a"));
            MyOrdersMenu.Click();

            // Click "Reorder" hyperlink from one of the orders
            IWebElement ReorderHyperlink = driver.FindElement(By.XPath("//*[@id=\"my-orders-table\"]/tbody/tr[1]/td[6]/a[2]"));
            ReorderHyperlink.Click();

            // Change the "Qty"
            IWebElement Qty = driver.FindElement(By.Id("cart-427337-qty"));
            Qty.Clear();
            Qty.SendKeys("10");

            // Click the "Update Shopping Cart" button
            IWebElement UpdateShoppingCart = driver.FindElement(By.XPath("//*[@id=\"form-validate\"]/div[2]/button[2]"));
            UpdateShoppingCart.Click();

            // Break
            Thread.Sleep(5000);

            // Click the "Proceed to Checkout" button
            IWebElement ProceedToCheckOut = driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[3]/div/div[2]/div[1]/ul/li[1]/button"));
            ProceedToCheckOut.Click();

            // Break
            Thread.Sleep(5000);

            // Click the "Next" button
            IWebElement NextButton = driver.FindElement(By.XPath("//*[@id=\"shipping-method-buttons-container\"]/div/button"));
            NextButton.Click();

            // Break
            Thread.Sleep(5000);

            // Click the "Place Order" button
            IWebElement PlaceOrder = driver.FindElement(By.XPath("//*[@id=\"checkout-payment-method-load\"]/div/div/div[2]/div[2]/div[4]/div/button"));
            PlaceOrder.Click();
        }


        [TearDown]
        public void CloseTest()
        {
            // Break for 5 sec.
            Thread.Sleep(5000);

            // Close the browser
            driver.Quit();
        }
    }
}