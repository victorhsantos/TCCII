using TCCII.Deputados.API.Configurations;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.UseDatabase(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.ResolveDependencies();
builder.Services.ConfigureWebApi();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }

app.UseSwagger();
app.UseSwaggerUI();

await DBManagementConfiguration.MigrationInitialization(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
