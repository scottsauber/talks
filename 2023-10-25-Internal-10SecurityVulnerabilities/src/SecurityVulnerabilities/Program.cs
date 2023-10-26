using Dapper;
using Npgsql;
using SecurityVulnerabilities.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<NpgsqlConnection>(_ => CreatePostgresConnection());

SeedData();

var app = builder.Build();

app.Use(async (context, next) =>
{
    // context.Response.Headers.Add("x-frame-options", "DENY");
    await next();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

NpgsqlConnection CreatePostgresConnection()
{
    return new NpgsqlConnection(
        connectionString: builder.Configuration.GetConnectionString("Postgres"));
}

void SeedData()
{
    var postgresConnection = CreatePostgresConnection();

    InsertCustomerIfMissing(postgresConnection, 
        "Spongebob", 
        "Squarepants");

    InsertCustomerIfMissing(postgresConnection, 
        "Scooby", 
        "Doo");
    
    InsertCustomerIfMissing(postgresConnection, 
        "Bluey", 
        "Heeler");
    
    InsertDocumentIfMissing(postgresConnection);
}

void InsertCustomerIfMissing(NpgsqlConnection dbConnection, string firstName, string lastName)
{
    if (dbConnection.QueryFirstOrDefault<Customer>("SELECT * FROM customers WHERE last_name=@LastName", new { LastName = lastName })
        == null)
    {
        var insertSql = "INSERT INTO customers (first_name, last_name) VALUES (@FirstName, @LastName)";
        dbConnection.Execute(insertSql, new { FirstName = firstName, LastName = lastName });
    }
}

void InsertDocumentIfMissing(NpgsqlConnection dbConnection)
{
    var count = dbConnection.ExecuteScalar<int>("SELECT COUNT(*) FROM documents");
    if (count == 0)
    {
        dbConnection.Execute("INSERT INTO documents (file_path) VALUES ('Documents\\SomeFile.txt')");
    }
}