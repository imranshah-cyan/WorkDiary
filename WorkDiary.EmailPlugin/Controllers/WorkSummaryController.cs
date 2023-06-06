using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using EmailPlugin.Classes;
using EmailPlugin.Models;
using EmailPlugin.Repositories;
using exampleOfHangfire.Dto;

namespace EmailPlugin.Controllers
{
    public class WorkSummaryController : Controller
    {
        // GET: WorkSummary
        public ActionResult Daily(string email, DateTime? reqDatetime=null)
        {
            try
            {
                var userRepo = new UserRepository();
                var jobRepo = new JobRepository();
                var date = DateTime.UtcNow;
                if (reqDatetime != null)
                {
                    date = Convert.ToDateTime(reqDatetime);
                }
                var timeLog = userRepo.GetTodayTimeLog(date);
                var body = string.Empty;
                var headerModel = new vmViewData();
                headerModel.today = date;
                body += Helper.RenderViewToString("Values", "~/Views/EmailTemplates/Header.cshtml", headerModel);
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                List<GetProjectTeamJobs_sp_Result> teams = new List<GetProjectTeamJobs_sp_Result>();

                if (timeLog.Count > 0)
                {
                    teams = jobRepo.GetTeams();

                    foreach (var teamMember in teams)
                    {
                        if (teamMember.EMAIL.ToLower() == email)
                        {
                            List<int> jobIds = new List<int>();
                            jobIds = teamMember.JOB_IDS.Split(',').Select(int.Parse).ToList();
                            var logs = timeLog.Where(t => jobIds.Contains(Convert.ToInt32(t.JOB_ID))).ToList();
                            var hours = 0;

                            if (logs.Count > 0)
                            {
                                foreach (var log in logs)
                                {
                                    if (log.TODAYS_HOURS != null)
                                        hours += (int)log.TODAYS_HOURS;

                                    var model = new vmDailyWork();
                                    model.CreatedOn = date;
                                    model.Log = userRepo.GetTodayWorkSummaryByProvider(Convert.ToDateTime(date), log.PROVIDER_ID, log.JOB_ID);
                                    if (model.Log != null)
                                    {
                                        model.Images = userRepo.GetTodayWorkSummaryImagesByProvider(Convert.ToDateTime(date), log.PROVIDER_ID, log.JOB_ID);
                                        //model.WindowsUsage = jobRepo.GetScreenLogs(Convert.ToInt32(log.PROVIDER_ID), Convert.ToInt32(log.JOB_ID), Convert.ToDateTime(date));
                                        model.ScreenLogs = userRepo.GetScreenLogs(Convert.ToInt32(log.PROVIDER_ID), Convert.ToInt32(log.JOB_ID), Convert.ToDateTime(date));
                                        body += Helper.RenderViewToString("Values", "~/Views/EmailTemplates/WorkSummary.cshtml", model);
                                    }
                                }

                            }
                        }
                    }
                }
                body += Helper.RenderViewToString("Values", "~/Views/EmailTemplates/Footer.cshtml", null);
                ViewBag.RenderedHtml = body;
            }
            catch (Exception ex)
            {
            }

            return View();
        }
    }
}