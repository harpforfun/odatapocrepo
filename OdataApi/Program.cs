using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.OData.ModelBuilder;
using Newtonsoft.Json.Linq;
using OdataApi.Model;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var obuilder = new ODataConventionModelBuilder();
var customerEntity = obuilder.EntityType<Customer>();
obuilder.EntityType<Order>();
obuilder.EntityType<OrderOnly>();
obuilder.EntitySet<Customer>("Customer");
obuilder.EntitySet<Order>("Order");
obuilder.EntitySet<OrderOnly>("OrderOnly");

var func1 = obuilder.Function("GetOrdersByCustomer");
func1.Parameter<int>("customerId");
func1.ReturnsFromEntitySet<OrderOnly>("OrderOnly");

builder.Services.AddControllers().AddOData(options =>
{
    options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents("odata", obuilder.GetEdmModel());
    options.RouteOptions.EnableNonParenthesisForEmptyParameterFunction = true;

});
builder.Services.AddDefaultODataServices();
builder.Services.AddDbContext<OtipContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("otipdbconn")));

var app = builder.Build();
app.UseODataRouteDebug();
app.UseRouting();
app.MapControllers();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
