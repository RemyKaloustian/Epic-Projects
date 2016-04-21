using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EpicProjects.View.CustomControls.Home
{
        public class AlternativeButton : CustomButton
        {
                public AlternativeButton(string content, double width, double height, System.Windows.Thickness margin, System.Windows.Thickness padding, HorizontalAlignment hAlign)
                        : base(content, width, height, margin, padding, hAlign)
                {
                        this.MouseEnter += AlternativeButton_MouseEnter;
                        this.MouseLeave += AlternativeButton_MouseLeave;
                }

                void AlternativeButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = Palette2.GetColor(Palette2.ALTERNATIVE);
                }

                void AlternativeButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = Palette2.GetColor(Palette2.ALTERNATIVE_HOVER);
                }

                public override void SetColor()
                {
                        this.Background = Palette2.GetColor(Palette2.ALTERNATIVE);
                }
        }//class AlternativeButton
}//ns
