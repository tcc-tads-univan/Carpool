using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.DAL.Domain
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime RequestDate { get; set; }
        public int StudentId { get; set; }
        public String ScheduledTime { get; set; }
        public int DriverId { get; set; }
        public String Origin { get; set; }
        public String Destination { get; set; }
    }
}
