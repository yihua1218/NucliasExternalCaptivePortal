using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NucliasExternalCaptivePortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            System.Console.WriteLine($"RuntimeInformation.FrameworkDescription: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapPost("api/login", async context =>
                {
                    var form = await context.Request.ReadFormAsync();
                    var userName = form["UserName"][0];
                    System.Console.WriteLine($"userName is {userName}");
                    var password = form["Password"][0];
                    System.Console.WriteLine($"password is {password}");
                    var loginUrl = form["login_url"][0];
                    System.Console.WriteLine($"loginUrl is {loginUrl}");
                    var successUrl = form["success_url"][0];
                    System.Console.WriteLine($"successUrl is {successUrl}");

                    context.Response.StatusCode = StatusCodes.Status200OK;
   
                    await context.Response.WriteAsJsonAsync(new {
                        Status = "OK",
                        RadiusUserName = "radius_user1",
                        RadiusPassword = "radius_password",
                        LoginUrl = loginUrl,
                        SuccessUrl = successUrl,
                    });
                });
            });
        }
    }
}
