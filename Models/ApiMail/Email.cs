using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_school.Models.ApiMail
{
    public class Email
    {
        public From From { get; set; }

        public To[] To { get; set; }

        public string Subject { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
    }
}