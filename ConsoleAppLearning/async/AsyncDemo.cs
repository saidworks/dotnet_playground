using System.Text;
using System.Text.Json;

namespace ConsoleAppLearning.async;
using Microsoft.Extensions.Logging;

public class AsyncDemo
{
    private ILogger<AsyncDemo> _logger;
    private static HttpClient client = new HttpClient();
    
    public AsyncDemo(ILogger<AsyncDemo> logger)
    {
        _logger = logger;
    }
    public static async Task simulateDelay()
    {
        await Task.Delay(1000);
        Console.WriteLine("Done");
    }

    public async Task DownloadDataAsync()
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("http://colormind.io/list/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            _logger.LogInformation(responseBody);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
    }

    public async Task<string> GetColorPaletteAsync()
    {
        try
        {
            // Create the input data structure
            var inputData = new
            {
                input = new object[] { 
                    new[] { 44, 43, 44 }, 
                    new[] { 90, 83, 82 }, 
                    "N", 
                    "N", 
                    "N" 
                },
                model = "default"
            };

            // Serialize to JSON
            var jsonContent = JsonSerializer.Serialize(inputData);
            _logger.LogInformation($"Sending request with data: {jsonContent}");

            // Create StringContent for the request
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Send POST request
            var response = await client.PostAsync("http://colormind.io/api/", content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"Received response: {responseBody}");
                
            return responseBody;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting color palette: {Message}", e.Message);
            throw;
        }
    }
    
    public async Task multipleHttpRequests()
    {
        try
        {
            Task task1 = GetColorPaletteAsync();
            Task task2 = DownloadDataAsync();
            await Task.WhenAll(task1, task2);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting color palette: {Message}", e.Message);
            throw;
        }

    }

}