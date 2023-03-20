using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("swagger", builde =>
    {
        builde.WithOrigins("https://localhost:7110/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed((hosts) => true);
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 


builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("swagger");
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.UseOcelot();
app.MapGet("/", () => "Hello World!");
app.Run();
