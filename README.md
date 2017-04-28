# LightBDDExample
Example code for LightBDD-NUnit-C# automation test

You can run this code by Visual Studio or NUnit Console Runner.

You can even use the TestSharpRunner, which is a custom NUnit Console Runner, and you can find it here:

[TestSharpRunner repository] (https://github.com/TestSharp/TestSharpRunner)

For running these tests, please follow the description in the TestSharpRunner readme.

## Main parts of the solution ##

You can find 3 folders in the project:
    - PageObjects: Which holds the CoreObjects and the PageObject files for the different tests.
    - Resources (Utils (Enums)): Contains the utility/helper classes
    - Tests: Contains the LightBDD based test files and the EnvironmentControl class.
    
## Important classes ##

EnvironmentControl: Contains the driver setup and teardown logic, and other environment related methods.
ConfiguredLightBddScopeAttribute: Generates a HTML, XML and txt report in the Reports folder in the project's root directory after each test run.
CustomExpectedConditions: Helps with the CustomWaits
CustomWaits: There are some custom explicit waits in there. You can create new ones using these as a template.
CoreObjects: Contains helper methods for your tests to use.

#### Other notes ####

This example is more procedural than object oriented programming. Because this only contains two really small, sample tests, no reason to build a big framework for it. If it would for example test different wikipedia pages, then there would be some common objects that could be used more effectively using OOP concepts.

Also not all the created methods are used during the tests. That is just for to show you, what kind of methods you could use in your CoreObject class.