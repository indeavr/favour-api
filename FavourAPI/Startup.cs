using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FavourAPI.Helpers;
using System.Text;
using FavourAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Services;
using Newtonsoft.Json;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using FavourAPI.Mutations;
using FavourAPI.Queries;
using FavourAPI.Services.GraphQLInputTypes;
using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using FavourAPI.GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using FavourAPI.GraphQL.Types;
using FavourAPI.GraphQL.InputTypes;
using System;
using FavourAPI.Data.Repositories;
using Microsoft.AspNetCore.Http;
using GraphQL.Validation;
using GraphQL.Server.Transports.AspNetCore.Common;
using System.IO;
using System.Linq;
using GraphQL.Authorization;
using FavourAPI.Data.Factories;

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
                        var userRepo = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
                        var userId = context.Principal.Identity.Name;
                        var user = userRepo.GetById(userId);
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
            services.AddDefaultIdentity<User>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<WorkFavourDbContext>()
                .AddDefaultTokenProviders()
                .AddUserManager<UserManager>();


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 2;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
            });

            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //    options.LoginPath = "/Identity/Account/Login";
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyProviderRepository, CompanyProviderRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IIndustryRepository, IndustryRepository>();

            // Factories
            services.AddScoped<IClaimsFactory, ClaimsFactory>();

            // Data Services
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

            // types
            services.AddScoped<UserType>();
            services.AddScoped<CompanyProviderType>();
            services.AddScoped<ConsumerType>();
            services.AddScoped<OfficeType>();
            services.AddScoped<SkillType>();
            services.AddScoped<IndustryType>();
            services.AddScoped<JobOfferType>();
            services.AddScoped<PositionType>();
            services.AddScoped<LocationType>();
            services.AddScoped<EmailType>();
            services.AddScoped<OngoingJobOfferType>();
            services.AddScoped<SavedJobOfferType>();
            services.AddScoped<CompletedJobOfferType>();
            services.AddScoped<CompletionResultType>();
            services.AddScoped<PeriodType>();
            services.AddScoped<ApplicationType>();
            services.AddScoped<ActiveJobOfferType>();
            services.AddScoped<PhoneNumberType>();

            // Input Types
            services.AddScoped<UserInputType>();
            services.AddScoped<ConsumerInputType>();
            services.AddScoped<LocationInputType>();
            services.AddScoped<EducationInputType>();
            services.AddScoped<ExperienceInputType>();
            services.AddScoped<IndustryInputType>();
            services.AddScoped<CompanyProviderInputType>();
            services.AddScoped<PhoneNumberInputType>();
            services.AddScoped<EmailInputType>();
            services.AddScoped<SkillInputType>();
            services.AddScoped<JobOfferInputType>();
            services.AddScoped<ActiveJobOfferInputType>();
            services.AddScoped<OngoingJobOfferInputType>();
            services.AddScoped<SavedJobOfferInputType>();
            services.AddScoped<CompletedJobOfferInputType>();
            services.AddScoped<PeriodInputType>();
            services.AddScoped<CompletedJobOfferInputType>();
            services.AddScoped<CompletionResultInputType>();

            // schemas
            services.AddScoped<ISchema, FavourSchema>();

            // mutations
            services.AddScoped<UserMutation>();

            // queries
            services.AddScoped<UserQuery>();

            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));

            this.AddGraphQLAuth(services);
            services.AddGraphQL(x => x.ExposeExceptions = true)
                .AddUserContextBuilder(context =>
                {
                    string auth = context.Request.Headers["Authorization"];
                    string token = null;
                    if (auth != null && auth.ToString().Contains("Bearer "))
                    {
                        token = auth.ToString().Skip(6).ToString();
                    }

                    string userId = context.Request.Headers["UserId"];

                    return new GraphQLUserContext(context)
                    {
                        Token = token,
                        UserId = userId,
                        User = context.User
                    };

                })
                .AddGraphTypes(ServiceLifetime.Scoped);

            var connection = this.Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<WorkFavourDbContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(connection)
                .EnableSensitiveDataLogging()
            , ServiceLifetime.Transient);

            // GraphQL
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDocumentWriter, DocumentWriter>();
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

            app.UseHttpsRedirection();
            // must be before it needs to be used
            app.UseAuthentication();


            //// add http for Schema at default url /graphql
            //app.UseGraphQL<ISchema>("/graphql");

            //// use graphql-playground at default url /ui/playground
            //app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            //{
            //    Path = "/ui/playground"
            //});

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseAuthentication();

            var settings = new GraphQLSettings
            {
                BuildUserContext = ctx =>
                {
                    return Task.FromResult(new GraphQLUserContext(ctx) as object);
                }
            };

            var rules = app.ApplicationServices.GetServices<IValidationRule>();
            settings.ValidationRules.AddRange(rules);

            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            // app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMvc();
        }

        public void AddGraphQLAuth(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            services.AddTransient<IValidationRule, AuthorizationValidationRule>();

            services.AddSingleton(s =>
            {
                var authSettings = new AuthorizationSettings();

                authSettings.AddPolicy("UserPolicy", _ => _.RequireClaim("role", "User", "Admin"));
                authSettings.AddPolicy("AdminPolicy", _ => _.RequireClaim("role", "Admin"));

                return authSettings;
            });
        }
    }

}
