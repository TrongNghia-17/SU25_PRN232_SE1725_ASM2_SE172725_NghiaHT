using SMMS.GraphQLAPIServices.NghiaHT.GraphQLs;
using SMMS.Repositories.NghiaHT.Models;
using SMMS.Services.NghiaHT;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("https://localhost:7133") // Origin của Blazor WebAssembly
              .AllowAnyMethod() // Cho phép các phương thức GET, POST, OPTIONS, v.v.
              .AllowAnyHeader(); // Cho phép các header như Content-Type
    });
});
builder.Services.AddGraphQLServer()
    .AddQueryType<Queries>()
    .AddMutationType<Mutations>()
    .BindRuntimeType<DateTime, DateTimeType>();

builder.Services.AddScoped<IServiceProviders, ServiceProviders>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
});

var app = builder.Build();
app.UseCors("AllowBlazor");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting().UseEndpoints(endpoints => { endpoints.MapGraphQL(); });

app.Run();
