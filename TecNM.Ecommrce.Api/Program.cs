using Dapper.Contrib.Extensions;
using TecNM.Ecommerce.Api.Repositories;
using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommrce.Api.Repositories;
using TecNM.Ecommrce.Api.DataAcces;
using TecNM.Ecommrce.Api.DataAcces.Interfaces;
using TecNM.Ecommrce.Api.Repositories.Interfaces;
using TecNM.Ecommrce.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IProductCategoryRepository, InMemoryProductControllerRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

builder.Services.AddScoped<IBrandRepository, BrandCategoryRepository>();
builder.Services.AddScoped<IBrandService, BrandCategoryService>();

builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IImagenRepository, ImagenRepository>();

SqlMapperExtensions.TableNameMapper = entityType =>
{
    var name = entityType.ToString();
    if (name.Contains("TecNM.Ecommerce.Core.Entities."))
        name = name.Replace("TecNM.Ecommerce.Core.Entities.", "");
    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();