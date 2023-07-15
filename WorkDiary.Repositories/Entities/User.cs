﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkDiaryRepository.Entities
{
    public class User
    {
        public int USER_ID { get; set; }
        public int ROLE_ID { get; set; }
        public string FULL_NAME { get; set; }
        public string FNAME { get; set; }
        public string MNAME { get; set; }
        public string LNAME { get; set; }
        public string EMAIL { get; set; }
        public string PRIMARYPHONE { get; set; }
        public string SECONDARYPHONE { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string SECURITY_QUESTION { get; set; }
        public string SECURITY_QUESTION_ANSWER { get; set; }
        public Nullable<System.DateTime> ACTIVATED_ON { get; set; }
        public bool IS_LOCKED { get; set; }
        public bool IS_ARCHIVED { get; set; }
    }
}