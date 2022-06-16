using Microsoft.EntityFrameworkCore;
using SchedulerWithDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerWithDb
{
    internal class Add
    {
        public static string TaskName { get; set; } = null!;
        public static DateTime dueDate { get; set; }
        public static void AddToList(DateTime date, string taskName)
        {
            TaskName = taskName;
            dueDate = date;
            ActionWithDb(DbActionEnums.Action.Add);
        }
        public static void ActionWithDb(DbActionEnums.Action ActionName)
        {
            using (ApplicationContext ac = new ApplicationContext())
            { 
            switch (ActionName)
                {
                    case DbActionEnums.Action.Add: AddToDb(); break;
                    case DbActionEnums.Action.Delete: DeleteFromDb(); break;
                    default: throw new ArgumentException();
                }
            }
        }

        public static void AddToDb()
        {

            using (ApplicationContext ac = new ApplicationContext())
            {
                ScheduleTask taskToAdd = new ScheduleTask() { Description = TaskName, DueDate = dueDate, };
                ac.ScheduleTasks.Add(taskToAdd);
                ac.SaveChanges();
            }
        }
        public static void DeleteFromDb()
        {
            using (ApplicationContext ac = new ApplicationContext())
            {
                if (int.TryParse(Data.IdToDelete, out int id))
                {
                    int Id = Convert.ToInt32(Data.IdToDelete);
                    foreach (var task in ac.ScheduleTasks)
                    {
                        if (task.Id.Equals(Id))
                        {
                            ac.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                            var item = ac.ScheduleTasks.Find(task.Id);
                            ac.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                            ac.ScheduleTasks.Remove(item);
                            ac.SaveChanges();
                        }
                    }

                }
            }
        }
    }
}
