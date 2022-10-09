using FlexWalletSelfService.Web.Abstractions.Services.Business;
using FlexWalletSelfService.Web.Abstractions.Services.Data;
using FlexWalletSelfService.Web.Services.BusinessServices;
using FlexWalletSelfService.Web.Services.DataServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddScoped<IWalletTransactionService, WalletTransactionService>();
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<IAccountDataServices, AccountDataServices>();

builder.Services.AddScoped<IWalletTransactionServices, WalletTransactionServices>();
builder.Services.AddScoped<IWalletTransactionDataServices, WalletTransactionDataServices>();

 builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(1000);  
});

builder.Services
               .AddHttpClient(String.Empty, client => client.BaseAddress = new Uri("http://localhost:5119/api/"));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
