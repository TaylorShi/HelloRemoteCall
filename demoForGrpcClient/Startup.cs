using GrpcServices;
using Helloworld;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static GrpcServices.OrderGrpc;
using static Helloworld.Greeter;

namespace demoForGrpcClient
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
            services.AddControllers();

            //// 允许使用不加密的HTTP/2协议
            //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            //services.AddGrpcClient<OrderGrpc.OrderGrpcClient>(grpcClientFactoryOptions =>
            //{
            //    // 使用不加密的HTTP/2协议地址
            //    grpcClientFactoryOptions.Address = new Uri("http://localhost:5002");
            //});

            services.AddGrpcClient<OrderGrpc.OrderGrpcClient>(grpcClientFactoryOptions =>
            {
                grpcClientFactoryOptions.Address = new Uri("https://localhost:5001");
            }).ConfigurePrimaryHttpMessageHandler(serviceProvider =>
            {
                var handler = new SocketsHttpHandler();
                // 允许无效或自签名证书
                handler.SslOptions.RemoteCertificateValidationCallback = (a, b, c, d) => true;
                return handler;
            });

            services.AddGrpcClient<Greeter.GreeterClient>(grpcClientFactoryOptions =>
            {
                grpcClientFactoryOptions.Address = new Uri("https://localhost:5001");
            }).ConfigurePrimaryHttpMessageHandler(serviceProvider =>
            {
                var handler = new SocketsHttpHandler();
                // 允许无效或自签名证书
                handler.SslOptions.RemoteCertificateValidationCallback = (a, b, c, d) => true;
                return handler;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    GreeterClient service = context.RequestServices.GetService<GreeterClient>();
                    try
                    {
                        HelloReply result = service.SayHello(new HelloRequest { Name = "abc" });
                        await context.Response.WriteAsync(result.Message.ToString());
                    }
                    catch (Exception ex)
                    {

                    }

                    //OrderGrpcClient service = context.RequestServices.GetService<OrderGrpcClient>();
                    //try
                    //{
                    //    CreateOrderResult result = service.CreateOrder(new CreateOrderCommand { BuyerId = "abc" });
                    //    await context.Response.WriteAsync(result.OrderId.ToString());
                    //}
                    //catch (Exception ex)
                    //{

                    //}
                });

                endpoints.MapControllers();
            });
        }
    }
}
