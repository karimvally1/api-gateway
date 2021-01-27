using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using Review.Data;
using Review.Data.Query;
using Review.Data.Command;

namespace Review.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ReviewDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Reviews")), ServiceLifetime.Transient);
            services.AddAutoMapper(typeof(FindReviews));
            services.AddMediatR(typeof(FindReviews.Handler).Assembly);
            services.AddMediatR(typeof(CreateReview.Handler).Assembly);
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
