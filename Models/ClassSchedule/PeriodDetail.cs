using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zummer.Models.ClassSchedule
{
    public class PeriodDetail
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Location { get; set; }
        public string LectureTopic { get; set; }

        public PeriodDetail(DateTime Start, DateTime End, string Location, string LectureTopic)
        {
            this.Start = Start;
            this.End = End;
            this.Location = Location;
            this.LectureTopic = LectureTopic; 
        }
    }
}