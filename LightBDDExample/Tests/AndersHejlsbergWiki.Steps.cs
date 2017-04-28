using System.Collections.Generic;
using LightBDDExample.PageObjects;
using LightBDDExample.Resources.Utils;
using LightBDDExample.Resources.Utils.Enums;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LightBDDExample.Tests
{
    public partial class AndersHejlsbergWiki : AndersHejlsbergWikiObjects
    {

        private void Given_I_am_on_the_Anders_Hejlsberg_wikipedia_page( )
        {
            CustomWaits.UntilUrlContains( driver, "wikipedia.org" );
            bool currentUrlIsAndersHejlsbergWikiPage = driver.Url.Contains( "Anders_Hejlsberg" );
            Assert.IsTrue( currentUrlIsAndersHejlsbergWikiPage );
        }

        private void Then_I_should_see_the_basic_informations_in_the_infobox( )
        {
            IReadOnlyList<By> infoBoxElementLocators = new List<By>( )
            {
                 XpathLocator( HtmlTags.table,  "class",    "infobox biography vcard"               )
                ,XpathLocator( HtmlTags.span,   "text()",   "Anders Hejlsberg"                      )
                ,XpathLocator( HtmlTags.img,    "alt",      "Anders Hejlsberg.jpg"                  )
                ,XpathLocator( HtmlTags.th,     "text()",   "Born"                                  )
                ,XpathLocator( HtmlTags.span,   "class",    "birthplace"                            )
                ,XpathLocator( HtmlTags.a,      "text()",   "Copenhagen"                            )
                ,XpathLocator( HtmlTags.a,      "text()",   "Denmark"                               )
                ,XpathLocator( HtmlTags.th,     "text()",   "Nationality"                           )
                ,XpathLocator( HtmlTags.td,     "text()",   "Danish"                                )
                ,XpathLocator( HtmlTags.th,     "text()",   "Education"                             )
                ,XpathLocator( HtmlTags.a,      "href",     "/wiki/Technical_University_of_Denmark" )
                ,XpathLocator( HtmlTags.th,     "text()",   "Occupation"                            )
                ,XpathLocator( HtmlTags.a,      "text()",   "Programmer"                            )
                ,XpathLocator( HtmlTags.a,      "href",     "/wiki/Systems_architect"               )
                ,XpathLocator( HtmlTags.th,     "text()",   "Employer"                              )
                ,XpathLocator( HtmlTags.a,      "title",    "Microsoft"                             )
                ,XpathLocator( HtmlTags.a,      "text()",   "Programming languages"                 )
                ,XpathLocator( HtmlTags.a,      "title",    "Turbo Pascal"                          )
                ,XpathLocator( HtmlTags.a,      "title",    "Embarcadero Delphi"                    )
                ,XpathLocator( HtmlTags.a,      "title",    "C Sharp (programming language)"        )
                ,XpathLocator( HtmlTags.a,      "title",    "TypeScript"                            )
                ,XpathLocator( HtmlTags.th,     "text()",   "Title"                                 )
                ,XpathLocator( HtmlTags.td,     "class",    "title"                                 )
                ,XpathLocator( HtmlTags.th,     "text()",   "Awards"                                )

                ,XpathLocator( HtmlTags.th, LocatorStrategy.contains, "text()", "Employer"          )
            };

            Assert.IsTrue( CheckElementLocatorsInListVisibility( infoBoxElementLocators ) );
        }

        private void Then_I_should_see_every_link_in_the_Contents_menu( string linkText )
        {
            IWebElement contentsBox = FindElement( driver, By.Id( "toc" ) );
            contentsBox.FindElement( By.XPath( string.Format( ".//span[ text() = '{0}' ]", linkText ) ) );
        }

        private void When_I_click_on_a_link_in_the_Contents_menu( string linkHref )
        {
            IWebElement contentsBox = FindElement( driver, By.Id( "toc" ) );
            IWebElement currentLink = contentsBox.FindElement( By.XPath( string.Format( ".//a[ @href = '{0}' ]", linkHref ) ) );

            currentLink.Click( );
        }

        private void Then_it_should_take_me_to_the_given_page_section( string pageSectionUrl )
        {
            CustomWaits.UntilUrlContains( driver, pageSectionUrl );
        }
    }
}