using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.IO.Compression;
using WebApiRepository.Models;
using WebApiRepository.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApi.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
//using AutoMapper.Extensions.Microsoft.DependencyInjection;

namespace WebApi
{
    /// <summary>
    /// Entry point to the application
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Start up
        /// </summary>
        /// <param name="env"></param>
        public Startup(IWebHostEnvironment env)
        {
            // Set up configuration sources.
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddJWTAuthentication(Configuration);
            services.AddSingleton(Configuration);
            //services.AddAutoMapper();
            //services.AddResponseCompression(options =>
            //{
            //    options.EnableForHttps = true;
            //    options.Providers.Add<GzipCompressionProvider>();
            //});


            // services.AddSingleton<TelemetryClientHelper>(new TelemetryClientHelper(Configuration));

            services.AddMvc(options => options.EnableEndpointRouting = false).AddNewtonsoftJson();
            //services.Configure<GzipCompressionProviderOptions>(options =>
            //{
            //    options.Level = CompressionLevel.Optimal;
            //});
            //services.AddResponseCompression(options =>
            //{
            //    options.EnableForHttps = true;
            //    options.Providers.Add<GzipCompressionProvider>();
            //});
            // services.AddSwaggerDocumentation();

            Action<AppSettings> appSettingOptions = (options =>
            {
                options.ConnectionString = Configuration.GetSection("Data").GetSection("ConnectionString").Value;// "DMPConnectionString";

            });
            services.Configure(appSettingOptions);
            services.AddDbContext<DataContext>();// (options => options.UseSqlServer(connection));
            services.AddTransient(resolver => resolver.GetRequiredService<IOptions<AppSettings>>().Value);
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
          

            // Register repository services.
            services.RegisterRepositoryServices(Configuration);

            services.AddHealthChecks();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/api/Error/Serlilog");
            }
            else
            {
                app.UseExceptionHandler("/api/Error/Error");
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseResponseCompression();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapHealthChecks("/health");
            //    endpoints.MapDefaultControllerRoute().RequireAuthorization();
            //});

            // app.UseSwaggerDocumentation();


        }
    }
}
