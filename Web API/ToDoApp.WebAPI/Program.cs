using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Mappers;
using ToDoApp.Application.Services;
using ToDoApp.Infrastructur.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// register Swagger for easy testing of API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddSingleton<ITodoRepository, TodoRepository>(); // For now Singleton. If interacting with DB change to Scoped

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", // for now allow but in real world example it must be restrcited and only authorized client should be allowed
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// to make it easier for testing. force to use these port
builder.WebHost.ConfigureKestrel(option =>
{
    option.ListenAnyIP(5001);
    option.ListenAnyIP(5002, listenOptions => listenOptions.UseHttps());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoApp API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
