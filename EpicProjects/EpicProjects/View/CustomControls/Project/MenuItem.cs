using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace EpicProjects.View.CustomControls.Project
{
        class MenuItem : StackPanel
        {
                public StackPanel _upperPanel { get; set; }
                public TextBlock _itemText{ get; set; }

                public MenuItem (string text)
	        {
                        this.Orientation = Orientation.Vertical;
                        this.Height = 50;
                        this.Background = new SolidColorBrush(Colors.DarkMagenta);

                        this._upperPanel = new StackPanel();
                        _upperPanel.Height = 5;
                        _upperPanel.Background = new SolidColorBrush(Color.FromRgb(121,85,72));


                        this._itemText = new TextBlock();
                        _itemText.Text = text;
                        _itemText.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        _itemText.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        
                        this.Children.Add(_itemText);
                        this.Children.Add(_upperPanel);

                        this.MouseEnter += MenuItem_MouseEnter;
                        this.MouseLeave += MenuItem_MouseLeave;


	        }

                void MenuItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this._upperPanel.Background = new SolidColorBrush(Color.FromRgb(121, 85, 72));
                }

                void MenuItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this._upperPanel.Background = new SolidColorBrush(Color.FromRgb(33, 150, 243));
                }
        }
}
