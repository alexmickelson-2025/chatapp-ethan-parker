using Api.Data;
using Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ChatDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetValue<string>("CONNECTION_STRING") ?? throw new Exception("Missing CONNECTION_STRING environment variable")));

builder.Services.AddSingleton<IMessageService, MessageService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

app.Run();
