using System;
using System.Collections.Generic;
using System.Text;

namespace VoiqXApiClient.Models {
    public class ContactMailingV2 {
        public string name { get; set; }
        public string reference_code { get; set; }
        public int delayed_days { get; set; }
        public int instalments { get; set; }
        public double amount { get; set; }
        public string product { get; set; }
        public List<long> phones { get; set; }
    }
}
