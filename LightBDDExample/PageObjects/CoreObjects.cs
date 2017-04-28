using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using LightBDDExample.Resources.Utils;
using LightBDDExample.Resources.Utils.Enums;
using LightBDDExample.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace LightBDDExample.PageObjects
{
    public abstract class CoreObjects : EnvironmentControl
    {

        #region Protected void functions
        protected void CheckElementContainsText( IWebDriver driver, By locator, string text )
        {
            CustomWaits.UntilElementVisible( driver, locator );

            IWebElement element = FindElement ( driver, locator );

            Assert.True ( element.Text.Contains ( text ) );
        }

        protected void ClickElementAndWait( IWebDriver driver, By locator, int milisec = 500)
        {
            IWebElement lElement = FindElement ( driver, locator );

            lElement.Click( );

            Thread.Sleep( milisec );
        }

        protected void ClickElementAndWait( IWebDriver driver, IWebElement element, int milisec = 500 )
        {
            element.Click( );

            Thread.Sleep( milisec );
        }

        protected void SwitchToLastWindow( IWebDriver driver )
        {
            IReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            string lastWindowHandle = windowHandles.Last( );

            driver.SwitchTo( ).Window( lastWindowHandle );
        }

        protected void OpenNewTab( IWebDriver driver )
        {
            IWebElement htmlBody = FindElement( driver, By.TagName( "body" ) );

            htmlBody.SendKeys( Keys.Control + "t" );
        }

        protected void HoverElement( IWebDriver driver, By locator )
        {
            CustomWaits.UntilElementVisible( driver, locator );

            IWebElement elementToHover = FindElement ( driver, locator );

            Actions action = new Actions ( driver );

            action.MoveToElement( elementToHover ).Perform( );
        }

        protected void HoverElement( IWebDriver driver, IWebElement element )
        {
            Actions action = new Actions ( driver );

            action.MoveToElement( element ).Perform( );
        }

        protected void CheckInputContainsText( IWebDriver driver, By inputLocator, string text)
        {
            CustomWaits.UntilElementVisible( driver, inputLocator );

            string lInputTextLowerCase = GetValueAttribute( driver, inputLocator ).ToLowerInvariant( );

            Assert.True ( lInputTextLowerCase.Contains ( text ) );
        }

        protected void GotoSite( IWebDriver driver, string url )
        {
            driver.Url = url;

            CustomWaits.UntilUrlContains( driver, url );
        }

        protected void ScrollUntilElementIsVisible( IWebDriver driver, By locator )
        {
            string scrollScript = "window.scrollTo(0, document.body.scrollHeight);";

            IJavaScriptExecutor lJs = driver as IJavaScriptExecutor;

            // A limit was created to avoid the test entering in a infinite loop.
            int scrollTimesLimit = 10;

            while ( !IsElementVisible ( driver, locator ) )
            {
                --scrollTimesLimit;

                if ( scrollTimesLimit < 0 )
                {
                    throw new ElementNotVisibleException( "Tried to scroll until element with the locator: " + locator + Environment.NewLine +
                                                          "Is visible, but run out of scroll try limit, and element is still not visible." );
                }

                lJs.ExecuteScript ( scrollScript );

                Thread.Sleep( 1000 );
            } 
        }

        protected void FillTextField( IWebDriver driver, By locator, string text, int milisec = 700 )
        {
            CustomWaits.UntilElementVisible( driver, locator );

            IWebElement textField = FindElement ( driver, locator );

            textField.Clear ( );

            textField.SendKeys ( text );

            textField.SendKeys ( "\t" );

            Thread.Sleep ( milisec );
        }

        #endregion

        #region Protected returning functions
        protected IReadOnlyList<IWebElement> GetAllChildrenFromElement( IWebDriver driver, By locator )
        {
            CustomWaits.UntilElementVisible( driver, locator );

            IWebElement rootElement = driver.FindElement( locator );

            IReadOnlyList<IWebElement> childrenList = rootElement.FindElements ( By.XPath ( ".//*" ) );

            return childrenList;
        }

        protected string GetValueAttribute( IWebDriver driver, By locator )
        {
            CustomWaits.UntilElementVisible( driver, locator );

            IWebElement lElement = FindElement ( driver, locator );

            return lElement.GetAttribute ( "value" );
        }
        protected bool CheckElementLocatorsInListVisibility( IReadOnlyList<By> locatorList )
        {
            bool allElementVisible = true;

            foreach( By currentLocator in locatorList )
            {
                if( !IsElementVisible( this.driver, currentLocator ) )
                {
                    allElementVisible = false;
                    break;
                }
            }

            return allElementVisible;
        }

        protected IWebElement GetElementByXpathContainsClass( IWebDriver driver, HtmlTags htmlTag, string containsClass )
        {
            string htmlTagString = Enum.GetName( typeof( HtmlTags ), htmlTag );

            IWebElement element = FindElement( driver, 
                By.XPath( $"//{htmlTagString}[ contains( @class,'{containsClass}' )]" ) );

            return element;
        }

        protected By XpathLocator( HtmlTags htmlTag, string locateWith, string attributeValue )
        {
            string htmlTagString = Enum.GetName( typeof( HtmlTags ), htmlTag );

            string locatorAttribute = locateWith == "text()" ? "text()" : $"@{locateWith}";

            return By.XPath( $"//{htmlTagString}[ {locatorAttribute} = '{attributeValue}' ]" );
        }

        protected By XpathLocator( HtmlTags htmlTag, LocatorStrategy locatorStrategy, string locateWith, string attributeValue )
        {
            By locator;

            string htmlTagString = Enum.GetName( typeof( HtmlTags ), htmlTag );

            string locatorAttribute = locateWith == "text()" ? "text()" : $"@{locateWith}";

            if ( locatorStrategy == LocatorStrategy.equals )
            {
                locator = By.XPath( $"//{htmlTagString}[ {locatorAttribute} = '{attributeValue}' ]" );
            }
            else
            {
                locator = By.XPath( $"//{htmlTagString}[ contains ( {locatorAttribute}, '{attributeValue}' ) ]" );
            }

            return locator;
        }

        protected bool IsElementVisible( IWebDriver driver, By locator )
        {
            try
            {
                IWebElement element = FindElement ( driver, locator );

                if ( element.Displayed )
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch ( NoSuchElementException noSuchElementEx )
            {
                Debug.WriteLine( $"Element not found in the DOM. Element locator: { locator }. Exception thrown: { noSuchElementEx }" );
                return false;
            }
        }

        protected IWebElement FindElement( IWebDriver driver, By locator )
        {
            CustomWaits.UntilElementVisible( driver, locator );
            return driver.FindElement( locator );
        }

        #endregion
    }
}
