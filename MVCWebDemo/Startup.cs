using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCWebDemo.Authentication;
using MVCWebDemo.Core.DAL.Contexts;
using MVCWebDemo.Core.DAL.Model;
using System.Linq;

namespace MVCWebDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserStore<User>, MSSQLUserContext>();
            services.AddTransient<IRoleStore<Role>, MSSQLRoleContext>();
            services.AddSingleton<IHighScoreContext, HighScoreContext>();
            services.AddIdentity<User, Role>().AddDefaultTokenProviders();
            // Add Response compression services
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                                         {
                               "application/octet-stream"
                            }); ;
            });


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 7;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings.Add(".unityweb", "application/octet-stream");

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });
        }
    }
}
