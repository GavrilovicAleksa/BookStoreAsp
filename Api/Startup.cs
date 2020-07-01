using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core;
using Application;
using Application.Commands;
using Application.Queries;
using DataAccess;
using Implementation.Commands;
using Implementation.Logging;
using Implementation.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api
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
            services.AddTransient<Context>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUser>();
            services.AddHttpContextAccessor();
            services.AddTransient<IGetBooksQuery, EfGetBooksQuery>();
            services.AddTransient<IGetAuthorsQuery, EfGetAuthorsQeury>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategories>();
            services.AddTransient<IGetSingleProductQuery, EfGetSingleBook>();
            services.AddTransient<IGetPublishersQuery, EfGetPublishersQuery>();
            services.AddTransient<IGetAllCartItemsQuery, EfGetCartItems>();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
               
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<IBookInsertCommand, EfInsertBook>();
            services.AddTransient<IPublisherInsertCommand, EfInsertPublisher>();
            services.AddTransient<ICategoryInsertCommand, EfInsertCategory>();
            services.AddTransient<IAuthorInsertCommand, EfInsertAuthor>();
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<JwtManager>();
            services.AddControllers();

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
                endpoints.MapControllers();
            });
        }
    }
}
