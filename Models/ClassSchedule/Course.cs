using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zummer.Models.ClassSchedule
{
    public class Course
    {
        public string Topic { get; set; }
        public string Professor { get; set; }
        public List<PeriodDetail> Schedule { get; set; } 

        public Course()
        {
            DateTime start = DateTime.Now.AddDays(-2);
            List<string> location = new List<string>();
            location.Add("Buffalo");
            location.Add("Worcester");
            List<string> subjects = new List<string>();
            for (int i = 0; i < 10; ++i)
            {
                subjects.Add("Macro Theory Lecture " + (i+1).ToString());
            }
                
            Topic = "Macro-Economic Theory for Noobs";
            Professor = "Dr. Hiroshi Ishiguro";
            Schedule = new List<PeriodDetail>();
            for(int i = 0; i < 10; ++i)
            {
                Schedule.Add(new PeriodDetail(start.AddDays(i), start.AddHours(1).AddDays(i), location[i % 2], subjects[i]));
            }
        }

        public Course(string Topic, string Professor, List<PeriodDetail> Schedule)
        {
            this.Topic = Topic;
            this.Professor = Professor;
            this.Schedule = Schedule; 
        }

    }
}