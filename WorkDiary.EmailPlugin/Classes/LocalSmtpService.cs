using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using EmailPlugin.Models;

namespace EmailPlugin.Classes
{
    public class LocalSmtpService: IEmailService
    {

        public bool SendEmail(EmailInfo emailInfo)
        {
            bool flag = false;
            var mailClient = default(SmtpClient);
            var mailMessage = default(MailMessage);
            SmtpConfiguration config = null;

            if (emailInfo == null)
            {
                //Logger.Error("");
                return false;
            }
            try
            {
                mailMessage = CreateMailMessage(emailInfo);
                config = GetConfiguration(emailInfo);
                var smtpHost = config.Host;
                var smtpPort = config.Port;
                var smtpUserName = config.UserName;
                var smtpPassword = config.Password;
                var smtpEmableSsl = config.EnableSsl;

                mailClient = new SmtpClient(smtpHost, smtpPort);
                mailClient.EnableSsl = smtpEmableSsl;
                if (!string.IsNullOrEmpty(smtpUserName))
                {
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    var basicAuthenticationInfo = new NetworkCredential(smtpUserName, smtpPassword);
                    mailClient.UseDefaultCredentials = false;
                    mailClient.Credentials = basicAuthenticationInfo;
                }

                mailMessage.IsBodyHtml = true;
                mailClient.Send(mailMessage);
                flag = true;
            }
            catch (SmtpException ex)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (mailMessage != null)
                {
                    foreach (var attachment in mailMessage.Attachments)
                    {
                        attachment.Dispose();
                    }
                    mailMessage.Attachments.Clear();
                    mailMessage.Dispose();
                }

                if (mailClient != null)
                {
                    mailClient.Dispose();
                    mailClient = null;
                }
            }
            return flag;
        }

        
        protected virtual SmtpConfiguration GetConfiguration(EmailInfo emailInfo)
        {
            return Configurations.Smtp;
        }

        protected virtual MailMessage CreateMailMessage(EmailInfo emailInfo)
        {
            var mailMessage = new MailMessage
            {
                Subject = emailInfo.Subject,
                Body = emailInfo.Body,
                IsBodyHtml = true,
                From = emailInfo.FromEmail,
                BodyEncoding = Encoding.UTF8
            };

            if (emailInfo.AltView != null)
            {
                foreach (var altV in emailInfo.AltView)
                {
                    mailMessage.AlternateViews.Add(altV);
                }
            }
            

            mailMessage.To.Add(emailInfo.ToEmail);

            if (emailInfo.CcEmail != null)
                mailMessage.CC.Add(emailInfo.CcEmail);

            if (emailInfo.BccEmail != null)
                mailMessage.CC.Add(emailInfo.BccEmail);

            if (emailInfo.ReplyToList != null && emailInfo.ReplyToList.Any())
            {
                foreach (var email in emailInfo.ReplyToList)
                    mailMessage.ReplyToList.Add(email);
            }

            if (emailInfo.Headers != null && emailInfo.Headers.Any())
            {
                foreach (var header in emailInfo.Headers)
                {
                    mailMessage.Headers[header.Key] = header.Value;
                }
            }

            return mailMessage;
        }
        
    }

}