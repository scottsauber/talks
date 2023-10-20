using FluentAssertions;
using HrManagementSystem.Web.Models;
using HrManagementSystem.Web.Validators;

namespace HrManagementSystem.Web.Tests;

public class EmployeeValidatorTests
{
    private readonly Employee _employee;
    private readonly EmployeeValidator _validator;
    private readonly ValidationError _firstNameValidationError = new(nameof(Employee.FirstName), "First name is required");

    public EmployeeValidatorTests()
    {
        _employee = new Employee();
        _validator = new EmployeeValidator();
    }

    [Fact]
    public void ValidateShouldReturnAnErrorWhenFirstNameIsNull()
    {
        _employee.FirstName = null;

        var errors = _validator.Validate(_employee);

        errors.Should().Contain(_firstNameValidationError);
    }

    [Fact]
    public void ValidateShouldNotReturnAnErrorWhenFirstNameIsNotNull()
    {
        _employee.FirstName = Guid.NewGuid().ToString();

        var errors = _validator.Validate(_employee);

        errors.Should().NotContain(_firstNameValidationError);
    }
}