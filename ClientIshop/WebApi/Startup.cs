using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 
 
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
 
using System.Threading;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Globalization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
 
 
using System.Text.Encodings.Web;
using System.Text.Unicode;
 
using Microsoft.Extensions.Logging;
 
using System.Net;
using Newtonsoft.Json;
 
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.WebEncoders;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Primitives;
using WebApi.Models;
using LanguageResource;
using WebApi.MiddleWare;
using WebApi.AppCode.PublicData;

namespace WebApi
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
            services.AddMvc();
            services.AddHttpContextAccessor();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); 
            var serializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
             
            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });
              
            //session
            services.AddSession();
             
            //Response CORS -----------------------------------------------------------------
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                    builder.WithExposedHeaders("x-custom-header");
                });
            });

            //Response Cache -----------------------------------------------------------------
            services.AddResponseCaching();  //UseCorsUseResponseCaching使用CORS 中间件之前，必须先调用。

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection"), providerOptions => providerOptions.EnableRetryOnFailure()));
             
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddHttpContextAccessor();

            //JWT MODE SETTING 
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                //以上 jwt 不起作用,可能上述語句問題 需要參考微軟doc,ref: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-3.1
            })
            .AddPolicyScheme("scheme", "IshopxPolicy", Policy =>
            {
                Policy.ForwardDefaultSelector = context =>
                {
                    var bearerAuth = context.Request.Headers["Authorization"].FirstOrDefault()?.StartsWith("Bear") ?? false;

                    if (bearerAuth)
                    {
                        Policy.ForwardAuthenticate = JwtBearerDefaults.AuthenticationScheme;
                        Policy.ForwardChallenge = JwtBearerDefaults.AuthenticationScheme;
                        return JwtBearerDefaults.AuthenticationScheme;
                    }
                    else
                        return IdentityConstants.ApplicationScheme;
                };
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenManagement.Secret)),
                    ValidIssuer = "//tokenManagement.Issuer",
                    ValidAudience = "//tokenManagement.Audience",
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromDays(120), //TimeSpan.FromMinutes(tokenManagement.RefreshExpiration), // cache refresh time span where token expired
                    SaveSigninToken = true //2022-1-23
                }; 
            });

            //SwaggerGen---------------------------------------------------------------------------------
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "IshopX Web Api V1.1",
                        Version = "vV1.1",
                        Contact = new OpenApiContact
                        {
                            Name = "IshopX Web Api V1.1"
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Scheme = JwtBearerDefaults.AuthenticationScheme,
                        Description = "Authorization Mode Bearer",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, Array.Empty<string>()
                    }
                });
            });

            //用於配置Startup內部
            var tokenManagement = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();

            app.UseResponseCaching();
             
            app.UseStaticFiles();

            app.UseRouting();

            //启动跨域策略 Endpoint DataGuardXcore.Controllers.Authentica
            //tionController.RequestToken(DataGuardXcore) contains CORS metadata, but a middleware was not found that supports CORS.
            //Configure your application startup by adding app.UseCors() inside the call to Configure(..) in the application startup code.
            //The call to app.UseAuthorization()must appear between app.UseRouting() and app.UseEndpoints(...).
            app.UseCors("any");  

            app.UseRequestLocalization();
             
            app.UseAuthentication();
             
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "API JSON DOCUMENT v2.1.3");
                c.RoutePrefix = "api";
            });
             
            app.Use((conttext, next) =>
            {
                //var endpoint = conttext.GetEndpoint();//GET终结点 
                //var routeData = conttext.GetRouteData();// conttext.Request.RouteValues;//GET路由数据

                //預留這裡做 Http管道來處理相關需求問題
                 
                return next();
            });
            
            //route
            app.UseRouting() ;

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                string default_template = $"{{controller=Home}}/{{action=Index}}/{{id?}}";

                endpoints.MapControllerRoute(
                  name: "default", 
                  pattern: default_template);
                 
                endpoints.MapRazorPages();

            });
        }
    } 
}