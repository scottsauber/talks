using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace SecurityVulnerabilities.Documents;

[ApiController]
[Route("[controller]")]
public class VulnerableDocumentsController : ControllerBase
{
    [HttpGet]
    public string GetFile(string fileName)
    {
        return System.IO.File.ReadAllText(Path.Combine("Documents", fileName));
    }

    [HttpPost]
    public IActionResult CreateFile([FromBody] CreateFileRequest request)
    {
        System.IO.File.WriteAllText(Path.Combine("Documents", request.FilePath), request.FileContents);
        return StatusCode(StatusCodes.Status201Created);
    }
}
