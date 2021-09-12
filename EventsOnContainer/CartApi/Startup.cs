using CartApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MassTransit;
using RabbitMQ;
using CartApi.Messaging.Consumers;

namespace CartApi
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<ICartRepository, RedisCartRepository>();
            services.AddSingleton<ConnectionMultiplexer>(cm =>
            {
                var configuration = ConfigurationOptions.Parse(Configuration["ConnectionString"], true);
                configuration.ResolveDns = true;
                configuration.AbortOnConnectFail = false;
                return ConnectionMultiplexer.Connect(configuration);
            });

            // prevent from mapping "sub" claim to nameidentifier.
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var identityUrl = Configuration["IdentityUrl"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {

                options.Authority = identityUrl.ToString();
                options.RequireHttpsMetadata = false;
                options.Audience = "basket";
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Events Cart API",
                    Version = "V1",
                    Description = "Events On Container - Cart API Microservice to create baskets to place order"
                }
                );
                options.AddSecurityDefinition("v1", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.OAuth2,
                    Flows = new Microsoft.OpenApi.Models.OpenApiOAuthFlows
                    {
                        Implicit = new Microsoft.OpenApi.Models.OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{Configuration.GetValue<string>("IdentityUrl")}/connect/authorize", UriKind.Absolute),
                            Scopes = new Dictionary<string, string>
                            {
                                 { "basket", "Basket Api" }
                            }
                        }
                    }
                });

            }
            );
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<OrderCompletedEventConsumer>();
                cfg.AddBus(provider =>
                {
                    return Bus.Factory.CreateUsingRabbitMq(rmq =>
                    {
                        rmq.Host(new Uri("rabbitmq://rabbitmq"), "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                        rmq.ReceiveEndpoint("EventscartAug21", e =>
                        {
                            e.ConfigureConsumer<OrderCompletedEventConsumer>(provider);

                        });
                    });

                });
            });

            services.AddMassTransitHostedService();
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger().UseSwaggerUI(e =>
            {
                e.SwaggerEndpoint("/swagger/v1/swagger.json", "Event Cart API V1");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
