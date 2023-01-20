using E_Learn.Infrastructure;
using E_Learn.Infrastructure.Interface;
using E_Learn.Infrastructure.IRepo;
using E_Learn.Infrastructure.Repo;
using E_learning.ApiRes;
using E_learning.Extension;
using E_learning.Helpers;
using E_learning.Middleware;
using ELearning.Service.IService;
using ELearning.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



  var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors( opt =>
{
    opt.AddPolicy("CorsPolicy", policy => { policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
  } );
builder.Services.AddDbContext<StoreContext>(x =>
{
    x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore//swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(option =>
{
    option.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
        .Where(e => e.Value.Errors.Count > 0)
        .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToArray();
        var errorResponse = new ApiValidationErrorResponse
        {
            Errors = errors
        };
        return new BadRequestObjectResult(errorResponse);
    };
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    ConfigCon.Initilize(service);  
}


// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStatusCodePagesWithReExecute("/redirect/{0}");//when unknown endpoint is called

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");  

app.UseAuthorization();

app.MapControllers();

app.Run();




