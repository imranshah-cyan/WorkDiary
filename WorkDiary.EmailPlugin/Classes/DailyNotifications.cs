using System;
using System.Configuration;
using System.Threading.Tasks;
using EmailPlugin.Controllers;

namespace EmailPlugin.Classes
{
    public class DailyNotifications 
        //: IJob
    {
        //Task IJob.Execute(IJobExecutionContext context)
        //{
        //    return SendMail();
        //}

        //public async Task SendMail()
        //{
        //    try
        //    {
        //        DateTime date = DateTime.UtcNow;
        //        var env = ConfigurationManager.AppSettings["Env"];
        //        var statusDate = ConfigurationManager.AppSettings["StatusDate"];

        //        if (env == "dev" && statusDate != null)
        //        {
        //            date = Convert.ToDateTime(statusDate);
        //        }

        //        await Retry.Do(() => Mails.DailyStatusReport(date), TimeSpan.FromMinutes(5));
        //    }
        //    catch (Exception ex)
        //    {
        //        BaseControllerLogger.Error(ex.Message, ex);
        //    }
        //}
    }
}