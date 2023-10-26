using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace SecurityVulnerabilities.Documents;

[ApiController]
[Route("[controller]")]
public class SafeDocumentsController : ControllerBase
{
    private readonly NpgsqlConnection _dbConnection;

    public SafeDocumentsController(NpgsqlConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    [HttpGet]
    public string GetFile(string id)
    {
        var filePath = GetFilePathById(Guid.Parse(id));
        return System.IO.File.ReadAllText(filePath);
    }

    [HttpPost]
    public IActionResult CreateFile([FromBody] CreateFileRequest request)
    {
        System.IO.File.WriteAllText(Path.Combine("Documents", $"{Guid.NewGuid()}.txt"), request.FileContents);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    private string GetFilePathById(Guid id) =>
        _dbConnection.QueryFirst<string>("SELECT file_path FROM documents WHERE id=@id", new { id });
}
