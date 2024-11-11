using ASM.Appdatacontext;
using ASM.Interface;
using ASM.Models;
using ASM.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// conect to database
builder.Services.Configure<DbSettings>
    (builder.Configuration.GetSection("DbSettings"));
builder.Services.AddSingleton<AppDataContext>(); // create one Instance by Appdatacontext

// create one instance when request
builder.Services
    .AddScoped<IResourcesServices, ResourcesServices>();
builder.Services
    .AddScoped<IGameModeServices, GameModeServices>();
builder.Services
    .AddScoped<IItemsServices, ItemsServices>();
builder.Services
    .AddScoped<IPlayerServices, PlayerServices>();
builder.Services
    .AddScoped<IPlayerResourcesServices, PlayerResourcesServices>();
builder.Services
    .AddScoped<IPlayerGameModeServices, PlayerGameModeServices>();

var app = builder.Build();

{
    using var scope = app.Services.CreateScope(); // create scope for service
    var context = scope.ServiceProvider; // get service provider
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

