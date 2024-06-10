using Microsoft.AspNetCore.Authentication.JwtBearer;
using RealEstate_Dapper_UI.Services;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
	opt.LoginPath = "/EstateAgent/Login/Index";
	opt.LogoutPath = "/EstateAgent/Login/Index";
	opt.AccessDeniedPath = "/Pages/AccessDenied";
	opt.Cookie.HttpOnly = true;
	opt.Cookie.SameSite = SameSiteMode.Strict;
	opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
	opt.Cookie.Name = "CokkececiEmlakJwt";
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
