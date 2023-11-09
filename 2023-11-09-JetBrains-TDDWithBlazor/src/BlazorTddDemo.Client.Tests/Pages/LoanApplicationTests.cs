using AngleSharp.Dom;
using BlazorTddDemo.Client.Pages;
using Bunit;
using FluentAssertions;

namespace BlazorTddDemo.Client.Tests.Pages;

public class LoanApplicationTests
{
    [Fact]
    public void ShouldShowValidationErrorWhenFirstNameIsNull()
    {
        using var context = new TestContext();
        var component = context.RenderComponent<LoanApplication>();

        component.FindAll("#message").Should().BeEmpty();

        var firstName = component.Find("#first-name");
        // var firstName = component.FindByLabelText("First Name");
        firstName.Change("Bluey");      
        var lastName = component.Find("#last-name");
        lastName.Change("Heeler");
        var button = component.Find("button");
        button.Click();

        var message = component.FindAll("#message");
        message.Single().TextContent.Should().Be("Thank you for submitting!");
    }
}