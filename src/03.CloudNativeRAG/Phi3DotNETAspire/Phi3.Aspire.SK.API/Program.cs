using System;
using System.Text.Json;
using Phi3.Aspire.SK.API.Domains;
using Phi3.Aspire.SK.API.Utils;

var builder = WebApplication.CreateBuilder(args);


// Add service defaults & Aspire components.
builder.AddServiceDefaults();



builder.Services.AddHttpClient<Phi3Client>(client =>
    {
        client.BaseAddress = new("https+http://phi3service");
        client.Timeout = TimeSpan.FromSeconds(600);
    });
    // .AddStandardResilienceHandler(config =>
    // {
    //     TimeSpan timeSpan = TimeSpan.FromMinutes(10);
    //     config.AttemptTimeout.Timeout = timeSpan;
    //     config.CircuitBreaker.SamplingDuration = timeSpan * 2;
    //     config.TotalRequestTimeout.Timeout = timeSpan * 3;
    // });

// builder.AddQdrantClient("qdrant", settings => settings.ApiKey = "1a2b3c4D##");

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();



app.MapPost("/api/chat",async(RequestPrompt request,Phi3Client phi3Client) => {

    string questionText = request.Prompt;

    string result = await phi3Client.GetChatCompetions(questionText);

    return new{gen_text = result};

    // return await phi3Client.GetChatCompetions(questionText);

    // string url = "https+http://phi3service/v1/chat/completions/models/phi3-mini";

    // var client = new HttpClient();

    // var httpRequest = new HttpRequestMessage(HttpMethod.Post, url){
    //     Content = new StringContent("{\"inputs\": \"" + questionText + "\"}", System.Text.Encoding.UTF8, "application/json")
    // };

    // var response = await client.SendAsync(httpRequest);

    // if (response.IsSuccessStatusCode)
    // {
    //     var responseContent = await response.Content.ReadAsStringAsync();
    //     var result = JsonSerializer.Deserialize<IList<GenText>>(responseContent)!;
    //     return result[0].generated_text;
    // }
    // else
    // {
    //     return "";
    // }

});


app.MapDefaultEndpoints();

app.Run();
