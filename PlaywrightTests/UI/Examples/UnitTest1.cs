using Playwright.MyTests._base;

namespace PlaywrightTests
{   
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : MyTestBase
    { 

        [Test]
        public async Task HeaderLogoShouldBeDisplayed()
        {
            var homePage = new HomePage(_page);
            await homePage.GoTo();
            await homePage.AssertLogoIsDisplayed();
        } 
    }
}
