using BlazorScrumAPI;
using BlazorScrumAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ScrumBoardContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorScrumAPIContext")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.MigrateDatabase();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader());
app.MapControllers();

app.Run();
