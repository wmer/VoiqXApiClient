using System;
using System.Collections.Generic;
using System.Text;

namespace VoiqXApiClient.Models {
    public class Campaign {
        public string name { get; set; }
        public int mailing_id { get; set; }
        public int template_id { get; set; }
    }
}
