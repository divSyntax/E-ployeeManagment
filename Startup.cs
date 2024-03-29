﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagment.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagment
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);//if I remove this line error will be thrown. 
            //System.InvalidOperationException: 'Endpoint Routing does not support 'IApplicationBuilder.UseMvc(...)'. 
            //To use 'IApplicationBuilder.UseMvc' set 'MvcOptions.EnableEndpointRouting = false' inside 'ConfigureServices(...).'

            //Dep injection container 
            services.AddMvc();
            services.AddScoped<IEmployeeRepo, SQLCommands>();//model and service

            //Add DB conn to dependancy container.
            services.AddDbContextPool<EmpDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();//config with default route 

            //app.UseMvc(routes => {
            //    routes.MapRoute("default","{controller}/{action}/{id?}");
            //});//manually config route
        }
    }
}
