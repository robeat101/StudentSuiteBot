using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zummer.Models.ClassSchedule
{
    public class PeriodDetail
    {
        DateTime Start { get; set; }
        DateTime End { get; set; }
        string Location { get; set; }
        string LectureTopic { get; set; }

        public PeriodDetail(DateTime Start, DateTime End, string Location, string LectureTopic)
        {
            this.Start = Start;
            this.End = End;
            this.Location = Location;
            this.LectureTopic = LectureTopic; 
        }
    }
}