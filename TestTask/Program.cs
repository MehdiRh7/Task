
using Application.Services;
using Application.Services.ContextInterface;
using Application.Services.Interface;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IUserService , UserService>();
builder.Services.AddTransient<IBirthCertificateService, BirthCertificateService>();
builder.Services.AddTransient<IDegreeService, DegreeService>();
builder.Services.AddTransient<IProfessionalCertService, ProfessionalCertService>();
builder.Services.AddTransient<IBCImagesService, BCImagesService>();
builder.Services.AddTransient<IDegreeImagesService, DegreeImagesService>();
builder.Services.AddTransient<IPCImagesService, PCImagesService>();
builder.Services.AddScoped<IMyContext, MyContext>();

//builder.Services.AddDbContext<MyContext>(option =>
//{
//    //option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"),
//    //    build =>
//    //    {
//    //        build.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
//    //    });
//});
ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;//???? ????? ???? ?? ?? ??????????? ? ?????????? ?????? ?? ?????? ??????? ????
string connection = configuration["ConnectionStrings:ConnectionString"];
builder.Services.AddDbContext<MyContext>(Options => Options.UseSqlServer(connection));

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

app.MapRazorPages();

app.Run();
