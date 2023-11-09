using Bunit;
using Counter = BlazorTddDemo.Client.Pages.Counter;
using FluentAssertions;

namespace BlazorTddDemo.Client.Tests;

[UsesVerify]
public class CounterTests
{
    [Fact]
    public void ShouldIncrementCountWhenClickingButton()
    {
        using var testContext = new TestContext();
        
        var component = testContext.RenderComponent<Counter>();
        var button = component.Find("button");
        button.Click();

        var currentCount = component.Find("[role='status']");
        currentCount.TextContent.Should().Be("Current count: 1");
    }
    
    // [Fact]
    // public Task SnapshotExample()
    // {
    //     VerifyBunit.Initialize();
    //     using var testContext = new TestContext();
    //     
    //     var component = testContext.RenderComponent<Counter>();
    //     var button = component.Find("button");
    //     button.Click();
    //
    //     return Verify(component.Markup);
    // }
}