using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OdataApi.Models;

namespace OdataApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OtipDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("otipdbconn")));
            services.AddControllers().AddOData(opt =>
                opt.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents("odata", GetEdmModel())
            );
            services.AddDefaultODataServices();
        }
        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntityType<Customer>();
            builder.EntityType<Order>();
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Order>("Orders");
            return builder.GetEdmModel();
        }
    }
}
