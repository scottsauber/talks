using HrManagementSystem.Web.Models;

namespace HrManagementSystem.Web.Validators;

public class EmployeeValidator
{
    public List<ValidationError> Validate(Employee employee)
    {
        var errors = new List<ValidationError>();

        if (employee.FirstName == null)
            errors.Add(new ValidationError(nameof(Employee.FirstName), "First name is required"));

        return errors;
    }
}