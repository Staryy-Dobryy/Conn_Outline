using ConnOutlineMessenger.BuisnessLogic.Injecting;
using ConnOutlineMessenger.BuisnessLogic.Services.Realization;
using ConnOutlineMessenger.BuisnessLogic.SignalR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services.AddSignalR();
builder.Services.AddDataBase(configuration);
builder.Services.InjectServices();
builder.Services.InjectRepositories();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = AuthOptions.ISSUER,
                    ValidAudience = AuthOptions.AUDIENCE,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ClockSkew = TimeSpan.Zero
                };
            });
builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Account/Error");
    app.UseHsts();
}

app.Services.UseDataBase();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


// Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/Chat");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "Chats",
    pattern: "{controller=Chats}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Menu",
    pattern: "{controller=Menu}/{action=CreateChat}");

app.Run();