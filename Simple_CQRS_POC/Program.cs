using Microsoft.EntityFrameworkCore;
using Simple_CQRS_POC.Domain.Repositories;
using Simple_CQRS_POC.Persistance.AppDbContext;
using Simple_CQRS_POC.Persistance.Repository;

var builder = WebApplication.CreateBuilder(args);


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
