using fiztestone.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddTransient<AppContext>(options =>
//                      options.UseSqlServer(
//                          builder.Configuration.GetConnectionString("FizikonDb")));
builder.Services.AddScoped<IDapper, Dapperr>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseRouting();
app.UseAuthorization();
app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute("api/[controller]", "{controller=Courses}/{action=GetAll}/{id?}");
//});

app.Run();
