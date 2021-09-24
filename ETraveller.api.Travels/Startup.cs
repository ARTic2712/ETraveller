using AutoMapper;
using ETraveller.api.Travels.Data;
using ETraveller.api.Travels.Interfaces;
using ETraveller.api.Travels.Providers;
using ETraveller.Common.Consts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;

namespace ETraveller.api.Travels
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
            services.AddScoped<ITravelProvider, TravelProvider>();
            services.AddScoped<IFlightService, FlightService>();

            services.AddHttpClient(ServiceName.FlightService, config =>
            {
                config.BaseAddress = new System.Uri(Configuration.GetSection("Services").GetSection("Flights").Value);
            })
                .AddTransientHttpErrorPolicy(p=>p.WaitAndRetryAsync(5,_=> System.TimeSpan.FromMilliseconds(500)));
            services.AddHttpClient(ServiceName.AccommodationService, config =>
            {
                config.BaseAddress = new System.Uri(Configuration.GetSection("Services").GetSection("Accommodations").Value);
            })
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => System.TimeSpan.FromMilliseconds(500))); ;
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<TravelsDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
