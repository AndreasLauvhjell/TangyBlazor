using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repository.IRepository;
using Tangy_Business.Repository;
using Tangy_DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Tangy_DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddCors(o => o.AddPolicy("Tangy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Tangy");
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
