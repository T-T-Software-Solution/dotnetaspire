var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");
var rabbit = builder.AddRabbitMQContainer("rabbit");

var apiservice = builder.AddProject<Projects.AspireSample_ApiService>("apiservice");

builder.AddProject<Projects.AspireSample_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiservice)
    .WithReference(rabbit);

builder.Build().Run();
