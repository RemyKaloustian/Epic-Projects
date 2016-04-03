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

                public TaskPanel(DetailsPanel detailsPanel, string name)
                {
                        _chief = new TaskMasterChief(name);
                        _detailsPanel = detailsPanel;
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;

                        this.Width = Dimensions.GetWidth() * 0.6;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = Palette2.GetColor(Palette2.LIGHT_GRAY);
                }


                public void FillBrainstormings()
                {

                        Constants.Debug.CW("In FillBrainsTorming");
                        List<Model.Task> brains = _chief.SelectBrainstormings();

                        foreach (Model.Task item in brains)
                        {
                                SingleTaskPanel p = new SingleTaskPanel(item);
                                
                                this.Children.Add(p);
                        }
                }
        }//class TaskPanel
}//ns
