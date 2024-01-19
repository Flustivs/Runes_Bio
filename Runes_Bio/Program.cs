using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Runes_Bio.Pages;
using Runes_Bio.Controller;

namespace Runes_Bio
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews()
	   .AddJsonOptions(options =>
		   options.JsonSerializerOptions.PropertyNamingPolicy = null);

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins",
					builder =>
					{
						builder
							.AllowAnyOrigin()
							.AllowAnyHeader()
							.AllowAnyMethod();
					});
			});

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddControllers();
			builder.Services.AddTransient<ICalculateTicketsModel, CalculateTicketsModel>();
			builder.Services.AddScoped<Dbconnection.Connection, Dbconnection.Connection>();

			// Add services to the container.
			builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});

			var app = builder.Build();
			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseCors("AllowAllOrigins");
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			// Use the session middleware
			app.UseSession();

			app.MapRazorPages();

			app.Run();
		}
	}
}
