using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using EmailPlugin.Models;
using Newtonsoft.Json;

namespace EmailPlugin.Classes
{
    public class SendGridSmtpService : LocalSmtpService
    {
        private const string SmtpApiHeader = "X-SMTPAPI";

        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.None
        };

        protected override SmtpConfiguration GetConfiguration(EmailInfo emailInfo)
        {
            var config = Configurations.SendGridSmtp;
            if (emailInfo.ApiKey != null)
            {
                config.UserName = "apikey";
            }
            config.Password = emailInfo.ApiKey ?? config.Password;
            return config;
        }

        protected override MailMessage CreateMailMessage(EmailInfo emailInfo)
        {
            var mailMessage = base.CreateMailMessage(emailInfo);

            mailMessage.Headers.Clear();

            if (!emailInfo.PreserveRecipients.HasValue || !emailInfo.PreserveRecipients.Value)
            {
                mailMessage.To.Clear();
                if (emailInfo.ToEmail != null)
                    mailMessage.To.Add(emailInfo.ToEmail);

                mailMessage.CC.Clear();
                mailMessage.Bcc.Clear();

                var smtpApiHeader = emailInfo.ToEmail != null
                    ? new Dictionary<string, object> { { "to", emailInfo.ToEmail.ToString() } }
                    : new Dictionary<string, object>();

                if (emailInfo.SendAt.HasValue)
                {
                    smtpApiHeader["send_at"] = (int)emailInfo.SendAt.Value.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                }

                var uniqueArguments = new Dictionary<string, object>();
                if (emailInfo.Headers != null)
                {
                    foreach (var header in emailInfo.Headers)
                    {
                        uniqueArguments[header.Key] = header.Value;
                    }

                    if (uniqueArguments.Count > 0)
                    {
                        smtpApiHeader["unique_args"] = uniqueArguments;
                    }
                }

                var substitutions = new Dictionary<string, object>();
                if (emailInfo.SubstitutionTags != null)
                {
                    foreach (var sub in emailInfo.SubstitutionTags)
                    {
                        substitutions[sub.Key] = sub.Value;
                    }

                    if (substitutions.Count > 0)
                    {
                        smtpApiHeader["sub"] = substitutions;
                    }
                }

                mailMessage.Headers[SmtpApiHeader] = Regex.Replace(JsonConvert.SerializeObject(smtpApiHeader, _serializerSettings), "(.{1,72})(\",|\\[|\\]|:)", "$1$2\n");
            }
            return mailMessage;
        }
    }
}