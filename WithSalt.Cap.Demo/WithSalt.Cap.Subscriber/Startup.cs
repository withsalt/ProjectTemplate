using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WithSalt.Cap.Subscriber.Services;

namespace WithSalt.Cap.Subscriber
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
            string dbConnectionString = Configuration.GetValue<string>("ConnectionStrings:NpgsqlDbConnectionString");
            services.AddCap(x =>
            {
                //配置数据库连接字符串
                x.UsePostgreSql(dbConnectionString);
                //CAP支持 RabbitMQ、Kafka、AzureServiceBus 等作为MQ，根据使用选择配置：
                x.UseRabbitMQ(x=>
                {
                    x.HostName = Configuration.GetValue<string>("RabbitMQ:HostName");
                    x.Port = Configuration.GetValue<int>("RabbitMQ:Port");
                    x.UserName = Configuration.GetValue<string>("RabbitMQ:UserName");
                    x.Password = Configuration.GetValue<string>("RabbitMQ:Password");
                    x.VirtualHost = Configuration.GetValue<string>("RabbitMQ:VirtualHost");
                });
            });

            services.AddTransient<ISubscriberService, SubscriberService>();

            services.AddControllersWithViews();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
