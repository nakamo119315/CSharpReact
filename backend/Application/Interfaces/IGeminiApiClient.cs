namespace backend.Application.Interfaces;

public interface IGeminiClient
{
    Task<string> GetResponseAsync(string prompt);
}
