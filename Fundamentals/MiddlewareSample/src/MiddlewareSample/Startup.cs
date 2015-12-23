using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MiddlewareSample
{
    public class Startup
    {
        private readonly string _environment;
        public Startup(IHostingEnvironment env)
        {
            _environment = env.EnvironmentName;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello, World, Again!");
            });
        }

        public void ConfigureLogInline(IApplicationBuilder app, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole(minLevel: LogLevel.Information);
            var logger = loggerfactory.CreateLogger(_environment);
            app.Use(async (context, next) =>
            {
                logger.LogInformation("Handling request.");
                await next.Invoke();
                logger.LogInformation("Finished handling request.");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }

        public void ConfigureEnvironmentOne(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }

        public void ConfigureEnvironmentTwo(IApplicationBuilder app)
        {
            app.Use(next => async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }

        private static void HandleMapTest(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test Successful");
            });
        }

        public void ConfigureMapping(IApplicationBuilder app)
        {
            app.Map("/maptest", HandleMapTest);

        }

        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Branch used.");
            });
        }

        public void ConfigureMapWhen(IApplicationBuilder app)
        {
            app.MapWhen(context => {
                return context.Request.Query.ContainsKey("branch");
            }, HandleBranch);

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }

        public void ConfigureLogMiddleware(IApplicationBuilder app, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole(minLevel: LogLevel.Information);

            app.UseRequestLogger();

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
