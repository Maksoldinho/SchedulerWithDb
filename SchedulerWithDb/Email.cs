using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerWithDb
{
    internal class Email
    {
       public static async Task SendEmailAsync(DateTime WhenToRemind)
        {
            //DateTime remind = Convert.ToDateTime(WhenToRemind);

            MailAddress from = new MailAddress("schedulerbot13@gmail.com", "Scheduler");
            MailAddress to = new MailAddress("maksim.korotkov.2005@gmail.com");

            //foreach(var tsk in Data.TasksToRemind)
            //{
             int tickTime = (int)(WhenToRemind - DateTime.Now).TotalMilliseconds;
            //    MailMessage m = new MailMessage(from, to)
            //    {
            //        Subject = "Напоминалка!",
            //        Body = $"Напоминаю, вы хотели сделать это: {tsk.TaskName}! Рекомендую вам проверить свой ToDo лист!"
            //    };
            //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            //    {
            //        Credentials = new NetworkCredential("schedulerbot13@gmail.com", "KljHgdt1937"),
            //        EnableSsl = true
            //    };
            //    await Task.Delay(tickTime);
            //    await smtp.SendMailAsync(m);
            //}




            MailMessage m = new MailMessage(from, to)
            {
                Subject = "Напоминалка!",
                Body = $"Напоминаю, вы хотели что-то сделать! Рекомендую вам проверить свой ToDo лист!"
            };
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("schedulerbot13@gmail.com", "KljHgdt1937"),
                EnableSsl = true
            };
            await Task.Delay(tickTime);
            await smtp.SendMailAsync(m);
        }
    }
}
