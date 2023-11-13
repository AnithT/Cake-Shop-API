using CakeShop.Data;
using CakeShop.Models;
using CakeShop.Repositories;
using CakeShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CakeShop
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
            services.AddSingleton(typeof(ILiteDBProvider<>), typeof(LiteDBProvider<>));

            services.AddSingleton<ILiteDBProvider<Cake>>(provider =>
            {
                var liteDbConnectionString = "cakeshop.db";
                return new LiteDBProvider<Cake>(liteDbConnectionString);
            });

            services.AddSingleton<ILiteDBProvider<Muffin>>(provider =>
            {
                var liteDbConnectionString = "cakeshop.db";
                return new LiteDBProvider<Muffin>(liteDbConnectionString);
            });

            services.AddSingleton<ICakeRepository, CakeRepository>();
            services.AddSingleton<IMuffinRepository, MuffinRepository>();
            services.AddSingleton<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddSingleton<IShoppingCartService, ShoppingCartService>();
            //services.AddSingleton(typeof(ILiteDBProvider<>), typeof(LiteDBProvider<>));


            SetInitialData(services);
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void SetInitialData(IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var cakeLiteDBProvider = serviceProvider.GetService<ILiteDBProvider<Cake>>();

                // Get an instance of ILiteDBProvider<Muffin> from the service provider
                var muffinLiteDBProvider = serviceProvider.GetService<ILiteDBProvider<Muffin>>();

                if (cakeLiteDBProvider.GetAll().Any())
                {
                    return;
                }
                var deathByCake = new Cake
                {
                    Name = "Death by cake",
                    CaloriesPerSlice = 666,
                    Recipe = "Mix ingredients together. Put into a lined cake tin and bake at 200 degrees celcius for 25 minutes.",
                    Creator = "Shane S.",
                    Ingredients = new List<string> { "250g self raising flour", "1kg of sugar", "500g butter", "100ml milk", "1 egg" },
                    Id = Guid.Parse("2388afc4-92c7-470d-9afe-797b1a9258bd"),
                    Price = 4,
                    RecipePrice = 50,
                    Added = DateTime.UtcNow
                };

                // Use the CakeRepository to add the initial cake data
                cakeLiteDBProvider.Create(deathByCake);

                //var wrongCake = new Cake
                //{
                //    Name = "The wrong cake",
                //    CaloriesPerSlice = 666,
                //    Recipe = "Mix ingredients together by hand. Put into a lined cake tin and bake at 150 degrees celcius for 30 minutes.",
                //    Creator = "Mat E.",
                //    Ingredients = new List<string> { "250g self raising flour", "1 Banana", "2 oranges", "100ml milk", "2 eggs" },
                //    Id = Guid.Parse("d17eeb84-6d52-49b7-b30c-f4b041016aca"),
                //    Price = 12,
                //    RecipePrice = 50,
                //    Added = DateTime.UtcNow
                //};

                //// Use the CakeRepository to add the initial cake data
                //cakeRepository.Add(wrongCake);

                //var rightCake = new Cake
                //{
                //    Name = "The right cake",
                //    CaloriesPerSlice = 666,
                //    Recipe = "Mix all ingredients together by hand apart from the chocolate. Put into a lined cake tin and bake at 150 degrees celcius for 30 minutes. Melt the chocolate and pour over the top. Allow 2 hours to set in the fridge.",
                //    Creator = "Mat E.",
                //    Ingredients = new List<string> { "250g self raising flour", "1kg of sugar", "500 grams chocolate", "500g butter", "100ml milk", "1 egg" },
                //    Id = Guid.Parse("21869e4f-c3ab-4a19-b7fe-d8c0a99773ae"),
                //    Price = 2,
                //    RecipePrice = 50,
                //    Added = DateTime.UtcNow
                //};

                //// Use the CakeRepository to add the initial cake data
                //cakeRepository.Add(rightCake);




                var rightMuffin = new Muffin
                {
                    Name = "The right Muffin",
                    Creator = "Mat E.",
                    Ingredients = new List<string> { "250g self raising flour", "1kg of sugar", "500 grams chocolate", "500g butter", "100ml milk", "1 egg" },
                    Id = Guid.Parse("21869e4f-c3ab-4a19-b7fe-d8c0a99773ae"),
                    Price = 2,
                    Added = DateTime.UtcNow
                };

                muffinLiteDBProvider.Create(rightMuffin);
            }
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvc();
     
                app.UseSwagger();
                app.UseSwaggerUI();
        }
    }
}
