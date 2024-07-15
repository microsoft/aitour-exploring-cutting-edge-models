var builder = DistributedApplication.CreateBuilder(args);


var cache = builder.AddRedis("cache");


// var apiKey = builder.AddParameter("apiKey", secret: true);

var qdrant = builder.AddQdrant("qdrant");





// builder.Services.ConfigureHttpClientDefaults(http =>
// {
//     http.AddStandardResilienceHandler(o =>
//     {
//         o.AttemptTimeout.Timeout = TimeSpan.FromSeconds(180);
//         o.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(540); // Must be larger than AttemptTimeout
//         o.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(360); //Must be at least 2 x AttemptTimeout
//     });

//     // // Turn on service discovery by default
//     // http.UseServiceDiscovery();
// });


var phi3service = builder.AddProject<Projects.Phi3_Aspire_ModelService>("phi3service");



var skService = builder.AddProject<Projects.Phi3_Aspire_SK_API>("skservice")
                .WithExternalHttpEndpoints()
                .WithReference(phi3service);

var skRAGService = builder.AddProject<Projects.Phi3_Aspire_SK_RAG_API>("skragservice")
                .WithExternalHttpEndpoints()
                .WithReference(qdrant)
                .WithReference(phi3service);


builder.AddNpmApp("vue", "../Phi3.Aspire.Vue")
    .WithReference(skService)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();




builder.Build().Run();
