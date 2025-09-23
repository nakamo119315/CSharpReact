namespace backend.Application.Services;
using Interfaces;

public class GeminiService
{
    private readonly IGeminiClient _client;

    public GeminiService(IGeminiClient client)
    {
        _client = client;
    }

    public async Task<string> AskAsync(string prompt)
    {
        // ドメインルールがあればここに追加
        return await _client.GetResponseAsync(prompt);
    }
}
