using FluentValidation;
using FluentValidation.AspNetCore;
using FormHelper;
using ItpdevelopmentTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using Task = ItpdevelopmentTestProject.Models.Task;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ItpdevelopmentTestProjectContext>(options => options.UseNpgsql(connection));
builder.Services.AddControllersWithViews().AddFormHelper();

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

app.UseFormHelper();

app.Run();
