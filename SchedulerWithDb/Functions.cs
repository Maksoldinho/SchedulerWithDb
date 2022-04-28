using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchedulerWithDb
{
    static public class Functions
    {


        public static void ShowStackPanel(StackPanel panelToShow, StackPanel panelToHide)
        {
            panelToShow.Visibility = System.Windows.Visibility.Visible;
            if (panelToHide != null)
            {
                panelToHide.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        public static void ShowStackPanel(StackPanel panelToShow)
        {
            panelToShow.Visibility = System.Windows.Visibility.Visible;
        }
        public static void ClearInfo(TextBox textBlockToClear, DatePicker datePickerToClear)
        {
            textBlockToClear.Text = null;
            datePickerToClear.Text = null;
        }

    }
}
