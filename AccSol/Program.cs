using AccSol.Components;
using AccSol.Components.Account;
using AccSol.EF.Data;
using AccSol.EF.Models;
using AccSol.EF.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();
var baseAddress = builder.Configuration["APIBaseURL"];
builder.Services.AddHttpClient<ICommonService<Coa>, CoaService>(client =>
{
    
    client.BaseAddress = baseAddress != null? new Uri(baseAddress) : null;
});
builder.Services.AddHttpClient<ICommonService<Client>, ClientService>(client =>
{
    client.BaseAddress = baseAddress != null ? new Uri(baseAddress) : null;
});
builder.Services.AddHttpClient<ICommonService<Employee>, EmployeeService>(client =>
{
    client.BaseAddress = baseAddress != null ? new Uri(baseAddress) : null;
});
builder.Services.AddHttpClient<ICommonService<ProjectCode>, ProjectCodeService>(client =>
{
    client.BaseAddress = baseAddress != null ? new Uri(baseAddress) : null;
});
builder.Services.AddHttpClient<ICommonService<PettyCash>, PettyCashService>(client =>
{
    client.BaseAddress = baseAddress != null ? new Uri(baseAddress) : null;
});
builder.Services.AddHttpClient<ICommonService<JournalEntry>, JournalEntryService>(client =>
{
    client.BaseAddress = baseAddress != null ? new Uri(baseAddress) : null;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
