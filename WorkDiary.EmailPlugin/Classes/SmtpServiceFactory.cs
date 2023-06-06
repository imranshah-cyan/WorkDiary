namespace EmailPlugin.Classes
{
    public static class SmtpServiceFactory
    {
        public static LocalSmtpService Create(string processor)
        {
            switch ((processor ?? string.Empty).ToLowerInvariant())
            {
                case "sendgrid":
                    return new SendGridSmtpService();
                default:
                    return new LocalSmtpService();
            }
        }
    }
}