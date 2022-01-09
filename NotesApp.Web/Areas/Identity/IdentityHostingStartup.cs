using NotesApp.Data.Models;
using NotesApp.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(NotesApp.Web.Areas.Identity.IdentityHostingStartup))]
namespace NotesApp.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NotesContext>(
                    options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NotesAppDB"))
                    );

                //services.AddDefaultIdentity<User>()
                //    .AddEntityFrameworkStores<NotesContext>();

                services.Configure<IdentityOptions>(options => 
                {
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                });
            });
        }
    }
}