using System;
using System.Collections.Generic;
using System.Text;

namespace VoiqXApiClient.Models {
    public class MailingV2Response {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public int contacts { get; set; }
        public int phones { get; set; }
        public Links links { get; set; }
    }
}
