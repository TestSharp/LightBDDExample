using System.Collections.Generic;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios.Basic;
using LightBDD.Framework.Scenarios.Extended;
using LightBDD.NUnit3;
using NUnit.Framework;

namespace LightBDDExample.Tests
{
    // Anders Hejlsberg is a Danish software engineer. 
    // Original author of Turbo Pascal, chief architect of Delphi.
    // And most importantly (in our case) the lead architect of C#

    [Label( "ANDERS_HEJLSBERG_WIKIPEDIA" )]
    [FeatureDescription( "Test some of the basic elements of the Wikipedia page of Anders Hejlsberg" )]
    public partial class AndersHejlsbergWiki
    {

        // Setup for this test set
        // Run before every scenario
        [SetUp]
        public void NavigateToTheAndersHejlsbergWikiPage( )
        {
            GoToAndersHejlsbergWikiPage( );
        }

        [Label( "INFOBOX" )]
        [Scenario]
        public void Check_the_content_of_the_infobox( )
        {
            Runner.RunScenario(
                _ => Given_I_am_on_the_Anders_Hejlsberg_wikipedia_page          ( ),
                _ => Then_I_should_see_the_basic_informations_in_the_infobox    ( ) 
                );
        }

        [Label( "NAVIGATION" )]
        [Scenario]
        public void Check_the_Contents_navigation_elements( )
        {

            Dictionary<string, string> contentsNavigationTextAndLinks = new Dictionary<string, string>( )
            {
                 [ "Early life"      ] = "#Early_life"
                ,[ "At Borland"      ] = "#At_Borland"
                ,[ "At Microsoft"    ] = "#At_Microsoft"
                ,[ "Awards"          ] = "#Awards"
                ,[ "Published work"  ] = "#Published_work"
                ,[ "References"      ] = "#References"
                ,[ "External links"  ] = "#External_links"
                ,[ "Interviews"      ] = "#Interviews"
                ,[ "Videos"          ] = "#Videos"
            };

            int iterationCount = 0;

            foreach ( KeyValuePair<string, string> currentNavigationTextAndLink in contentsNavigationTextAndLinks )
            {
                // The SetUp NUnit attribute will only work on the scenario level
                // Therefore it only initialize the driver for the first iteration
                // This code block will initialize a new driver for every test
                if ( iterationCount != 0 )
                {
                    Setup( );
                    GoToAndersHejlsbergWikiPage( );
                }

                string currentPageSectionUrl = "https://en.wikipedia.org/wiki/Anders_Hejlsberg" + currentNavigationTextAndLink.Value;

                Runner.RunScenario(
                    _ => Given_I_am_on_the_Anders_Hejlsberg_wikipedia_page  ( ),
                    _ => Then_I_should_see_every_link_in_the_Contents_menu  ( currentNavigationTextAndLink.Key    ),
                    _ => When_I_click_on_a_link_in_the_Contents_menu        ( currentNavigationTextAndLink.Value  ),
                    _ => Then_it_should_take_me_to_the_given_page_section   ( currentPageSectionUrl )
                    );

                // The TearDown attribute works the same as the SetUp
                // Therefore we need a code block to dispose the driver after every iteration
                // except the last one
                if ( iterationCount != contentsNavigationTextAndLinks.Count - 1 )
                {
                    IterationTearDown( );
                }

                ++iterationCount;
            }
        }
    }
}