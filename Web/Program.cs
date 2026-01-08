using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Services.Auth.Abstract;
using Web.Services.Auth.Manager;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // MVC tarafında SADECE Cookie Authentication kullanıyoruz
            // JWT burada kullanılmaz
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    // Kullanıcı login değilse buraya yönlendirilecek
                    options.LoginPath = "/Auth/Login";

                    // Logout işlemi sonrası yönlendirme
                    options.LogoutPath = "/Auth/Login";

                    // Yetkisi yoksa (Authorize ama role uymuyorsa)
                    options.AccessDeniedPath = "/Home/AccessDenied";

                    // Cookie ayarları
                    options.Cookie.Name = "BlogApp.Auth";      // Tarayıcıda görünecek cookie adı
                    options.Cookie.HttpOnly = true;             // JS erişemesin (XSS koruması)
                    options.Cookie.SameSite = SameSiteMode.Lax; // MVC + API uyumlu
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

                    // Cookie ömrü
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.SlidingExpiration = true; // Aktif kullanıcı için süre uzar
                });

            // MVC → API çağrıları için HttpClient
            builder.Services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7043/api/");
            });

            // DI (Web Services)
            builder.Services.AddScoped<IApiAuthService, ApiAuthManager>();
            builder.Services.AddScoped<IAuthSessionService, AuthSessionManager>();

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Middleware Pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Cookie okur
            app.UseAuthorization();  // [Authorize] çalışır

            // Routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
