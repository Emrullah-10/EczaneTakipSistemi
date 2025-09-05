using Microsoft.EntityFrameworkCore;
using IlacTakip.Data;
using IlacTakip.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

// Session servisi ekle (basit auth için)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Varsayılan Admin kullanıcısını oluştur
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
    // Veritabanını oluştur
    context.Database.EnsureCreated();
    
    // Varsayılan admin varsa ekle
    if (!context.Admins.Any())
    {
        var admin = new Admin
        {
            Ad = "Admin",
            Soyad = "Yönetici",
            Email = "admin@eczanetakip.com",
            Sifre = "123456", // Basit şifre (gerçek projede hash'lenmiş olmalı)
            AktifMi = true,
            OlusturmaTarihi = DateTime.Now
        };
        
        context.Admins.Add(admin);
        context.SaveChanges();
    }
}

app.Run();
