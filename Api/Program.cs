using Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChatDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetValue<string>("CONNECTION_STRING") ?? throw new Exception("Missing CONNECTION_STRING environment variable")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
