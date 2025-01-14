using FeedR.Aggregator.Services;
using FeedR.Shared.Messaging;
using FeedR.Shared.Pulsar;
using FeedR.Shared.Redis;
using FeedR.Shared.Redis.Streaming;
using FeedR.Shared.Serialization;
using FeedR.Shared.Streaming;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddHostedService<PricingStreamBackgroundService>()
    .AddHostedService<WeatherStreamBackgroundService>()
    .AddSerialization()
    .AddStreaming()
    .AddRedis(builder.Configuration)
    .AddRedisStreaming()
    .AddMessaging()
    .AddPulsar()
    .AddSingleton<IPricingHandler, PricingHandler>();
    
var app = builder.Build();

app.MapGet("/", () => "FeedR Aggregator");

app.Run();