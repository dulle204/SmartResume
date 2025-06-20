using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.AI;

namespace SmartResume.Application.Analyze;

public class AnalyzeService(IChatClient chatClient) : IAnalyzeService
{
    public async Task<string> AnalyzeCvAsync(IFormFile file)
    {
        using var stream = file.OpenReadStream();
        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();
        ChatOptions chatOptions = new ChatOptions()
        {
            ResponseFormat = ChatResponseFormat.Json,
            Temperature = 0f,
            MaxOutputTokens = 128
        };
        var chatCompletion = await chatClient.GetResponseAsync($"analyze cv:  {content}", chatOptions);
        
        return $"CV Analysis Result: {chatCompletion.Text}";
    }
}