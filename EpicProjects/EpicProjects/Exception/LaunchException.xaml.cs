using System;
using System.Collections.Generic;
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

namespace EpicProjects.Exception
{
        /// <summary>
        /// Interaction logic for LaunchException.xaml
        /// </summary>
        public partial class LaunchException : Window
        {
                public LaunchException(string message, string stackTrace, string data)
                {
                        InitializeComponent();
                        MessageBlock.Text = message;
                        StackBlock.Text = stackTrace;
                        DataBlock.Text = data;

                        this.Show();
                }
        }
}
