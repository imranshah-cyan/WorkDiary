using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDiaryRepository.Entities
{
    public class Job
    {
		public int USER_ID { get; set; }
	    public int JOB_TYPE_ID { get; set; }
	    public int JOB_STATUS_ID { get; set; }
	    public string JOB_TITLE { get; set; }
	    public int CLASS_ID { get; set; }
	    public string DESCRIPTION { get; set; }
	    public string APPROXIMATE_DURATION { get; set; }
	    public decimal APPROXIMATE_BUDGET { get; set; }
	    public string DURATION { get; set; }
	    public decimal HOURLY_RATE { get; set; }
	    public float HOURS_PER_WEEK { get; set; }
	    public Boolean ON_SITE_WORK { get; set; }
	    public int SITE_LOCATION_REGION_ID { get; set; }
	    public int SITE_LOCATION_CITY_ID { get; set; }
	    public string SITE_LOCATION_POSTCODE { get; set; }
	    public int OFFER_SUBMIT_DAYS { get; set; }
	    public string WORK_START { get; set; }
	    public Boolean WORK_START_IMMIDIATELY { get; set; }
	    public Nullable<DateTime> WORK_START_ON_DATE { get; set; }
	    public Boolean JOB_VIEW_IS_PUBLIC { get; set; }
	    public Boolean OFFER_AMOUNT_IS_PUBLIC { get; set; }
	    //public DateTime CREATED_ON {get; set;}
	    public int CREATED_BY { get; set; }
	    //public Boolean IS_ARCHIVED {get;set;}
	    public int CURRENCY_ID { get; set; }
	    public int RATE_TYPE_ID { get; set; }
	    public decimal RATE { get; set; }
	}
}
