using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.HuggingFace;
using Microsoft.SemanticKernel.TextGeneration;
using Microsoft.SemanticKernel.Embeddings;
using SmartComponents.LocalEmbeddings;
using SmartComponents.LocalEmbeddings.SemanticKernel;

using Microsoft.SemanticKernel.Memory;
using Microsoft.SemanticKernel.Connectors.Qdrant;

using Phi3.Aspire.SK.RAG.API.Domains;

var builder = WebApplication.CreateBuilder(args);


// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.AddQdrantClient("qdrant");

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();



    
string chat_endpoint = "http://localhost:5257/v1/chat/completions/";

#pragma warning disable SKEXP0070

Kernel kernel = Kernel.CreateBuilder()
                                .AddLocalTextEmbeddingGeneration()
                                .AddHuggingFaceTextGeneration(
                                    model: "phi-3-mini",
                                    endpoint: new Uri(chat_endpoint))
                                .Build();

#pragma warning disable SKEXP0001

var embeddingGenerator = kernel.GetRequiredService<ITextEmbeddingGenerationService>();

#pragma warning disable SKEXP0001
#pragma warning disable SKEXP0020

var qdrantMemoryBuilder = new MemoryBuilder();

qdrantMemoryBuilder.WithTextEmbeddingGeneration(embeddingGenerator);
var qdrantURL = builder.Configuration.GetConnectionString("qdrant");
var endpoint = ExtractValueFromEndpoint(qdrantURL, "Endpoint");
var key = ExtractValueFromEndpoint(qdrantURL, "Key");
var port = ExtractPort(endpoint);

// 
HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Add("api-key", key);
client.BaseAddress = new Uri("http://localhost:"+port);

qdrantMemoryBuilder.WithQdrantMemoryStore(client,768);

Console.WriteLine("Qdrant URL: " + "http://localhost:"+port);

    
var qdrantBuilder = qdrantMemoryBuilder.Build();


app.MapPost("/api/rag", async (RequestPrompt request) => {

    string questionText = request.Prompt;


    var searchResults =  qdrantBuilder.SearchAsync("demo_kb_db", questionText, limit: 1, minRelevanceScore: 0.7);

    string result = "";

    await foreach (var item in searchResults)
    {
        // Console.WriteLine(item.Metadata.Text + " : " + item.Relevance);

        result = item.Metadata.Text;
    } 

    return result;

});

string ExtractValueFromEndpoint(string endpointString, string valueName)
{
        string[] parts = endpointString.Split(';');
        foreach (var part in parts)
        {
            if (part.StartsWith(valueName, StringComparison.OrdinalIgnoreCase))
            {
                return part.Substring(part.IndexOf('=') + 1);
            }
        }
        return null;
}

string ExtractPort(string endpointString)
{
    var port = endpointString.Substring(endpointString.LastIndexOf(':') + 1);
    Console.WriteLine("Port: " + port);
    return (Convert.ToInt32(port)+1).ToString();
}



app.MapDefaultEndpoints();

app.Run();
