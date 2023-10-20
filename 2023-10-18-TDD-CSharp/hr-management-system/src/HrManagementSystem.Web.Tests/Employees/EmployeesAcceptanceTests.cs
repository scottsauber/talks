namespace HrManagementSystem.Web.Tests.Employees;

public class EmployeesAcceptanceTests : IClassFixture<HrWebApplicationFactory>
{
    private readonly HrWebApplicationFactory _webApplicationFactory;
    private readonly HttpClient _client;

    public EmployeesAcceptanceTests(HrWebApplicationFactory webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
        _client = webApplicationFactory.CreateClient();
    }

}