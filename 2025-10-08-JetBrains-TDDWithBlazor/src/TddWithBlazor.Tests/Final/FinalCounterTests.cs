using Bunit;
using Shouldly;
using TddWithBlazor.Client.Pages;

namespace TddWithBlazor.Tests.Final;

public class FinalCounterTests : TestContext
{
    [Fact]
    public void ShouldHaveAnInitialCountOfZeroWhenComponentLoads()
    {
        var component = RenderComponent<Counter>();
        
        var countDisplay = component.Find("#current-count");
        countDisplay.TextContent.ShouldBe("Current count: 0");
    }

    [Fact]
    public void ShouldIncrementCurrentCountWhenIncrementButtonIsClicked()
    {
        var component = RenderComponent<Counter>();
        
        var currentCount = component.Find("#current-count");
        var incrementButton = component.Find("button");
        incrementButton.Click();
        
        currentCount.TextContent.ShouldBe("Current count: 1");
    }
}