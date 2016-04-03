using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class ContentPanel : StackPanel
        {

                public ContentPanel()
                {
                        //this.Height = 500;
                       // this.Background = Palette2.GetColor(Palette2.GREEN_SEA);
                }

                public void LoadBrainstorming()
                {
                        this.Children.Clear();
                        TextBlock block = new TextBlock();
                        block.Text = "Here is the brainstorming";
                        block.FontSize = 50;

                        this.Children.Add(block);
                }

                public void LoadTraining()
                {
                        this.Children.Clear();
                        TextBlock block = new TextBlock();
                        block.Text = "Here is the training";
                        block.FontSize = 50;

                        this.Children.Add(block);
                }


                public void LoadAssignments()
                {
                        this.Children.Clear();
                        TextBlock block = new TextBlock();
                        block.Text = "Here are the assignments";
                        block.FontSize = 50;

                        this.Children.Add(block);
                }

                public void LoadMaintenance()
                {
                        this.Children.Clear();
                        TextBlock block = new TextBlock();
                        block.Text = "Here is the maintenance";
                        block.FontSize = 50;

                        this.Children.Add(block);
                }
        }//class ContentPanel
}//ns
