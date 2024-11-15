using Business;
using Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IGroupTeamRepository, GroupTeamRepositoryImp>();
builder.Services.AddTransient<IAccountBusiness, AccountBusinessImp>();
builder.Services.AddTransient<IGroupTeamBusiness, GroupTeamBusinessImp>();
builder.Services.AddTransient<ITeamBusiness, TeamBusinessImp>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
