using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Data.Models;
using WebApplication1.Areas.Identity.Data;

[assembly: HostingStartup(typeof(WebApplication1.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NotesContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NotesContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<NotesContext>();
            });
        }
    }
}