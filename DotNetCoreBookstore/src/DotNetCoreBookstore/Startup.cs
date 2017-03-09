using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using DotNetCoreBookstore.Dependencies;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using DotNetCoreBookstore.ProjectDependencies;
using Microsoft.Extensions.Options;
using DotNetCoreBookstore.Middleware;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Routing.Constraints;
using DotNetCoreBookstore.Repositories;
using DotNetCoreBookstore.Services;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBookstore
{
	public class Startup
	{
		private IConfiguration Configuration { get; }
		
		public Startup(IHostingEnvironment hostingEnvironment)
		{
			ConfigurationBuilder configBuilder = new ConfigurationBuilder();
			configBuilder
				.SetBasePath(hostingEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables();
			IConfiguration configRoot = configBuilder.Build();

			string currentMood = configRoot["Mood"];
			IConfigurationSection coloursSection = configRoot.GetSection("Colours");
			IEnumerable<IConfigurationSection> coloursSectionMembers = coloursSection.GetChildren();
			List<string> colours = (from c in coloursSectionMembers select c.Value).ToList();

			string secondColour = configRoot["Colours:1"];

			IConfigurationSection languagesSection = configRoot.GetSection("Languages");
			IEnumerable<IConfigurationSection> languagesSectionMembers = languagesSection.GetChildren();
			Dictionary<string, List<string>> platformLanguages = new Dictionary<string, List<string>>();
			foreach (var platform in languagesSectionMembers)
			{
				List<string> langs = (from p in platform.GetChildren() select p.Value).ToList();
				platformLanguages[platform.Key] = langs;
			}

			string secondJvmLanguage = configRoot["Languages:JVM:1"];

			string javaHome = configRoot["JAVA_HOME"];

			Configuration = configRoot;


		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton(Configuration);

			services.Configure<FavOptions>((opt) =>
			{
				opt.Food = Configuration["Favourites:Food"];
				opt.Music = Configuration["Favourites:Music"];
				opt.Technology = Configuration["Favourites:Technology"];
			});

			services.AddSingleton((serviceProvider) =>
			{
				ProductMeasures opt = new ProductMeasures();
				opt.Height = Convert.ToInt32(Configuration["Measures:Height"]);
				opt.Length = Convert.ToInt32(Configuration["Measures:Length"]);
				opt.Type = Configuration["Measures:Type"];
				opt.Width = Convert.ToInt32(Configuration["Measures:Width"]);
				return opt;
			});

			services.AddSingleton<IStringFormatter, JsonStringFormatter>();
			services.AddTransient<IGreeter>((provider) =>
			{
				//IGreeter branching logic ignored, supposedly depends on current time
				return new GoodMorningGreeter();
			});
			services.AddScoped<IBookRepository, BookStoreRepository>();
			services.AddScoped<IBookService, DebugBookService>();
			/*
			 * //https://docs.microsoft.com/sv-se/aspnet/core/fundamentals/configuration
			 * https://docs.microsoft.com/sv-se/aspnet/core/fundamentals/middleware
			foreach (var service in services)
			{
				string typeName = service.ImplementationType == null ? 
					(service.ImplementationInstance == null ? service.ImplementationFactory.GetType().ToString() : service.ImplementationInstance.ToString())
					: service.ImplementationType.ToString();
				Debug.WriteLine($"{service.ServiceType}: {typeName}, {service.Lifetime}");
			}*/

			services.AddMvc();
			services.AddDbContext<BookStoreDbContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("BookStore")));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
			IStringFormatter stringFormatter)
		{
			loggerFactory.AddConsole();

			//app.UseEndOfTheWorldComponent();
			app.UseLoggerComponent("Elvis Presley", DateTime.UtcNow);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else if (env.IsProduction())
			{
				//app.UseExceptionHandler("/Error.html");
				app.UseExceptionHandler(new ExceptionHandlerOptions()
				{
					//ExceptionHandlingPath = new PathString("/Error.html"),
					ExceptionHandler = context => context.Response.WriteAsync("An exception has occurred. Please contact admin@nosuchcompany.com for assistance.")
				});
			}
			else if (env.IsEnvironment("DonaldDuck"))
			{
				Debug.WriteLine("QuackQuack");
			}

			app.UseFileServer();
			/*
			app.UseFileServer(new FileServerOptions()
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
				RequestPath = new PathString("/Img")
			});*/

			/*
			DefaultFilesOptions options = new DefaultFilesOptions();
			options.DefaultFileNames.Clear();
			options.DefaultFileNames.Add("myhome.html");
			app.UseDefaultFiles(options);
			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions()
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
				RequestPath = new PathString("/Img")
			});*/

			app.UseWelcomePage("/hello");
			app.UseMvc(routeBuilder =>
			{
				//routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
				//routeBuilder.MapRoute("Default", "{controller}/{action}/{id?}", new { controller = "Home", action = "Index"});
				routeBuilder.MapRoute("Default", "{controller}/{action}/{id?}",
					defaults: new { controller = "Home", action = "Index", token = "blah" }
					, constraints: new { id = new IntRouteConstraint()});

				routeBuilder.MapRoute("Route", "Route/{*whatever}", 
					defaults: new { controller = "Route", action = "activity"});
				//routeBuilder.MapRoute("NewRoute", "Route/{*whatever}", defaults: new { controller = "Route", action = "activity" });
				//routeBuilder.MapRoute("Route", "routing/{controller}/{action}");
			});			

			/*
			app.Run(async (context) =>
			{
				//throw new ArgumentException("NONO!");
				await context.Response.WriteAsync(stringFormatter.FormatMe(new { Message = "Hello World!" }));
			});*/
		}
	}
}
