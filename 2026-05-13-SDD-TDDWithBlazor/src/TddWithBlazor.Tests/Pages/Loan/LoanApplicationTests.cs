using Bunit;
using Shouldly;
using TddWithBlazor.Client.Pages.Loan;

namespace TddWithBlazor.Tests.Pages.Loan;

public class LoanApplicationTests
{
    [Fact]
    public void ShouldShowValidationErrorWhenFirstNameIsNull()
    {
        using var context = new TestContext();
        var component = context.RenderComponent<LoanApplication>();

        component.FindAll("#message").ShouldBeEmpty();

        var firstNameInput = component.Find("#first-name");
        // var firstNameInput = component.FindByLabelText("First Name");
        var firstName = "Bluey";
        var lastName = "Heeler";
        firstNameInput.Change(firstName);      
        var lastNameInput = component.Find("#last-name");
        lastNameInput.Change(lastName);
        var button = component.Find("button");
        button.Click();

        var message = component.FindAll("#message");
        message.Single().TextContent.ShouldBe($"Thank you for submitting {firstName} {lastName}!");
    }
}