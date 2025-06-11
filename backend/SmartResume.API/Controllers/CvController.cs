using Microsoft.AspNetCore.Mvc;
using SmartResume.Application.Analyze;

namespace SmartResume.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CvController(IAnalyzeService analyzeService) : ControllerBase
{
    [HttpPost("analyze")]
    public async Task<IActionResult> AnalyzeCv(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        if (!file.FileName.EndsWith(".pdf"))
            return BadRequest("Only PDF files are supported.");

        var result = await analyzeService.AnalyzeCvAsync(file);
       
        return Ok(result);
    }
}