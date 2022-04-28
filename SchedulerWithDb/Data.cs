using SchedulerWithDb.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SchedulerWithDb
{
    internal class Data
    {
        public List<string> TaskBar = new List<string>();
        public static string IdToDelete { get; set; } = null!;
        public Data()
        {
            using (ApplicationContext ac = new ApplicationContext())
            {
                var tsks = ac.ScheduleTasks.ToList(); 
                foreach (var tsk in tsks) { TaskBar.Add($"\nTask Id:{tsk.Id}\n" +
                    $"Your Taks: {tsk.Description} \n" +
                    $"This Date: {tsk.DueDate}\n"); }
            }
        }
    }
}