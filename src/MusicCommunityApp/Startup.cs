﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MusicCommunityApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MusicCommunityApp.Models;

namespace MusicCommunityApp
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            //.AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
            .Build();

        }




        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(
                    Configuration["Data:MusicCommunity:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
                Configuration["Data:MusicIdentity:ConnectionString"]));

            services.AddIdentity<Musician, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();
            // Add framework services.
            services.AddMvc();

            services.AddTransient<IMessage, MessageRepository>();
            services.AddTransient<IMember, MemberRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvcWithDefaultRoute();
            SeedData.EnsurePopulated(app);
            
        }
    }
}
