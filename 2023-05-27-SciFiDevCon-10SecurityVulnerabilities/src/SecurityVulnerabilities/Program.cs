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

// Configure the HTTP request pipeline.
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

    var spongeBobId = Guid.Parse("63142066-CB99-462E-907E-9EE6076715E7");
    InsertCustomerIfMissing(postgresConnection, spongeBobId, "Spongebob", "Squarepants");

    var scoobyDooId = Guid.Parse("A27B68A5-33B1-464C-85DB-F9F5FFC3E841");
    InsertCustomerIfMissing(postgresConnection, scoobyDooId, "Scooby", "Doo");
    InsertDocumentIfMissing(postgresConnection);
}

void InsertCustomerIfMissing(NpgsqlConnection dbConnection, Guid guid, string firstName, string LastName)
{
    if (dbConnection.QueryFirstOrDefault<Customer>("SELECT * FROM customers WHERE id=@id", new { id = guid })
        == null)
    {
        var insertSql = "INSERT INTO customers (id, first_name, last_name) VALUES (@Id, @FirstName, @LastName)";
        dbConnection.Execute(insertSql, new { Id = guid, FirstName = firstName, LastName = LastName });
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