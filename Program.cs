using WebApplication10.Singletons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<MarcaGlobalValue>();
builder.Services.AddSingleton<MarcaGlobalNome>();
builder.Services.AddSingleton<ModeloGlobalNome>();
builder.Services.AddSingleton<ModeloGlobalValue>();
builder.Services.AddSingleton<versaoGlobalNome>();
builder.Services.AddSingleton<versaoGlobalValue>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
