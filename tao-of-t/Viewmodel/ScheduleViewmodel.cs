using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tao_of_t.Viewmodel
{
    public class ScheduleViewmodel
    {
        [Required]
        public string Firstname { get; set; }
        
        [Required]
        public string Lastname { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string Concerns { get; set; }

        private DateTime datetime = DateTime.Now;

        [Required]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        public DateTime ScheduleTimeDate
        {
            get { return datetime = DateTime.Now; }
            set { datetime = value; }
        }
        

        public SessionType type { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}