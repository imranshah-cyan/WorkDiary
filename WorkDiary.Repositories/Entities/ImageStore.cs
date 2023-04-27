using System;

namespace WorkDiaryRepository.Entities
{
    public class ImageStore
    {
        public int IMAGE_ID { get; set; }
        public int? TIME_SHEET_ID { get; set; }
        public byte[] IMAGE_BINARY { get; set; }
        public string IMAGE_NAME { get; set; }
        public string KEY_LOG { get; set; }
        public int? KEY_STROKE_LEVEL { get; set; }
        public int? MOUSE_CLICK { get; set; }
        public string ACTIVE_WINDOW_TITLE { get; set; }
        public int? JOB_ID { get; set; }
        public int? JOB_OFFER_ID { get; set; }
        public int? JOB_AWARDED_ID { get; set; }
        public int? BUYER_ID { get; set; }
        public int? PROVIDER_ID { get; set; }
        public int? CREATED_BY { get; set; }
        public DateTime? CREATED_ON { get; set; }
        public bool IS_EMAIL_SENT { get; set; }
        public bool IS_DELETED { get; set; }
        public int? DELETED_BY { get; set; }
        public DateTime? DELETED_ON { get; set; }
        public int? WINDOWS_SWITCHED { get; set; }
        public int? TIME_SPENT_IN_SECONDS { get; set; }
    }
}
