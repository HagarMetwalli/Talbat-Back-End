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
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
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
            services.AddScoped<IGenericService<Client>, ClientService>();
            //services.AddScoped<IGenericService<ClientOffer>, ClientOfferService>();
            services.AddScoped<IGenericService<AddressType>, AddressTypeService>();
            services.AddScoped<IGenericService<ClientAddress>, ClientAddressService>();
            services.AddScoped<IGenericService<Country>, CountryService>();
            services.AddScoped<IGenericService<DeliveryMan>, DeliveryManService>();
            services.AddScoped<IGenericService<Invoice>, InvoiceService>();
            services.AddScoped<IGenericService<ItemCategory>, ItemCategoryService>();
            services.AddScoped<IGenericService<Item>, ItemService>();
            services.AddScoped< IGenericService<ItemReview>, ItemReviewService>();
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
            services.AddScoped<IStoreService, StoreService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talbat", Version = "v1" });
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
