using System;
using BookStore.WebApplication.Data;
using BookStore.WebApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BookStore.WebApplication.Areas.Identity.IdentityHostingStartup))]
namespace BookStore.WebApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BookStoreWebApplicationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BookStoreWebApplicationContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BookStoreWebApplicationContext>();
            });
        }
    }
}