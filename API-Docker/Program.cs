var builder = WebApplication.CreateBuilder(args);

// 👇 Configure Kestrel explicitly to listen on HTTP and HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080); // HTTP
    options.ListenAnyIP(443, listenOptions =>
    {
        listenOptions.UseHttps(); // This line uses the cert passed via ENV
    });
});

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
