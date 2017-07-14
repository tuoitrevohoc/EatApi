using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using EatApi.Models;
using EatApi.Repositories;
using EatApi.Repositories.Mongo;
using EatApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;
using Twilio;

namespace EatApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddCors();
            services.AddMvc();

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new Info { Title = "Sit 'N' Eat API", Version = "v1" });
            });

            var client = GetClient();
            var database = client.GetDatabase("SitNEat");

            services.AddSingleton<IRepository<Order>>(
                c => new MongoRepository<Order>(database.GetCollection<Order>("orders"))
            );

            services.AddSingleton<IRepository<Restaurant>>(
                c => new MongoRepository<Restaurant>(database.GetCollection<Restaurant>("restaurants"))
			);

            services.AddSingleton<IRepository<MenuItem>>(
				c => new MongoRepository<MenuItem>(database.GetCollection<MenuItem>("menuitems"))
			);

            InitializeTwilio();
            services.AddSingleton<INotification>(c => new SmsNotification());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
			app.UseCors(builder =>
						builder.AllowAnyOrigin()
                                .AllowAnyMethod()
							   .AllowAnyHeader()
				);
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseMvc();

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});
        }

        /// <summary>
        /// Get mongodb client
        /// </summary>
        /// <returns>The client.</returns>
        public MongoClient GetClient() 
        {
            var connectionString = "mongodb://sitneatdb:4Zb8TnlK2bbhnRJLm73nTX8cftEKoaU90A1J88e8fYddXXPUNpmw3Z8CQOgb97Q6qHckMSrJWt88iLm6ceC0AA==@sitneatdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
			var settings = MongoClientSettings.FromUrl(
			  new MongoUrl(connectionString)
			);
			settings.SslSettings =
			  new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
			var mongoClient = new MongoClient(settings);

            return mongoClient;
        }

        /// <summary>
        /// Initialize twilio
        /// </summary>
        public void InitializeTwilio() {
            var accountSid = "ACeaa09a6170cb94dda35f7d4657842acf";
            var authToken = "f9611e5d035d25881ecece094487280c";

            TwilioClient.Init(accountSid, authToken);
        }
    }
}
