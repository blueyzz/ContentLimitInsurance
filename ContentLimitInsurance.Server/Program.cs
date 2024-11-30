var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc();

builder.Services.AddDbContext<ContentLimitInsuranceContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContentLimitInsuranceContext")
        , b => b.MigrationsAssembly(typeof(ContentLimitInsuranceContext).Assembly.FullName)));

//DI for Services
builder.Services.AddScoped<IDBInitializer, DBInitializer>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper configuration
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Ensure database is initialized
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider; 
    var context = services.GetRequiredService<ContentLimitInsuranceContext>(); 
    var dbInitializer = services.GetRequiredService<IDBInitializer>(); 
    dbInitializer.Initialize(context);
}


app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
