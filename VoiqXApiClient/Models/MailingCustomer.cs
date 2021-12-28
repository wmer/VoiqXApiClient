using System;
using System.Collections.Generic;
using System.Text;

namespace VoiqXApiClient.Models {
    public class MailingCustomer {
        public string name { get; set; }
        public string reference_code { get; set; }
        public List<long> phones { get; set; }
    }
}
