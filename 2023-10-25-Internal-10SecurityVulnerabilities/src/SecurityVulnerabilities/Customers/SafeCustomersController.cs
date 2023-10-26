using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SecurityVulnerabilities.Controllers;

namespace SecurityVulnerabilities.Customers;

[ApiController]
[Route("[controller]")]
public class SafeCustomersController : ControllerBase
{
    private readonly NpgsqlConnection _dbConnection;

    public SafeCustomersController(NpgsqlConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    [HttpGet("{lastName}")]
    public Customer Get(string lastName)
    {
        var query = @"SELECT id, 
                             first_name as FirstName, 
                             last_name as LastName 
                       FROM customers 
                       WHERE last_name=@lastName";

        return _dbConnection.QueryFirstOrDefault<Customer>(query, new { lastName});
    }
}