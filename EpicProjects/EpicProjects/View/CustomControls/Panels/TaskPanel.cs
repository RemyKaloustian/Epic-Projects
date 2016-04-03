using EpicProjects.Constants;
using EpicProjects.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class TaskPanel : StackPanel
        {

                public DetailsPanel _detailsPanel { get; set; }

                public TaskMasterChief _chief { get; set; }

                public List<SingleTaskPanel> _brainstormingList { get; set; }

                public TaskPanel(DetailsPanel detailsPanel, string name)
                {
                        _chief = new TaskMasterChief(name);
                        _detailsPanel = detailsPanel;
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        this.Margin = new System.Windows.Thickness(0, 0, 10, 0);

                        this.Width = Dimensions.GetWidth() * 0.6;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = Palette2.GetColor(Palette2.LIGHT_GRAY);

                        _brainstormingList = new List<SingleTaskPanel>();
                }


                public void FillBrainstormings()
                {

                        
                        List<Model.Task> brains = _chief.SelectBrainstormings();



                        foreach (Model.Task item in brains)
                        {
                                

                                SingleTaskPanel brainStorming = new SingleTaskPanel(item);
                                _brainstormingList.Add(brainStorming);
                                brainStorming.MouseDown += brainStorming_MouseDown;
                                this.Children.Add(brainStorming);


                        }
                }

                void brainStorming_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {

                        SingleTaskPanel taskPanel = (SingleTaskPanel)sender;
                        taskPanel.TriggerHover();
                        foreach (SingleTaskPanel task in _brainstormingList)
                        {
                                if (!task.IsMouseOver)
                                {
                                        task.Background = new Theme.CustomTheme().GetAccentColor();

                                        task._checkBoxBorder.BorderBrush = new Theme.CustomTheme().GetBackground();
                                        task._content.Foreground = new Theme.CustomTheme().GetBackground();
                                }
                        }
                        _detailsPanel._name.Text = taskPanel._task._name;
                        _detailsPanel._details.Text = taskPanel._task._details;

                        Constants.Debug.CW("NAME : " + taskPanel._task._name);
                        Constants.Debug.CW("DETAILS ON SINGLE : " + taskPanel._task._details);

                }
        }//class TaskPanel
}//ns
