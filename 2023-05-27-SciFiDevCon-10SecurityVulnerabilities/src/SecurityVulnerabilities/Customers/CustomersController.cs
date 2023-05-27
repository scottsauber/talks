using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SecurityVulnerabilities.Controllers;

namespace SecurityVulnerabilities.Customers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly NpgsqlConnection _dbConnection;

    public CustomersController(NpgsqlConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    [HttpGet("{id}")]
    public Customer Get(string id)
    {
        var query = $@"SELECT id, 
                              first_name as FirstName, 
                              last_name as LastName 
                       FROM customers 
                       WHERE id=@id";

        return _dbConnection.QueryFirst<Customer>(query, new {id});
    }
}