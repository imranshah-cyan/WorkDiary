using System.Configuration;

namespace EmailPlugin.Classes
{
    public static class Configurations
    {
        public static SmtpConfiguration Smtp
        {
            get
            {
                return new SmtpConfiguration
                {
                    Host = ConfigurationManager.AppSettings["SMTP_Host"],
                    Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]),
                    UserName = ConfigurationManager.AppSettings["SMTP_UserName"],
                    Password = ConfigurationManager.AppSettings["SMTP_Password"],
                    EnableSsl = bool.Parse(ConfigurationManager.AppSettings["SMTP_EnableSsl"]),
                    RetryOnFailure = true
                };
            }
        }

        public static SmtpConfiguration SendGridSmtp
        {
            get
            {
                return new SmtpConfiguration
                {
                    Host = ConfigurationManager.AppSettings["SG_Host"],
                    Port = int.Parse(ConfigurationManager.AppSettings["SG_Port"]),
                    UserName = ConfigurationManager.AppSettings["SG_UserName"],
                    Password = ConfigurationManager.AppSettings["SG_Password"],
                    EnableSsl = bool.Parse(ConfigurationManager.AppSettings["SG_EnableSsl"])
                };
            }
        }
    }
}
