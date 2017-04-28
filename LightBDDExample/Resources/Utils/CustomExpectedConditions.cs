using System;
using OpenQA.Selenium;

namespace LightBDDExample.Resources.Utils
{
    public static class CustomExpectedConditions
    {

        public static Func<IWebDriver, bool> WindowHandlesCount( int expectedCount )
        {
            return ( IWebDriver driver ) => expectedCount == driver.WindowHandles.Count;
        }

        public static Func<IWebDriver, bool> ElementContainsText( IWebElement element, string text )
        {
            return ( IWebDriver driver ) => element.Text.Contains( text );
        }

    }
}
