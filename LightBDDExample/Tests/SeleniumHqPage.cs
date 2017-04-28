using System.Collections.Generic;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios.Basic;
using LightBDD.Framework.Scenarios.Extended;
using LightBDD.NUnit3;
using LightBDDExample.Resources.Utils.Enums;
using NUnit.Framework;

namespace LightBDDExample.Tests
{
    [Label( "SELENIUM_HQ" )]
    [FeatureDescription( "Basic tests of Selenium HQ" )]
    public partial class SeleniumHqPage
    {
        [SetUp]
        public void NavigateToSeleniumHqMainPage( )
        {
            GoToSeleniumHq( );
        }

        [Label( "MAIN_PAGE" )]
        [Scenario]
        public void Check_some_of_the_basic_elements_on_the_main_page( )
        {
            Runner.RunScenario(
                _ => Given_I_am_on_the_Selenium_HQ_main_page( ),
                _ => Then_I_see_the_basic_elements          ( ) 
                );
        }

        [Label( "NAVIGATION" )]
        [Scenario]
        public void Check_the_navigation_bar( )
        {

            Dictionary<string, string> navigationTitlesAndSubPageUrlPartials = new Dictionary<string, string>( )
            {
                 [ "Selenium Projects"                  ] = "projects"
                ,[ "Get Selenium"                       ] = "download"
                ,[ "Technical references and guides"    ] = "docs"
                ,[ "Get help with Selenium"             ] = "support"
                ,[ "Overview of Selenium"               ] = "about"
            };

            int iteratorCounter = 0;

            foreach ( KeyValuePair<string, string> currentNavigationTitleAndSubPageUrl in navigationTitlesAndSubPageUrlPartials )
            {
                if( iteratorCounter != 0 )
                {
                    Setup( );
                    GoToSeleniumHq( );
                }

                Runner.RunScenario(
                    _ => Given_I_am_on_the_Selenium_HQ_main_page    ( ),
                    _ => When_I_click_on_the_navigation_links       ( currentNavigationTitleAndSubPageUrl.Key   ),
                    _ => Then_I_should_be_taken_to_the_given_subpage( currentNavigationTitleAndSubPageUrl.Value )
                    );

                if( iteratorCounter != navigationTitlesAndSubPageUrlPartials.Count - 1 )
                {
                    IterationTearDown( );
                }

                ++iteratorCounter;
            }
        }

        [Label( "PROJECTS_PAGE" )]
        [Scenario]
        public void Check_the_basic_elements_of_projects_page( )
        {
            Runner.RunScenario(
                _ => Given_I_am_on_the_Selenium_HQ_main_page                    ( ),
                _ => When_I_click_on_the_given_navigation_link                  ( SeleniumHqNavigation.Projects ),
                _ => Then_I_should_be_arrive_on_the_given_page                  ( SeleniumHqNavigation.Projects ),
                _ => Then_I_should_see_the_main_elements_of_the_projects_page   ( )
                );
        }

        [Label( "DOWNLOAD_PAGE" )]
        [Scenario]
        public void Check_the_basic_elements_of_download_page( )
        {
            Runner.RunScenario(
                _ => Given_I_am_on_the_Selenium_HQ_main_page                    ( ),
                _ => When_I_click_on_the_given_navigation_link                  ( SeleniumHqNavigation.Download ),
                _ => Then_I_should_be_arrive_on_the_given_page                  ( SeleniumHqNavigation.Download ),
                _ => Then_I_should_see_the_main_elements_of_the_download_page   ( )
                );
        }

        [Label( "DOCUMENTATION_PAGE" )]
        [Scenario]
        public void Check_the_basic_elements_of_documentation_page( )
        {
            Runner.RunScenario(
                _ => Given_I_am_on_the_Selenium_HQ_main_page                        ( ),
                _ => When_I_click_on_the_given_navigation_link                      ( SeleniumHqNavigation.Documentation ),
                _ => Then_I_should_be_arrive_on_the_given_page                      ( SeleniumHqNavigation.Documentation ),
                _ => Then_I_should_see_the_main_elements_of_the_documentation_page  ( )
                );
        }

        [Label( "SUPPORT_PAGE" )]
        [Scenario]
        public void Check_the_basic_elements_of_support_page( )
        {
            Runner.RunScenario(
                _ => Given_I_am_on_the_Selenium_HQ_main_page                    ( ),
                _ => When_I_click_on_the_given_navigation_link                  ( SeleniumHqNavigation.Support ),
                _ => Then_I_should_be_arrive_on_the_given_page                  ( SeleniumHqNavigation.Support ),
                _ => Then_I_should_see_the_main_elements_of_the_support_page    ( )
                );
        }

        [Label( "ABOUT_PAGE" )]
        [Scenario]
        public void Check_the_basic_elements_of_about_page( )
        {
            Runner.RunScenario(
                _ => Given_I_am_on_the_Selenium_HQ_main_page                ( ),
                _ => When_I_click_on_the_given_navigation_link              ( SeleniumHqNavigation.About ),
                _ => Then_I_should_be_arrive_on_the_given_page              ( SeleniumHqNavigation.About ),
                _ => Then_I_should_see_the_main_elements_of_the_about_page  ( )
                );
        }

    }
}