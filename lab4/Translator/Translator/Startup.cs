using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Translator.Models;

namespace Translator
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                if (context.Request.Query.ContainsKey("word"))
                {
                    string word = context.Request.Query["word"];
                    Dictionary dictionary = new Dictionary("Models/Dictionary.txt");
                    string translatedWord = dictionary.findTranslation(word);
                    if (translatedWord == null)
                    {
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync("Not Found");
                    }
                    else
                    {
                        context.Response.ContentType = "text/plain;charset=utf-8";
                        await context.Response.WriteAsync($"{word} = {translatedWord}");
                    }
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Bad Request");
                }
            });
        }
    }
}
