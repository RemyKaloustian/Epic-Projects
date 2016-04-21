using EpicProjects.Constants;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EpicProjects.View.CustomControls.Buttons
{
        public class DefaultButton : CustomButton
        {
                public DefaultButton(string content, double width, double height, System.Windows.Thickness margin, System.Windows.Thickness padding, HorizontalAlignment hAlign)
                        : base(content, width, height, margin, padding, hAlign)
                {
                        this.Background =ThemeSelector.GetBackground();
                        _block.Foreground = ThemeSelector.GetAccentColor();

                        this.MouseEnter += DefaultButton_MouseEnter;
                        this.MouseLeave += DefaultButton_MouseLeave;

                        _block.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                }

                void DefaultButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = ThemeSelector.GetBackground();
                        _block.Foreground = ThemeSelector.GetAccentColor();
                }

                void DefaultButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = Palette2.GetColor(Palette2.DEFAULT_HOVER);
                       // _block.Foreground = ThemeSelector.GetBackground();
                }

                public override void SetColor()
                {
                        //this.Background = Palette2.GetColor(Palette2.ALTERNATIVE);
                }
        }//class DefaultButton
}//ns
