using AccSol.EF.Data;
using AccSol.EF.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("AccSol.EF")), ServiceLifetime.Scoped);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

//builder.Services.AddHttpClient<ICommonService<Coa>, CoaService>(client =>
//{
//    var baseAddress = builder.Configuration["APIBaseURL"];
//    client.BaseAddress = new Uri(baseAddress);
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    // migrate any database changes on startup (includes initial db creation)
    // Important!: This will automatically create the database in case missing.
    //           : No need to switch to master database.
    //Start - Automatically update db from new migrations ====================>
    var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseSqlServer(connectionString)
        .Options;

    var context = new ApplicationDbContext(contextOptions);
    context.Database.Migrate();

    //End   - Automatically update db from new migrations ====================>

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();


