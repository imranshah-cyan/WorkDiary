using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceDotNet.Api.Models
{
    public class ProviderLog
    {
        public int? BUYER_ID { get; set; } = 0;
        public int PROVIDER_ID { get; set; }
        public int? JOB_ID { get; set; }
        public int Period { get; set; }
        public DateTime? Start_Time { get; set; }

        public DateTime? End_Time { get; set; }
    }
}