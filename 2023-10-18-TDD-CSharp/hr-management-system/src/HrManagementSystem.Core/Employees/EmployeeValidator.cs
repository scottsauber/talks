using HrManagementSystem.Core.Models;

namespace HrManagementSystem.Core.Employees;

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