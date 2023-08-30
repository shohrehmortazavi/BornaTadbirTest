using BornaTadbirTest.Application.SeedWorks;
using BornaTadbirTest.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string Policy = "AllowAll";

builder.Services.AddCors(options => options.AddPolicy(Policy, p => p.AllowAnyOrigin()
                                                                    .AllowAnyMethod()
                                                                    .AllowAnyHeader()));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new QueryStringApiVersionReader();
    options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationLayerEntryPoint).Assembly));
builder.Services.AddAutoMapper(typeof(ApplicationLayerEntryPoint).Assembly);

builder.Services.AddAppDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();
//builder.Services.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.EnsureMigrationOfContext<AppDbContext>();

app.Run();
