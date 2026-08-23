
using Tributario.Atendimento.Module.Application;
using Tributario.Imobiliario.Module.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Simulando a API passando a string de conexão
var connectionString = "Server=localhost,1433;Database=MinhaAppDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;";
builder.Services.ConfigureImobiliarioModule(connectionString);
builder.Services.ConfigureAtendimentoModule(connectionString);
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
