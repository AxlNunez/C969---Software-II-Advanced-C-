using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Axl_Nunez.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

}
