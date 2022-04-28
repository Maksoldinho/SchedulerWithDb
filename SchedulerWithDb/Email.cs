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
            int tickTime = (int)(WhenToRemind - DateTime.Now).TotalMilliseconds;
            MailAddress from = new MailAddress("schedulerbot13@gmail.com", "Scheduler");
            MailAddress to = new MailAddress("maksim.korotkov.2005@gmail.com");
            MailMessage m = new MailMessage(from, to)
            {
                Subject = "Сорри за спам",
                Body = "Сорри"
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
