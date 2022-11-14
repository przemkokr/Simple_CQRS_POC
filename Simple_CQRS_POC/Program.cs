using Microsoft.EntityFrameworkCore;
using Simple_CQRS_POC.Api.Configuration;
using Simple_CQRS_POC.Application.QueryHandlers.Auctions;
using Simple_CQRS_POC.Domain.Repositories;
using Simple_CQRS_POC.Persistance.AppDbContext;
using Simple_CQRS_POC.Persistance.Repository;
using System.Reflection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatorHandlers(typeof(GetAuctionsQueryHandler).GetTypeInfo().Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("SampleApp"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
