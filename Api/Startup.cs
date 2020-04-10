using Core.Logic;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
#if DEBUG
        private readonly string AllowOrigin = "AllowOrigin";
#endif
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<Context>(options =>
            options.UseMySql(Configuration.GetConnectionString("Context")));
            services.AddIdentity<ApiUser, IdentityRole>().AddEntityFrameworkStores<Context>();
            services.AddIdentityCore<ApiUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
            }).AddDefaultTokenProviders();

            new IdentityBuilder(typeof(ApiUser), typeof(IdentityRole), services)
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddSignInManager<SignInManager<ApiUser>>()
                .AddEntityFrameworkStores<Context>();

            services.AddTransient<IProductsLogic>(x => new ProductsLogic(Configuration["ConnectionStrings:Context"]));

            services.AddTransient<IProductsAdminLogic>(x => new ProductsAdminLogic(Configuration["ConnectionStrings:Context"], ""));
#if DEBUG
            services.AddCors(options =>
            {
                options.AddPolicy(AllowOrigin, builder => builder
                 .SetIsOriginAllowed((host) => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowAnyOrigin()
                 );
            });
#endif

#if !DEBUG
            services.AddLetsEncrypt();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseHttpsRedirection();
#if DEBUG
            app.UseCors(AllowOrigin);
#endif
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
