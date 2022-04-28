using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchedulerWithDb
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ShowRecentTaks();
        }

        private void ViewAll_Button_Click(object sender, RoutedEventArgs e)
        {
            Functions.ShowStackPanel(ViewAll_Panel, Main_Panel);
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Functions.ShowStackPanel(Add_Panel, Main_Panel);
            Functions.ClearInfo(TaskPicker, DatePicker);
        }
        private void ShowRecentTaks()
        {
            Data dt = new Data();
            TextBlockWithRecentTasks.Text = null;
            TextBlockWithTasks.Text = null;
                foreach (string tsk in dt.TaskBar) {TextBlockWithRecentTasks.Text += tsk; TextBlockWithTasks.Text += tsk; }
        }

        private async void Accept_Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Functions.ShowStackPanel(Main_Panel, Add_Panel);
                Email.SendEmailAsync((DateTime)DatePickerForReminding.Value);
                Add.AddToList(DatePicker.SelectedDate.Value, TaskPicker.Text);
                ShowRecentTaks();
            }
            catch (Exception)
            {
                Add.AddToList(DateTime.Now, TaskPicker.Text);
                ShowRecentTaks();
            }
            SendEmailGreeting();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Functions.ShowStackPanel(Main_Panel, Add_Panel);
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Functions.ShowStackPanel(Delete_Panel, Main_Panel);
        }
        private void DeleteActionAccept_Button_Click(object sender, RoutedEventArgs e)
        {
            Data.IdToDelete = IdForDeletePicker.Text;
            Add.ActionWithDb(ClassWithEnums.Action.Delete);
            Functions.ShowStackPanel(Main_Panel,Delete_Panel);
            ShowRecentTaks();
        }

        private void Back_Button_Click_fromViewAll(object sender, RoutedEventArgs e)
        {
            Functions.ShowStackPanel( Main_Panel,ViewAll_Panel);
        }







        private static void SendEmailGreeting()
        {
            MailAddress from = new MailAddress("schedulerbot13@gmail.com", "Scheduler");
            MailAddress to = new MailAddress("maksim.korotkov.2005@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "You have added new remark!";
            m.Body = "In our todo app you added task to do. Congrats!";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("schedulerbot13@gmail.com", "KljHgdt1937"),
                EnableSsl = true
            };
            smtp.Send(m);
        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            DatePickerForReminding.Visibility = Visibility.Visible;
        }

        private void Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            DatePickerForReminding.Visibility = Visibility.Hidden;
        }
    }
}
