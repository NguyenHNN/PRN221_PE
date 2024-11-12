using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//DI - Dependency Injection
builder.Services.AddScoped<ISystemAccountRepository, SystemAccountRepository>();
builder.Services.AddScoped<IOilPaintingArtRepository, OilPaintingArtRepository>();
builder.Services.AddScoped<ISupplierCompanyRepository, SupplierCompanyRepository>();

//Add Session
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Use Session
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
