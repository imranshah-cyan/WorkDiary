using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDiaryRepository.Entities
{
    public class Offer
    {
		public int Job_Offer_Id { get; set; }
		public int Job_Id { get; set; }
	    public int Provider_Id { get; set; }
		public int Buyer_Id { get; set; } = 0;
		public int Currency_Id { get; set; } = 1;
		public decimal OFFER_AMOUNT { get; set; } = 0;
		public decimal SERVICE_FEE { get; set; } = 0;
		public decimal CLIENT_CHARGED { get; set; } = 0;
		public decimal UPFRONT_PAYMENT { get; set; } = 0;
		public string TIME_REQUIRED { get; set; } = "";
		public bool IS_FIRST_OFFER { get; set; } = false;
		public bool IS_AWARDED { get; set; } = false;
		public string DESCRIPTION { get; set; } = "";
		public string TERMS { get; set; } = "";
		public int CREATED_BY { get; set; } = 0;
		public bool IS_OFFER_BUYER { get; set; } = false;
	}
}
