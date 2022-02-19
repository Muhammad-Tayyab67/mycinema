using mycinema.Data;
using Microsoft.EntityFrameworkCore;
using mycinema.Data.Services;
using mycinema.Data.Cart;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connect = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDBContext>(option => option.UseSqlServer(connect));
builder.Services.AddScoped<IActorServies, ActorService>();
builder.Services.AddScoped<IProducerServices, ProducerServices>();
builder.Services.AddScoped<ICinemaServices, CinemaServices>();
builder.Services.AddScoped<IMoviesServices, MoviesServices>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShopingCart.GetShoppingCart(sc));
builder.Services.AddSession();
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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");
AppDbInitializer.Seed(app);
app.Run();

