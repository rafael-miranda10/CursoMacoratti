using System;

namespace AspnCore_EnviaEmail.Models
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public String UsernameEmail { get; set; }
        public String UsernamePassword { get; set; }
        public String FromEmail { get; set; }
        public String ToEmail { get; set; }
        public String CcEmail { get; set; }
    }
}
