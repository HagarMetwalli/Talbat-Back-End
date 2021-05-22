using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;
using Talbat.Services;

namespace Talbat
{
    public class Startup
    {
        string MyAllowSpecificOrigins = "T";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TalabatContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("Talbaltconn")));
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<IGenericService<City>, CityService>();
            services.AddScoped<IGenericService<AddressType>, AddressTypeService>();
            services.AddScoped<IGenericService<ClientAddress>, ClientAddressService>();
            // services.AddScoped<IGenericService<ClientOffer>, ClientOfferService>();
            services.AddScoped<IGenericService<Country>, CountryService>();
            services.AddScoped<IGenericService<DeliveryMan>, DeliveryManService>();
            services.AddScoped<IGenericService<Invoice>, InvoiceService>();
            services.AddScoped<IGenericService<ItemCategory>, ItemCategoryService>();
            services.AddScoped<IGenericService<Item>, ItemService>();
            services.AddScoped<IGenericService<ItemReview>, ItemReviewService>();
            services.AddScoped<IGenericService<TempPartnerRegisterationDetail>, TempPartnerRegisterationDetailService>();
            services.AddScoped<IGenericService<SubItemCategory>, SubItemCategoryService>();
            services.AddScoped<IGenericService<SubItem>, SubItemsService>();
            services.AddScoped<IGenericService<StoreWorkingHour>, StoreWorkingHourService>();
            services.AddScoped<IGenericService<StoreType>, StoreTypeService>();
            services.AddScoped<IGenericService<ReviewCategory>, ReviewCategoryService>();
            services.AddScoped<IGenericService<Review>, ReviewService>();
            services.AddScoped<IGenericService<Region>, RegionService>();
            services.AddScoped<IGenericService<RateStatus>, RateStatusService>();
            services.AddScoped<IGenericService<Partner>, PartnerService>();
            services.AddScoped<IGenericService<OrderReview>, OrderReviewService>();
            services.AddScoped<IStoreService<Store>, StoreService>();
            services.AddScoped<IStoreService<Cuisine>, CuisineService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IOfferService, OfferService>();



            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "https://localhost:4200",
                    ValidIssuer = "https://localhost:4200",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretey@83"))
                };
            });

            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = "Authentication and Authorization in ASP.NET 5 with JWT and Swagger"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talbat", Version = "v1" });
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseCors(
            //     options =>
            //     {
            //         options.AllowAnyOrigin();
            //         options.AllowAnyMethod();
            //         options.AllowAnyHeader();
            //     }
            //);
            app.UseCors(MyAllowSpecificOrigins);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Talbat v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
