var builder = DistributedApplication.CreateBuilder(args);


var cache = builder.AddRedis("cache");


var phi3service = builder.AddProject<Projects.Phi3_Aspire_ModelService>("phi3service");



var skService = builder.AddProject<Projects.Phi3_Aspire_SK_API>("skservice")
                .WithExternalHttpEndpoints()
                .WithReference(phi3service);


builder.AddNpmApp("vue", "../Phi3.Aspire.Vue")
    .WithReference(skService)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();


builder.Build().Run();
