using Linter.Components;
using Linter.Components.Account;
using Linter.Dados.Contexto;
using Linter.Dados.Repositorios;
using Linter.Modelos.Modelos;
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

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();


builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                 throw new InvalidOperationException("String de conexão 'DefaultConnection' não foi encontrada.");

// essa string serve pra usar o sql server
//builder.Services.AddDbContext<ApplicationDbContext>(options =>  
//    options.UseSqlServer(connectionString));

builder.Services.AddServerSideBlazor(option =>
{
    option.DetailedErrors = true; //serve pra exibir erros no console do site
});

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString)
                                                              .EnableDetailedErrors());


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthorization(options =>
{
    //em teoria isso aq serve pra usar as roles como autorização em alguma tela
    options.AddPolicy("RequerAdmin",
         policy => policy.RequireRole("Administrador"));
});


builder.Services.AddAuthenticationCore();


//builder.Services.AddIdentity<TAB001_Usuarios, IdentityRole<int>>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();


//builder.Services.AddIdentity<TAB001_Usuarios, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>()  // Configura o contexto de DB
//    //.AddRoles<IdentityRole<int>>()  // Registra os papéis (roles)
//    .AddSignInManager()  // Gerenciador de login
//    .AddDefaultTokenProviders();  // Token de confirmação, etc.



//isso aq n ta funcionando
builder.Services.AddIdentityCore<Users>(options => options.SignIn.RequireConfirmedAccount = false)
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();


//builder.Services.Addde<IdentityUser>(options =>
//    options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

//garante que as migrations estejam aplicadas ao banco
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Aplica migrações pendentes
}


#region Injeções de dependência

#region Singletons
builder.Services.AddSingleton<ToastService>();
builder.Services.AddSingleton<IEmailSender<Users>, IdentityNoOpEmailSender>();
//builder.Services.AddScoped<RoleManager<IdentityRole>>();
//builder.Services.AddScoped<IdentityRole>();

#endregion

#region Transients
builder.Services.AddTransient<TransactionRepository>();
builder.Services.AddTransient<TransactionCancelationRepository>();
builder.Services.AddTransient<DeletedAccountRepository>();
builder.Services.AddTransient<CNT002_ContasExcluidasRepositorio>();
builder.Services.AddTransient<RoleRepository>();
#endregion

#region Scopeds
//builder.Services.AddScoped<RoleManager<TAB001_Usuarios>>();
builder.Services.AddScoped<TAB001_UsuariosRepositorio>();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<ITooltipService, TooltipService>();
builder.Services.AddScoped<FastRelatorios>();
//builder.Services.AddScoped<SignInManager<TAB001_Usuarios>>();
#endregion

#endregion

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