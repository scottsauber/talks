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
        connectionString: "Server=localhost;Port=5433;User Id=postgres;Password=postgres;Database=a_site_to_order_stuff_local;");
}

void SeedData()
{
    var postgresConnection = CreatePostgresConnection();

    var spongeBobId = Guid.Parse("63142066-CB99-462E-907E-9EE6076715E7");
    InsertIfMissing(postgresConnection, spongeBobId, "Spongebob", "Squarepants");
    
    var scoobyDooId = Guid.Parse("A27B68A5-33B1-464C-85DB-F9F5FFC3E841");
    InsertIfMissing(postgresConnection, scoobyDooId, "Scooby", "Doo");
}

void InsertIfMissing(NpgsqlConnection npgsqlConnection, Guid guid, string firstName, string LastName)
{
    if (npgsqlConnection.QueryFirstOrDefault<Customer>("SELECT * FROM customers WHERE id=@id", new { id = guid }) ==
        null)
    {
        var insertSql = "INSERT INTO customers (id, first_name, last_name) VALUES (@Id, @FirstName, @LastName)";
        npgsqlConnection.Execute(insertSql, new { Id = guid, FirstName = firstName, LastName = LastName });
    }
}