using Domain.AggregatesModel.IDiscountRepository;
using Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

#region Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(
        config.GetConnectionString("DefaultConnection"),
        sqlServerOptions =>
        {
            sqlServerOptions.MigrationsAssembly("Application"); // Specify the assembly containing migrations
            sqlServerOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null
            ); // Enable retry logic for transient failures
        }
    );
});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod()
                 .AllowAnyHeader()
                 .WithOrigins("http://localhost:3000")
                 .AllowCredentials();
    });
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<StoreDbContext>()
    .AddApiEndpoints();

#region AddScoped region for repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
#endregion

#region AddScoped region for domain services
builder.Services.AddScoped<IProductDomainService, ProductDomainService>();
builder.Services.AddScoped<IMockDataDomainService, MockDataDomainService>();
#endregion

#region AddScoped region for application services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICSharpTopicsService, CSharpTopicsService>();
builder.Services.AddScoped<IMockDataService, MockDataService>();
#endregion

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<StoreDbContext>();
    dbContext.Database.Migrate();

    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ExceptionMiddleware>();
//app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapIdentityApi<User>();
});
#endregion

app.Run();

/* .net 6 onwards now allows integration of startup into program.cs! */