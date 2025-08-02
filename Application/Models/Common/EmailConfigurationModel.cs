using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Common
{
    public class EmailConfigurationModel
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public bool SendingEmailEnabled { get; set; }
        public bool SSL { get; set; }
    }
}
