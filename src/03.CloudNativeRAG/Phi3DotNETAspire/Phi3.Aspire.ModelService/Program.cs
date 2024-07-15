using Microsoft.ML.OnnxRuntimeGenAI;
using Phi3.Aspire.ModelService.Agents;
using Phi3.Aspire.ModelService.Domains;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// builder.Services.ConfigureHttpClientDefaults(http =>
// {
//     http.AddStandardResilienceHandler(o =>
//     {
//         o.AttemptTimeout.Timeout = TimeSpan.FromSeconds(180);
//         o.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(540); // Must be larger than AttemptTimeout
//         o.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(360); //Must be at least 2 x AttemptTimeout
//     });

//     // Turn on service discovery by default
    
// });

// builder.Services.AddHttpClient("hgface", c =>
// {
//     c.BaseAddress = new Uri("http://llm");
//     c.Timeout = TimeSpan.FromSeconds(540);
// });

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapGet("/", () => "Welcome to access Phi-3-mini API Service");

app.MapPost("/v1/chat/completions/models/{model}", (string model,RequestPrompt prompt) =>
{
    var response =  Phi3Agent.ChatWithPhi3HuggingFaceAsync(prompt.inputs);
    
    return response;
});

app.MapPost("/v1/chat/completions", (ChatRequestPrompt request) =>
{
    var response = Phi3Agent.ChatWithPhi3OpenAIAsync(request.Messages);

    var list = JsonSerializer.Deserialize<IList<KBInfo>>(response.generated_text);

    string content  = "";
    int i = 1;
    foreach(var item in list)
    {
        content  += "{\"index\": "+i.ToString()+",\"message\": {\"role\": \"assistant\",\"content\": \""+ item.KB+"-"+ item.Content +"\"},\"finish_reason\": \"stop\"}";
        i+=1;
        if(i <= list.Count)
        {
            content += ",";
        }
    }

    string template  = "{\"id\": \"chatphi3-123\",\"object\": \"chat.completion\",\"created\": 1677652288,\"model\": \"microsoft-phi-3-mini\",\"choices\": [";

    string json = template + content + "]}";

    
    // string json = "{\"id\": \"chatphi3-123\",\"object\": \"chat.completion\",\"created\": 1677652288,\"model\": \"microsoft-phi-3-mini\",\"choices\": [{\"index\": 0,\"message\": {\"role\": \"assistant\",\"content\": \'"+ response.generated_text.Replace("\n","").ToString() +"\'},\"finish_reason\": \"stop\"}]}";  


    // Console.WriteLine(json);
    // string result = "{ \"object\": \"chat.completion\", \"model\": \"phi-3-mini\", \"usage\": { \"prompt_tokens\": 2048, \"completion_tokens\": 2048, \"total_tokens\": 2048 }, \"choices\": [ { \"message\": { \"role\": \"assistant\", \"content\": " + response.generated_text +" }, \"finish_reason\": \"stop\", \"index\": 0 } ] }";

    // string result = "{\"choices\": [{\"message\": {\"role\": \"assistant\",\"content\": " + response.generated_text.ToString() +"}}]}";   

    // var resultObject = JsonSerializer.Deserialize<dynamic>(json);

    // IList<Root> resultObjectList = new List<Root>();
    // RepsonseChatJson resultObject = new RepsonseChatJson{ Role = "assistant", InnerContent = response.generated_text.ToString()};
    // resultObjectList.Add(resultObject);

    return json;
});


app.MapDefaultEndpoints();

app.Run();
