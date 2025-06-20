using Microsoft.AspNetCore.Http;

namespace SmartResume.Application.Analyze;

public interface IAnalyzeService
{
    Task<string> AnalyzeCvAsync(IFormFile file);
}