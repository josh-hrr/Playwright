using Microsoft.Playwright;  
using Microsoft.Playwright.NUnit;
using PlaywrightTests.driver; 

namespace Playwright.MyTests._base
{
    public class MyTestBase
    {
        protected IBrowserContext _context;
        protected IPage _page; 
        
        [SetUp]
        public async Task Setup()
        {
            _context = await PlaywrightDriver.Initialize("chromium", false); 
            _page = await _context.NewPageAsync();
        } 
    }
}
