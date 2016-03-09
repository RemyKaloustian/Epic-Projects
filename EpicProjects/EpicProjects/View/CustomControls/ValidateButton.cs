using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.View.CustomControls
{
        public class ValidateButton : CustomButton
        {
                public ValidateButton(string content, double width ) : base(content,width)
                {
                        this.MouseEnter += ValidateButton_MouseEnter;
                        this.MouseLeave+=ValidateButton_MouseLeave;
                }

                private void ValidateButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = Palette2.GetColor(Palette2.VALIDATE);
                }

                void ValidateButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = Palette2.GetColor(Palette2.VALIDATE_HOVER);
                }
                public override void SetColor()
                {
                        this.Background = Palette2.GetColor(Palette2.VALIDATE);
                }
        }
}
