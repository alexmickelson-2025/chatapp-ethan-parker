using ImageApi.Services;
using ImageApi.Services.Constants;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IImageService, ImageService>();
builder.Services.AddSingleton<IConstants, Constants>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

app.MapControllers();


// app.UseStaticFiles();

app.Run();

