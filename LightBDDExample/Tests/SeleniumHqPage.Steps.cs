using System.Collections.Generic;
using LightBDDExample.PageObjects;
using LightBDDExample.Resources.Utils;
using LightBDDExample.Resources.Utils.Enums;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LightBDDExample.Tests
{
    public partial class SeleniumHqPage : SeleniumHqPageMainObjects
    {
        private void Given_I_am_on_the_Selenium_HQ_main_page( )
        {
            CustomWaits.UntilUrlContains( driver, "seleniumhq.org" );
        }

        private void Then_I_see_the_basic_elements( )
        {
            List<By> mainPageBasicElementList = new List<By>( )
            {
                 By.Id( "container"             )
                ,By.Id( "header"                )
                ,By.Id( "q"                     )
                ,By.Id( "submit"                )
                ,By.Id( "menu_projects"         )
                ,By.Id( "menu_download"         )
                ,By.Id( "menu_documentation"    )
                ,By.Id( "menu_support"          )
                ,By.Id( "menu_about"            )
                ,By.Id( "choice"                )
                ,By.Id( "footer"                )
                ,By.Id( "sitemap"               )

                ,XpathLocator( HtmlTags.a,      "title",    "Return to Selenium home page"      )
                ,XpathLocator( HtmlTags.a,      "title",    "Selenium Projects"                 )
                ,XpathLocator( HtmlTags.a,      "title",    "Get Selenium"                      )
                ,XpathLocator( HtmlTags.a,      "title",    "Technical references and guides"   )
                ,XpathLocator( HtmlTags.a,      "title",    "Get help with Selenium"            )
                ,XpathLocator( HtmlTags.a,      "title",    "Overview of Selenium"              )
                ,XpathLocator( HtmlTags.img,    "alt",      "Selenium Logo"                     )
                ,XpathLocator( HtmlTags.div,    "class",    "ads"                               )
                ,XpathLocator( HtmlTags.div,    "class",    "downloadBox"                       )
                ,XpathLocator( HtmlTags.div,    "class",    "selenium-sponsors"                 )

            };

            Assert.IsTrue( CheckElementLocatorsInListVisibility( mainPageBasicElementList ) );
        }

        private void When_I_click_on_the_navigation_links( string titleOfLink )
        {
            IWebElement currentNavigationLink = FindElement( driver, XpathLocator( HtmlTags.a, "title", titleOfLink ) );

            currentNavigationLink.Click( );
        }

        private void Then_I_should_be_taken_to_the_given_subpage( string subpageUrlPartial )
        {
            CustomWaits.UntilUrlContains( driver, subpageUrlPartial );
        }

        private void When_I_click_on_the_given_navigation_link( SeleniumHqNavigation currentNavigationLink )
        {
            IWebElement currentNavigationElement;

            switch ( currentNavigationLink )
            {
                case SeleniumHqNavigation.Projects:
                    currentNavigationElement = FindElement( driver, By.XPath( "//a[ @href= '/projects/' ]" ) );
                    break;
                case SeleniumHqNavigation.Download:
                    currentNavigationElement = FindElement( driver, By.XPath( "//a[ @href= '/download/' ]" ) );
                    break;
                case SeleniumHqNavigation.Documentation:
                    currentNavigationElement = FindElement( driver, By.XPath( "//a[ @href= '/docs/' ]" ) );
                    break;
                case SeleniumHqNavigation.Support:
                    currentNavigationElement = FindElement( driver, By.XPath( "//a[ @href= '/support/' ]" ) );
                    break;
                case SeleniumHqNavigation.About:
                    currentNavigationElement = FindElement( driver, By.XPath( "//a[ @href= '/about/' ]" ) );
                    break;
                default:
                    currentNavigationElement = FindElement( driver, By.XPath( "//a[ @href= '/' ]" ) );
                    break;
            }
            currentNavigationElement.Click( );
        }

        private void Then_I_should_be_arrive_on_the_given_page( SeleniumHqNavigation currentNavigation )
        {
            string expectedPartialUrl = null;

            switch ( currentNavigation )
            {
                case SeleniumHqNavigation.Projects:
                    expectedPartialUrl = "/projects/";
                    break;
                case SeleniumHqNavigation.Download:
                    expectedPartialUrl = "/download/";
                    break;
                case SeleniumHqNavigation.Documentation:
                    expectedPartialUrl = "/docs/";
                    break;
                case SeleniumHqNavigation.Support:
                    expectedPartialUrl = "/support/";
                    break;
                case SeleniumHqNavigation.About:
                    expectedPartialUrl = "/about/";
                    break;
            }
            if ( expectedPartialUrl != null )
            {
                CustomWaits.UntilUrlContains( driver, expectedPartialUrl );
            }
        }

        private void Then_I_should_see_the_main_elements_of_the_projects_page( )
        {
            List<By> projectsPageBasicElementList = new List<By>( )
            {
                 XpathLocator( HtmlTags.img,    "alt",  "Selenium Logo"                 )
                ,XpathLocator( HtmlTags.img,    "alt",  "Selenium Grid Logo"            )
                ,XpathLocator( HtmlTags.img,    "alt",  "Selenium IDE Logo"             )
                ,XpathLocator( HtmlTags.img,    "alt",  "Selenium Remote Control Logo"  )
                ,XpathLocator( HtmlTags.a,      "href", "webdriver/"                    )
                ,XpathLocator( HtmlTags.a,      "href", "grid/"                         )
                ,XpathLocator( HtmlTags.a,      "href", "ide/"                          )
                ,XpathLocator( HtmlTags.a,      "href", "remote-control/"               )

            };

            Assert.IsTrue( CheckElementLocatorsInListVisibility( projectsPageBasicElementList ) );
        }

        private void Then_I_should_see_the_main_elements_of_the_download_page( )
        {
            List<By> downloadPageBasicElementList = new List<By>( )
            {
                 By.Id( "nav"           )
                ,By.Id( "mainContent"   )
            };

            Assert.IsTrue( CheckElementLocatorsInListVisibility( downloadPageBasicElementList ) );
        }

        private void Then_I_should_see_the_main_elements_of_the_documentation_page( )
        {
            List<By> documentationPageBasicElementList = new List<By>( )
            {
                 XpathLocator( HtmlTags.input,  "value",  "java"        )
                ,XpathLocator( HtmlTags.input,  "value",  "csharp"      )
                ,XpathLocator( HtmlTags.input,  "value",  "python"      )
                ,XpathLocator( HtmlTags.input,  "value",  "ruby"        )
                ,XpathLocator( HtmlTags.input,  "value", "php"          )
                ,XpathLocator( HtmlTags.input,  "value", "perl"         )
                ,XpathLocator( HtmlTags.input,  "value", "javascript"   )

            };

            Assert.IsTrue( CheckElementLocatorsInListVisibility( documentationPageBasicElementList ) );
        }

        private void Then_I_should_see_the_main_elements_of_the_support_page( )
        {
            List<By> supportPageBasicElementList = new List<By>( )
            {
                 By.Id( "mainContent"       )
                ,By.Id( "IRC"               )
                ,By.Id( "BugTracker"        )
                ,By.Id( "CommercialSupport" )
            };

            Assert.IsTrue( CheckElementLocatorsInListVisibility( supportPageBasicElementList ) );
        }

        private void Then_I_should_see_the_main_elements_of_the_about_page( )
        {
            List<By> aboutPageBasicElementList = new List<By>( )
            {
                 XpathLocator( HtmlTags.a,  "href",  "/about/news.jsp"              )
                ,XpathLocator( HtmlTags.a,  "href",  "/about/events.html"           )
                ,XpathLocator( HtmlTags.a,  "href",  "/sponsor"                     )
                ,XpathLocator( HtmlTags.a,  "href",  "/sponsors"                    )
                ,XpathLocator( HtmlTags.a,  "href", "/about/contributors.html"      )
                ,XpathLocator( HtmlTags.a,  "href", "/ecosystem"                    )
                ,XpathLocator( HtmlTags.a,  "href", "/about/license.html"           )
                ,XpathLocator( HtmlTags.a,  "href", "/about/history.html"           )
                ,XpathLocator( HtmlTags.a,  "href", "/about/getting-involved.html"  )

            };

            Assert.IsTrue( CheckElementLocatorsInListVisibility( aboutPageBasicElementList ) );
        }
    }
}