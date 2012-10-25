using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tao_of_t.Viewmodel
{
    public class ScheduleViewmodel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Concerns { get; set; }
        public SessionType type { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ScheduleDate { get; set; }
    }
}