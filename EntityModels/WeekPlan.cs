﻿using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class WeekPlan
    {
        public WeekPlan()
        {
            PeriodsFiles = new HashSet<PeriodFile>();
        }

        public short WeekPlanId { get; set; }
        public short? WeekId { get; set; }
        public int TimeTableId { get; set; }
        public DateTime? Date { get; set; }
        public int? LessonId { get; set; }
        public string Homework { get; set; }
        public string Quiz { get; set; }

        public Lesson Lesson { get; set; }
        public TimeTable TimeTable { get; set; }
        public AcademicWeek Week { get; set; }
        public ICollection<PeriodFile> PeriodsFiles { get; set; }
    }
}
