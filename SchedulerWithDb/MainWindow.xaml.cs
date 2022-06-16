using SchedulerWithDb.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchedulerWithDb
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>


    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            bool logInfoIsCorrect = false;
            string usernametry = UserName.Text;
            var userpwdtry = GetHashString(UserPassword.Text);

            using (ApplicationContext ac = new ApplicationContext())
            {
                var users = ac.Users.ToList();
                foreach (var user in users)
                {
                    if(usernametry == user.UserName && userpwdtry == user.UserPassword)
                    {
                        logInfoIsCorrect = true;
                    }
                    else
                    {
                        logInfoIsCorrect = false;
                    }
                }
            }


            if (logInfoIsCorrect)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Debug.WriteLine("All good!");
                this.Close();
            }
        }





        private void Confirm_Register_Button_Click(object sender, RoutedEventArgs e)
        {
            string email = Mail_To_Register.Text.ToString();
            var password = GetHashString(Password_To_Register.Text);
            using (ApplicationContext ac = new ApplicationContext())
            {
                var userToAdd = new User() {UserName = email, UserPassword = password };
                ac.Users.Add(userToAdd);
                ac.SaveChanges();
            }
            StartForm.Visibility = Visibility.Visible;
            RegisterForm.Visibility = Visibility.Hidden;

        }



        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            StartForm.Visibility = Visibility.Hidden;
            RegisterForm.Visibility = Visibility.Visible;
        }
        static Guid GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return new Guid(hash);
        }
    }

}
