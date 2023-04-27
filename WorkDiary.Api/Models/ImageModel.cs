using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceDotNet.Api.Models
{
    public class ImageModel
    {
        public int? PROVIDER_ID { get; set; }
        public int? JOB_ID { get; set; }
        public DateTime? START_TIME { get; set; } 
        public DateTime? END_TIME { get; set; }
        
    }
}