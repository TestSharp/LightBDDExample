using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using LightBDD.NUnit3;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace LightBDDExample.Tests
{
    public abstract class EnvironmentControl : FeatureFixture
    {


        #region Fields
        protected IWebDriver driver;
        #endregion


        #region Private void (helper) functions

        // Writes the exception message to the console if the screenshot maker fails and quit the driver
        private void HandleScreenshotExceptionAndQuitDriver( Exception exception )
        {
            Debug.WriteLine( exception.GetType( ).ToString( ) + " type of Exception happened while tried to take a screenshot. Exception message: "
                 + Environment.NewLine + exception );

            driver.Quit( );
            driver = null;
        }

        // Takes a screenshot of the driver controlled browser
        private void TakeScreenshot( string screenshotName )
        {
            try
            {
                ITakesScreenshot screenShotTaker = driver as ITakesScreenshot;
                if ( screenShotTaker != null )
                {
                    // makes the screenshot   
                    Screenshot shot = screenShotTaker.GetScreenshot();
                    string projectRootDir = GetProjectRootDir( );
                    string screenShotDir = Path.Combine( projectRootDir, "Resources", "FailedStepsScreenshot" );

                    if( !Directory.Exists( screenShotDir ) )
                    {
                        Directory.CreateDirectory( screenShotDir );
                    }

                    // path and filename
                    string currentScreenShotSave = Path.Combine( screenShotDir, screenshotName );
                    // saves the screenshot to our directory with the wanted name in bmp format
                    shot.SaveAsFile ( currentScreenShotSave, ScreenshotImageFormat.Jpeg );
                }
            }
            catch ( AppDomainUnloadedException appDomainUnloadedEx )
            {
                HandleScreenshotExceptionAndQuitDriver( appDomainUnloadedEx );
                throw;
            }
            catch ( ArgumentNullException argNullEx )
            {
                HandleScreenshotExceptionAndQuitDriver( argNullEx );
                throw;
            }
            catch ( ArgumentException argEx )
            {
                HandleScreenshotExceptionAndQuitDriver( argEx );
                throw;
            }
            catch ( ExternalException externalEx )
            {
                HandleScreenshotExceptionAndQuitDriver ( externalEx );
                throw;
            }
        }

        #endregion

        #region Protected void functions
        // Initialize the given browser's driver
        protected void InitCurrentlySetBrowser( string aBrowser )
        {
            switch ( aBrowser )
            {
                case "firefox":
                    driver = new FirefoxDriver( );
                    driver.Manage( ).Window.Maximize( );
                    break;
                case "edge":
                    driver = new EdgeDriver( );
                    driver.Manage( ).Window.Maximize( );
                    break;
                case "ie":
                case "internet explorer":
                case "internetexplorer":
                case "iexplorer":
                    driver = new InternetExplorerDriver( );
                    driver.Manage( ).Window.Maximize( );
                    break;
                case "safari":
                    driver = new SafariDriver( );
                    driver.Manage( ).Window.Maximize( );
                    break;
                case "chrome":
                default:
                    driver = new ChromeDriver( );
                    driver.Manage( ).Window.Maximize( );
                    break;
            }
        }

        #endregion

        #region Private returning (helper) functions

        // Returning the project's root directory's path
        private string GetProjectRootDir()
        {
            string projectRootDir = AppDomain.CurrentDomain.BaseDirectory;
            
            // changes the unnecessary parts of the path (the remaining is the project dir) and changes to our wanted screenshot dir
            if ( projectRootDir.Contains ( "bin" ) )
            {
                string stringToReplace = projectRootDir.Substring( projectRootDir.IndexOf( "bin", StringComparison.Ordinal ) - 1 );
                projectRootDir = projectRootDir.Replace ( stringToReplace, "" );
            }

            return projectRootDir;
        }

        #endregion

        #region Protected returning functions

        // If you are using the TestRunner program (which can be found in thsi repository:
        // https://github.com/TestSharp/SetBrowserTestRunnerCA
        // this function helps to read in the content (selected browser) from the text file
        // generated by that program
        protected string GetCurrentlySetBrowser
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly( ).CodeBase;
                UriBuilder uri = new UriBuilder( codeBase );
                string path = Uri.UnescapeDataString( uri.Path );
                string assemblyDirectory = Path.GetDirectoryName( path );

                string configTextInAssemblyDir = Path.Combine( assemblyDirectory, "config.txt" );

                if ( !File.Exists( configTextInAssemblyDir ) )
                {
                    return "chrome";
                }
                else
                {
                    string browserText = File.ReadAllText( configTextInAssemblyDir );
                    browserText = browserText.Trim( ' ' );
                    return browserText.ToLowerInvariant( );
                }
            }
        }

        #endregion


        #region Public void functions for setting up and disposing the environment

        [SetUp]
        protected void Setup( )
        {
            InitCurrentlySetBrowser( GetCurrentlySetBrowser );
        }

        [TearDown]
        public void TearDown()
        {
            bool testPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;

            if ( !testPassed )
            {

                // gets the current scenario name
                string currentScenarioName = TestContext.CurrentContext.Test.Name;
                // generates the screenshot's name by using the current time and current screenshot name
                string screenshotName = DateTime.Now.ToString("MM_dd_hh_mm_") + $"sc_{currentScenarioName}" + ".jpeg";

                TakeScreenshot( screenshotName );
            }

            driver.Quit();
            driver = null;
        }

        public void IterationTearDown()
        {
            driver.Quit();
            driver = null;
        }

        #endregion
    }
}
