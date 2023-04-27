using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

namespace ServiceDotNet.Api.Classes
{
    public static class Common
    {
        public static bool IsServiceDotNetServerAlive()
        {
            return (IsNetConnected() && IsNetConnected());
        }

        public static bool IsNetConnected()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDatabaseServerAvailable()
        {
            try
            {
                return true; // new CommonService().CheckDatabaseLive();
            }
            catch
            {
                return false;
            }
        }

        public static String EncryptString(String text)
        {
            return new Crypto().Encrypt(text);
        }

        public static String DecryptString(String text)
        {
            return new Crypto().Decrypt(text);
        }
    }
}