using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Tangy_Business.Repository;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess.Data;
using TangyWeb_Server.Data;
using TangyWeb_Server.Service;
using TangyWeb_Server.Service.IService;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTUyNDA5MEAzMjMxMmUzMTJlMzMzNW9BT0FLblNwNWxYblU2ZG5nRlpWMU9MN0JwQWxSZDkvaTBNUEJsWllJaFU9;Mgo+DSMBaFt+QHFqVkNrWE5AaV1CX2BZell1TWlbd04QCV5EYF5SRHVdSlxlSnZRfkBhXHo=;Mgo+DSMBMAY9C3t2VFhhQlJBfVtdWXxLflF1VWdTfFZ6dl1WACFaRnZdQV1gS3ZScEZrW3dbdHVQ;Mgo+DSMBPh8sVXJ1S0d+X1RPckBGQmFJfFBmQWlad1RyfEUmHVdTRHRcQl5hQX9VdU1hUXpbd3E=;MTUyNDA5NEAzMjMxMmUzMTJlMzMzNWRMNkw3OFpzR0V0UXlwaEdVWU92RitjR1RUbUMxeUFuQjFKTU1WWlhvaTg9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RGQmdWfFN0RnNddV14fldOcDwsT3RfQF5jSnxbd0NgUX1WdX1TQw==;ORg4AjUWIQA/Gnt2VFhhQlJBfVtdWXxLflF1VWdTfFZ6dl1WACFaRnZdQV1gS3ZScEZrW3dYcXVQ;MTUyNDA5N0AzMjMxMmUzMTJlMzMzNURzUUJCMWJNRkh6aktNekNPT25HRDdGVENENU4vdCtwT2lLanRxTm5MNE09;MTUyNDA5OEAzMjMxMmUzMTJlMzMzNWF6YjlWMGZlNUtBdlBMUVJMR3F5L2ZuaksyWFp3cGt1UWIwV1V6MlNvK009;MTUyNDA5OUAzMjMxMmUzMTJlMzMzNUVZSmg5cXo0amhRNnMrSHovVURIUGZ3TFppemhpd0lWcElkbFhxRGJoRkU9;MTUyNDEwMEAzMjMxMmUzMTJlMzMzNVJwblZnSFB2WjJzYTAzK0cwNDBYNCtuQjdoblMwTlg0bnJtUmRMU3l5TDg9;MTUyNDEwMUAzMjMxMmUzMTJlMzMzNW9BT0FLblNwNWxYblU2ZG5nRlpWMU9MN0JwQWxSZDkvaTBNUEJsWllJaFU9 ");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
