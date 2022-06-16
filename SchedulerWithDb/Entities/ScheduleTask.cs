using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerWithDb.Entities
{
    internal class User
    {
        public int Id { get; set; }

        //Description max length = 128 characters ↓
        [MaxLength(128)]

        public string UserName { get; set; } = null!;
        public Guid UserPassword { get; set; }
        public ScheduleTask? ScheduleTask { get; set; }
    }
    public class ScheduleTask
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
    }
}
