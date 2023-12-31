﻿namespace Carpool.DAL.Domain
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime RequestDate { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public String ScheduleTime { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public int CampusId { get; set; }
        public String Origin { get; set; }
        public String Destination { get; set; }
        public decimal RidePrice { get; set; }
        public bool? Accepted { get; set; }
        public bool? Completed { get; set; }
    }
}
