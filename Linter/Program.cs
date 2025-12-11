using Linter.Components;
using Linter.Components.Account;
using Linter.Infraestructure.Contexto;
using Linter.Infraestructure.Repositories;
using Linter.Models.Modelos;
using Linter.Utilidades;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Components.Tooltip;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddFluentUIComponents();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                 throw new InvalidOperationException("String de conex�o 'DefaultConnection' n�o foi encontrada.");

builder.Services.AddServerSideBlazor(option =>
{
    option.DetailedErrors = true; //serve pra exibir erros no console do site
});

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString)
                                                              .EnableDetailedErrors());
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequerAdmin",
         policy => policy.RequireRole("Administrador"));
});


builder.Services.AddAuthenticationCore();


//isso aq n ta funcionando
builder.Services.AddIdentityCore<Users>(options => options.SignIn.RequireConfirmedAccount = false)
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

//garante que as migrations estejam aplicadas ao banco
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Aplica migra��es pendentes
}

builder.Services.AddSingleton<ToastService>();
builder.Services.AddSingleton<IEmailSender<Users>, IdentityNoOpEmailSender>();
builder.Services.AddTransient<TransactionRepository>();
builder.Services.AddTransient<TransactionCancelationRepository>();
builder.Services.AddTransient<DeletedAccountRepository>();
builder.Services.AddTransient<DeletedAccountsRepository>();
builder.Services.AddTransient<RoleRepository>();

builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<ITooltipService, TooltipService>();
builder.Services.AddScoped<FastReports>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllersWithViews();

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

app.UseStaticFiles();
//app.UseFastReport();
app.UseAntiforgery();
//app.MapControllers();
//app.MapBlazorHub();
//app.MapRazorPages();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();