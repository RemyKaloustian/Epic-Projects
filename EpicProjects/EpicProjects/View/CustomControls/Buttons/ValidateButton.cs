using EpicProjects.Constants;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EpicProjects.View.CustomControls
{
        public class ValidateButton : CustomButton
        {
                public ValidateButton(string content, double width, double height, System.Windows.Thickness margin,System.Windows.Thickness padding, HorizontalAlignment hAlign ) : base(content,width, height,margin , padding,hAlign)
                {
                        //this.MouseEnter += ValidateButton_MouseEnter;
                        //this.MouseLeave+=ValidateButton_MouseLeave;
                        
                }

                //private void ValidateButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                //{
                //        this.Background = ThemeSelector.GetButtonColor();
                //        _block.Foreground = ThemeSelector.GetButtonContentColor();
                //}

                //void ValidateButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                //{
                //        this.Background = ThemeSelector.GetButtonContentColor();
                //        _block.Foreground = ThemeSelector.GetButtonColor();
                ////}
                //public override void SetColor()
                //{
                //        this.Background = ThemeSelector.GetButtonColor();
                //}
        }//class ValidateButton
}//ns
