using Microsoft.Playwright;

public class HomePage {
    public readonly HomePageMap Map;
    private IPage _page; 

    public HomePage(IPage page) 
    { 
        Map = new HomePageMap(page);
        _page = page;
    } 

    public async Task GoTo() {
        await _page.GotoAsync("https://demoqa.com/");
    } 

    public async Task AssertLogoIsDisplayed() {
        await Assertions.Expect(Map.PageHeaderLogo).ToBeVisibleAsync();
    }
} 

public class HomePageMap(IPage page) {
    public ILocator PageHeaderLogo = page.Locator("img[src='/images/Toolsqa.jpg']");
}
