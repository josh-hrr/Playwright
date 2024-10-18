using Microsoft.Playwright;

namespace PlaywrightTests.driver
{
    public static class PlaywrightDriver
    {
        public static async Task <IBrowserContext> Initialize(string browserType, bool headless, bool enableTracing = false)
        {   
            var browser = await InitBrowserAsync(browserType, headless);
            IBrowserContext context = await browser.NewContextAsync();

            if(enableTracing)
            {
                await context.Tracing.StartAsync(new TracingStartOptions
                {
                    Screenshots = true,
                    Snapshots = true,
                });
            }
            return context;
        }

        public static async Task <IBrowser> InitBrowserAsync(string browserType, bool headless)
        {
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            BrowserTypeLaunchOptions launchOptions = new BrowserTypeLaunchOptions { Headless = headless };
            return browserType switch
            {
                "chromium" => await playwright.Chromium.LaunchAsync(launchOptions),
                "firefox" => await playwright.Firefox.LaunchAsync(launchOptions),
                "webkit" => await playwright.Webkit.LaunchAsync(launchOptions),
                _ => throw new ArgumentException("Invalid browser type, Only Chromium, Firefox and Webkit are supported"),
            };
        }
    }
}