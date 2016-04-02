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

using EpicProjects.View.CustomControls;
using EpicProjects.Constants;

namespace EpicProjects.Sketches.Custom
{
        /// <summary>
        /// Interaction logic for CustomProject.xaml
        /// </summary>
        public partial class CustomProject : Window
        {
                public CustomProject()
                {
                        InitializeComponent();
                     
                }

                private void BrainStormingPanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        BrainStormingUnderline.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2196f3"));
                }

                private void BrainStormingPanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        BrainStormingUnderline.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF7EDED"));
                }

                private void FormationsPanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        FormationsUnderline.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2196f3"));
                }

                private void FormationsPanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        FormationsUnderline.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF7EDED"));

                }

                private void TasksPanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        TasksUnderline.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2196f3"));
                }

                private void TasksPanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        TasksUnderline.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF7EDED"));

                }

                private void MaintenancePanel_MouseEnter(object sender, MouseEventArgs e)
                {
                        MaintenanceUnderline.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2196f3"));
                }

                private void MaintenancePanel_MouseLeave(object sender, MouseEventArgs e)
                {
                        MaintenanceUnderline.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF7EDED"));

                }

            
              
        }
}
