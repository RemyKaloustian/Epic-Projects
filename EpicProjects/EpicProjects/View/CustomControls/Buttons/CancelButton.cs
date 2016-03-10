using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EpicProjects.View.CustomControls
{
        public class CancelButton : CustomButton
        {
                public CancelButton(string content, double width, double height, System.Windows.Thickness margin,System.Windows.Thickness padding, HorizontalAlignment hAlign, Theme.Theme theme ) : base(content,width, height, margin , padding,hAlign, theme)
                {
                        this.MouseEnter += CancelButton_MouseEnter;
                        this.MouseLeave += CancelButton_MouseLeave;
                }

                void CancelButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = Palette2.GetColor(Palette2.CANCEL);
                }

                void CancelButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = Palette2.GetColor(Palette2.CANCEL_HOVER);
                }

                public override void SetColor()
                {
                        this.Background = Palette2.GetColor(Palette2.CANCEL);
                }
        }
}
