using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LightBDDExample.Resources.Utils
{
    public static class CustomWaits
    {
        public static bool UntilElementVisibleReturnBool( IWebDriver driver, double maxWaitTime, By locator )
        {
            IWebElement element = new WebDriverWait( driver, TimeSpan.FromSeconds( maxWaitTime ) ).Until( ExpectedConditions.ElementIsVisible( ( locator ) ) );
            return element != null;
        }

        public static bool UntilElementVisibleReturnBool( IWebDriver driver, By locator )
        {
            IWebElement element = new WebDriverWait( driver, TimeSpan.FromSeconds( 10 ) ).Until( ExpectedConditions.ElementIsVisible( ( locator ) ) );
            return element != null;
        }

        public static void UntilElementVisible( IWebDriver driver, double maxWaitTime, By locator )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( maxWaitTime ) ).Until( ExpectedConditions.ElementIsVisible( ( locator ) ) );
        }

        public static void UntilElementVisible( IWebDriver driver, By locator )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( 10 ) ).Until( ExpectedConditions.ElementIsVisible( ( locator ) ) );
        }

        public static bool UntilAllElementVisibleReturnBool( IWebDriver driver, double maxWaitTime, By locator )
        {
            ReadOnlyCollection<IWebElement> elementList = new WebDriverWait( driver, TimeSpan.FromSeconds( maxWaitTime ) ).Until( ExpectedConditions.VisibilityOfAllElementsLocatedBy( ( locator ) ) );

            return elementList.Count != 0;
        }

        public static bool UntilAllElementVisibleReturnBool( IWebDriver driver, By locator )
        {
            ReadOnlyCollection<IWebElement> elementList = new WebDriverWait( driver, TimeSpan.FromSeconds( 10 ) ).Until( ExpectedConditions.VisibilityOfAllElementsLocatedBy( ( locator ) ) );

            return elementList.Count != 0;
        }

        public static void UntilAllElementVisible( IWebDriver driver, double maxWaitTime, By locator )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( maxWaitTime ) ).Until( ExpectedConditions.VisibilityOfAllElementsLocatedBy( ( locator ) ) );
        }

        public static void UntilAllElementVisible( IWebDriver driver, By locator )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( 10 ) ).Until( ExpectedConditions.VisibilityOfAllElementsLocatedBy( ( locator ) ) );
        }

        public static bool UntilElementNotVisibleReturnBool( IWebDriver driver, double maxWaitTime, By locator )
        {
            bool isNotVisible = new WebDriverWait( driver, TimeSpan.FromSeconds( maxWaitTime ) ).Until( ExpectedConditions.InvisibilityOfElementLocated( ( locator ) ) );
            return isNotVisible;
        }

        public static bool UntilElementNotVisibleReturnBool( IWebDriver driver, By locator )
        {
            bool isNotVisible = new WebDriverWait( driver, TimeSpan.FromSeconds( 10 ) ).Until( ExpectedConditions.InvisibilityOfElementLocated( ( locator ) ) );
            return isNotVisible;
        }

        public static void UntilElementNotVisible( IWebDriver driver, double maxWaitTime, By locator )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( maxWaitTime ) ).Until( ExpectedConditions.InvisibilityOfElementLocated( ( locator ) ) );
        }

        public static void UntilElementNotVisible( IWebDriver driver, By locator )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( 10 ) ).Until( ExpectedConditions.InvisibilityOfElementLocated( ( locator ) ) );
        }

        public static void UntilUrlContains( IWebDriver driver, double maxWaitTime, string urlFragment )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( maxWaitTime ) ).Until( ExpectedConditions.UrlContains( ( urlFragment ) ) );
        }

        public static void UntilUrlContains( IWebDriver driver, string urlFragment )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( 15 ) ).Until( ExpectedConditions.UrlContains( ( urlFragment ) ) );
        }

        public static void UntilWindowHandlesCount( IWebDriver driver, double maxWaitTime, int windowHandlesCount )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( maxWaitTime ) ).Until( CustomExpectedConditions.WindowHandlesCount( windowHandlesCount ) );
        }

        public static void UntilWindowHandlesCount( IWebDriver driver, int windowHandlesCount )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( 15 ) ).Until( CustomExpectedConditions.WindowHandlesCount( windowHandlesCount ) );
        }

        public static void UntilElementContainsText( IWebDriver driver, double maxWaitTime, IWebElement element, string text )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( maxWaitTime ) ).Until( CustomExpectedConditions.ElementContainsText( element, text ) );
        }

        public static void UntilElementContainsText( IWebDriver driver, IWebElement element, string text )
        {
            new WebDriverWait( driver, TimeSpan.FromSeconds( 15 ) ).Until( CustomExpectedConditions.ElementContainsText( element, text ) );
        }

    }
}
