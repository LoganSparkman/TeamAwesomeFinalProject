using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class PrintStudentSchedules
    {
        public Student Student { get; set; }
        public List<ClassSchedule> Schedules { get; set; }
    }
}
