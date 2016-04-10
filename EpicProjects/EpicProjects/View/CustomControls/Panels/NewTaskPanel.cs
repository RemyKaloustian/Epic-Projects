using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        //!!!!!!!!!!!!!!!!!!!!NOT USED \ TO DELETE
      
        public class NewTaskPanel:StackPanel
        {
                public TextBlock _block { get; set; }

                public StackPanel _quitButton { get; set; }

                public NewTaskPanel()
                {
                        _block = new TextBlock();
                        _block.Text = "ghazdjvbdf,";

                        _quitButton = new StackPanel();
                        _quitButton.Height = 300;
                        _quitButton.Width = 400;
                        _quitButton.Background = Palette2.GetColor(Palette2.ALTERNATIVE);

                        this.Children.Add(_block);
                        this.Children.Add(_quitButton);
                }
        }//NewTaskPanel()
}//ns
