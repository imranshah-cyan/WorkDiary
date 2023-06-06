using EmailPlugin.Classes;
using EmailPlugin.Models;
using EmailPlugin.Repositories;
using exampleOfHangfire.Dto;
using Hangfire;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Email.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(HomeController));
        public Task<bool> SendDailyNotificationMail()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            // Create a logger instance


            DateTime date = DateTime.Now;
            TimeZoneInfo ukTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            DateTime ukDateTime = TimeZoneInfo.ConvertTime(date, ukTimeZone);

            var isSent = false;
            //var logFilePath = @"G:\ServiceDotNet-master\ServiceDotNet-master\EmailPlugin\ErrorLog\Externallogsworkdiary.txt";
            var logFileName = "ErrorLog//Externallogsworkdiary.txt";
            var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFileName);

            try
            {
                var userRepo = new UserRepository();
                var jobRepo = new JobRepository();

                var timeLog = userRepo.GetTodayTimeLog(ukDateTime);

                var body = string.Empty;
                var headerModel = new vmViewData();
                headerModel.today = date;

                List<AlternateView> htmlViews = new List<AlternateView>();
                List<GetProjectTeamJobs_sp_Result> teams = new List<GetProjectTeamJobs_sp_Result>();

                if (timeLog.Count > 0)
                {
                    teams = jobRepo.GetTeams();

                    foreach (var teamMember in teams)
                    {
                        List<int> jobIds = new List<int>();
                        jobIds = teamMember.JOB_IDS.Split(',').Select(int.Parse).ToList();
                        var logs = timeLog.Where(t => jobIds.Contains(Convert.ToInt32(t.JOB_ID))).ToList();
                        var hours = 0;
                        var User = "";
                        body = String.Empty;
                        headerModel.Email = teamMember.EMAIL;
                        body += Helper.RenderViewToString("Values", "~/Views/EmailTemplates/Header.cshtml", headerModel);
                        //body += @"<tr><td style='text-align: center; padding-bottom: 25px; font-family: arial, helvetica, sans-serif; font-size:18px'>To see complete report please visit <a href='https://www.teksifyservice.net/worksummary/daily?email='" + teamMember.EMAIL + "&reqDatetime=" + date +">Service.net Work Diary.</a></td></tr>";
                        if (logs.Count > 0)
                        {
                            foreach (var log in logs)
                            {
                                if (log.TODAYS_HOURS != null)
                                    hours += (int)log.TODAYS_HOURS;

                                User = log.PROVIDER_FULL_NAME;

                                var model = new vmDailyWork();
                                model.Log = userRepo.GetTodayWorkSummaryByProvider(Convert.ToDateTime(date), log.PROVIDER_ID, log.JOB_ID);
                                if (model.Log != null)
                                {
                                    model.Images = userRepo.GetTodayWorkSummaryImagesByProvider(Convert.ToDateTime(date), log.PROVIDER_ID, log.JOB_ID);
                                    model.WindowsUsage = jobRepo.GetScreenLogs(Convert.ToInt32(log.PROVIDER_ID), Convert.ToInt32(log.JOB_ID), Convert.ToDateTime(date));
                                    model.ScreenLogs = userRepo.GetScreenLogs(Convert.ToInt32(log.PROVIDER_ID), Convert.ToInt32(log.JOB_ID), Convert.ToDateTime(date));
                                    body += Helper.RenderViewToString("Values", "~/Views/EmailTemplates/DailyWorkSummary.cshtml", model);
                                }
                            }

                            if (hours > 0)
                            {
                                EmailInfo emailInfo;
                                var processor = ConfigurationManager.AppSettings["Processor"];
                                var env = ConfigurationManager.AppSettings["Env"];
                                var bccEmail = ConfigurationManager.AppSettings["Bcc"];
                                var devEmail = ConfigurationManager.AppSettings["DevEmail"];
                                var fromEmail = ConfigurationManager.AppSettings["DailyWorkDiaryStatusFromEmail"];
                                var isBcc = Convert.ToBoolean(ConfigurationManager.AppSettings["IsBcc"]);
                                body += Helper.RenderViewToString("Values", "~/Views/EmailTemplates/Footer.cshtml", null);
                                emailInfo = new EmailInfo
                                {
                                    Subject = env == "dev" ? "to:" + teamMember.EMAIL : "Daily Work Status",
                                    FromEmail = new MailAddress(fromEmail),
                                    ToEmail = (env == "dev") ? new MailAddress(devEmail) : new MailAddress(teamMember.EMAIL),
                                    BccEmail = !string.IsNullOrEmpty(bccEmail) && env == "dev" && !isBcc ? null : new MailAddress(bccEmail),
                                    Headers = new Dictionary<string, string>(),
                                    SubstitutionTags = new Dictionary<string, List<string>>(),
                                    IsBodyHtml = true,
                                    Body = body
                                };

                                IEmailService service = SmtpServiceFactory.Create(processor);
                                isSent = service.SendEmail(emailInfo);

                                if (isSent)
                                {
                                    // Log the exception
                                    logger.InfoFormat("Email at {0}", DateTime.Now);
                                    logger.InfoFormat("To Email : {0}", emailInfo.ToEmail);
                                    logger.InfoFormat("Email isSent: {0}", isSent);
                                }
                                else
                                {
                                    // Log the exception
                                    logger.Error("Failed to Send Email");
                                    logger.InfoFormat("Email failed at {0}", DateTime.Now);
                                    logger.InfoFormat("To Email : {0}", emailInfo.ToEmail);
                                    logger.InfoFormat("Email isSent: {0}", isSent);
                                }
                            }
                            else
                            {
                                // Log the exception
                                logger.Warn("Log Email Not Sent for "+ User + " because the User logs are less than 1 hour");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("An error occurred", ex);
            }

            return Task.FromResult(isSent);
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}