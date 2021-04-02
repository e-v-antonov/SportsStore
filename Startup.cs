using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace SportsStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SportsStoreConnection"));
            });
            services.AddScoped<IProductRepository, EFProductRepository>();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/Page{productPage:int}",
                    new { Controller = "Product", action = "List" });

                endpoints.MapControllerRoute("page",
                    "Page{productPage:int}",
                    new { Controller = "Product", action = "List", productPge = 1 });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Product", action = "List", productPge = 1 });

                endpoints.MapControllerRoute("pagination",
                    "Products/Page{productPage}",
                    new { Controller = "Product", action = "List" });
                
                endpoints.MapControllerRoute("default",
                    "{controller=Product}/{action=List}/{id?}");
            });

            #region Сводка по маршрутам
            /* Сводка по маршрутам
             * / - Выводит первую страницу списка товаров всех категорий
             * слэш + Page2 - Выводит указанную страницу отображая товары всех категорий
             * слэш + Soccer - Выводит первую страницу товаров указанной категории
             * слэш + Soccer + слэш + Page2 - Выводт указанную страницу товаров заданной категории
             */
            #endregion

            SeedData.EnsurePopulated(app);
        }
    }
}
