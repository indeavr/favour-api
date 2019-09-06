using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using FavourAPI.Helpers;
using System.Text;
using FavourAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Http.Internal;
using FavourAPI.Data;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Services;
using Newtonsoft.Json;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using FavourAPI.Services.GraphQLTypes;

namespace FavourAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc()
                .AddJsonOptions(jo => jo.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper();

            var appSettingsSection = this.Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            string domain = $"https://{Configuration["Auth0:Domain"]}";

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = context.Principal.Identity.Name;
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyProviderService, CompanyProviderService>();
            services.AddScoped<IPersonProviderService, PersonProviderService>();
            services.AddScoped<IConsumerService, ConsumerService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IIndustryService, IndustryService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IBlobService, BlobService>();
            services.AddScoped<UserType>();
            services.AddScoped<CompanyProviderType>();


            foreach (var type in GetGraphQlTypes())
            {
                services.AddScoped(type);
            }

            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddScoped<FavourSchema>();

            services.AddGraphQL(x => x.ExposeExceptions = true).AddGraphTypes(ServiceLifetime.Scoped);


            var connection = this.Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<WorkFavourDbContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(connection)
                .EnableSensitiveDataLogging()
            );
        }




        static IEnumerable<Type> GetGraphQlTypes()
        {
            return typeof(Startup).Assembly
                .GetTypes()
                .Where(x => !x.IsAbstract &&
                            (typeof(IObjectGraphType).IsAssignableFrom(x) ||
                             typeof(IInputObjectGraphType).IsAssignableFrom(x)));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(x => x

               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseGraphQL<FavourSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            // app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMvc();
        }
    }

}
