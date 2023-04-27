using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;

namespace ServiceDotNet.Api.Classes
{
    public static class UserLogs
    {
        public static List<USER_LOG> GetFormattedUserLog(int userId, int jobId, string filePath)
        {
            List<USER_LOG> userLogs = new List<USER_LOG>();

            List<string> lines = File.ReadAllLines(filePath).ToList();

            USER_LOG userLog;
            string[] entries;
            string[] delimiter = { "##||##" };

            foreach (var line in lines)
            {
                userLog = new USER_LOG();
                entries = line.Split(delimiter, StringSplitOptions.None);
                userLog.USER_ID = userId;
                userLog.JOB_ID = jobId;
                if (!string.IsNullOrEmpty(entries[0]))
                    userLog.START_TIME = Convert.ToDateTime(DateTime.ParseExact(entries[0], "dd/MM/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture));
                if (!string.IsNullOrEmpty(entries[1]))
                    userLog.WINDOW_TITLE = Convert.ToString(entries[1]);

                if (!string.IsNullOrEmpty(entries[2]))
                    userLog.KEY_STROKES = Convert.ToInt32(entries[2]);
                if (!string.IsNullOrEmpty(entries[3]))
                    userLog.MOUSE_CLICKS = Convert.ToInt32(entries[3]);
                if (!string.IsNullOrEmpty(entries[4]))
                    userLog.SCROLLING = Convert.ToInt32(entries[4]);
                if (!string.IsNullOrEmpty(entries[5]))
                    userLog.TIME_SPENT_IN_SEC = Convert.ToInt32(entries[5]);
                if (!string.IsNullOrEmpty(entries[6]))
                    userLog.END_TIME = Convert.ToDateTime(DateTime.ParseExact(entries[6], "dd/MM/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture));
                userLogs.Add(userLog);
            }

            return userLogs;
        }

        public static List<SCREEN_LOGS> GetFormattedScreenLogs(List<USER_LOG> userLogs, int timeSheetId, int jobId)
        {
            List<SCREEN_LOGS> logs = new List<SCREEN_LOGS>();

            foreach (var uLog in userLogs)
            {
                var scLog = new SCREEN_LOGS();
                scLog.SCREEN_CAT_ID = 1;
                scLog.SCREEN_TITLE = uLog.WINDOW_TITLE;
                scLog.SCREEN_CODE = "";
                scLog.PROVIDER_ID = uLog.USER_ID;
                scLog.JOB_ID = jobId;
                scLog.TIME_SHEET_ID = timeSheetId;
                scLog.TIME_SPENT = uLog.TIME_SPENT_IN_SEC;
                scLog.CREATED_ON = uLog.START_TIME;
                scLog.START_ON = uLog.START_TIME;
                scLog.END_ON = uLog.END_TIME;
                scLog.IMAGE_ID = null;
                logs.Add(scLog);
            }

            return logs;
        }
    }
}