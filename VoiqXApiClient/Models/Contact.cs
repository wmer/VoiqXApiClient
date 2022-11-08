using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiqXApiClient.Models {
    public class Contact {
        public string name { get; set; }
        public string reference_code { get; set; }
        public object amount { get; set; }
        public object product { get; set; }
        public object delayed_days { get; set; }
        public string[] phones { get; set; }
    }
}
