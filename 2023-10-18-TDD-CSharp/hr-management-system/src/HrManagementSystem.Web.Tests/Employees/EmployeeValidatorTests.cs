using FluentAssertions;
using HrManagementSystem.Core.Employees;
using HrManagementSystem.Core.Models;

namespace HrManagementSystem.Web.Tests.Employees;

public class EmployeeValidatorTests
{
    private readonly Employee _employee;
    private readonly EmployeeValidator _validator;

    public EmployeeValidatorTests()
    {
        _employee = new Employee
        {
            FirstName = null
        };
        _validator = new EmployeeValidator();
    }

    [Fact]
    public void ValidateShouldReturnErrorWhenFirstNameIsNull()
    {
        var errors = _validator.Validate(_employee);

        errors.Should().Contain(new ValidationError(nameof(Employee.FirstName), "First name is required"));
    }
    
    [Fact]
    public void ValidateShouldNotReturnErrorWhenFirstNameIsNotNull()
    {
        _employee.FirstName = Guid.NewGuid().ToString();

        var errors = _validator.Validate(_employee);

        errors.Should().NotContain(new ValidationError(nameof(Employee.FirstName), "First name is required"));
    }
}