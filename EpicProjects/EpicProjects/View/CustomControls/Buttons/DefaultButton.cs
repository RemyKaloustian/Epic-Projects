using EpicProjects.Constants;
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
                public DefaultButton(string content, double width, double height, System.Windows.Thickness margin, System.Windows.Thickness padding, HorizontalAlignment hAlign, Theme.Theme theme)
                        : base(content, width, height, margin, padding, hAlign, theme)
                {
                        this.Background = new Theme.CustomTheme().GetBackground();
                        _block.Foreground = new Theme.CustomTheme().GetAccentColor();

                        this.MouseEnter += DefaultButton_MouseEnter;
                        this.MouseLeave += DefaultButton_MouseLeave;

                        _block.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                }

                void DefaultButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = new Theme.CustomTheme().GetBackground();
                        _block.Foreground = new Theme.CustomTheme().GetAccentColor();
                }

                void DefaultButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = Palette2.GetColor(Palette2.DEFAULT_HOVER);
                       // _block.Foreground = new Theme.CustomTheme().GetBackground();
                }

                public override void SetColor()
                {
                        //this.Background = Palette2.GetColor(Palette2.ALTERNATIVE);
                }
        }//class DefaultButton
}//ns
