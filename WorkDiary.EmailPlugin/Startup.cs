using Email.Controllers;
using exampleOfHangfire.Models;
using Hangfire;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(exampleOfHangfire.Startup))]
namespace exampleOfHangfire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");
            app.UseHangfireDashboard("/myJobDashboard", new DashboardOptions() {
                //Authorization = new[] { new HangfireAthorizationFilter()}
            });

            HomeController homeController = new HomeController();
            //RecurringJob.AddOrUpdate(() => homeController.SendDailyNotificationMail(), "30 16 * * *");
            //RecurringJob.AddOrUpdate(() => homeController.SendDailyNotificationMail(), "47 22 * * *");  // UK 11:47 PM
            RecurringJob.AddOrUpdate(() => homeController.SendDailyNotificationMail(), "57 23 * * *");  // UK 12:06 AM

            //RecurringJob.AddOrUpdate(() => homeController.SendDailyNotificationMail(), "00 16 * * *");
            app.UseHangfireServer();
        }
    }
}
