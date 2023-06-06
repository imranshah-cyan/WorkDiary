using exampleOfHangfire.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace EmailPlugin.Models
{
    public class EmailInfo
    {
        public string SenderFrom { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public MailAddress FromEmail { get; set; }
        public MailAddress ToEmail { get; set; }
        public MailAddress CcEmail { get; set; }
        public MailAddress BccEmail { get; set; }
        public List<MailAddress> ReplyToList { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public DateTime? SendAt { get; set; }
        public string FromName { get; set; }
        public bool IsFileAttached { get; set; }
        public string FileName { get; set; }
        public Stream buffer { get; set; }
        public Attachment attachment { get; set; }
        public List<AlternateView> AltView { get; set; }
        public string ApiKey { get; set; }
        public bool? PreserveRecipients { get; set; }
        public string FilePath { get; set; }
        public Dictionary<string, List<string>> SubstitutionTags { get; set; }
        public GetTodayWorkSummary_Result ProviderTimeLog { get; set; }
        public List<GetTodayWorkSummaryImages_Result> Images { get; set; }
        
    }
}