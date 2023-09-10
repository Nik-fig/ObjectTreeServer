using server.DAL;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


builder.Services
    .AddEndpointsApiExplorer()
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    .AddSwaggerGen()
    .AddTransient(o => new TreeDataContext("./data.json"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
