using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls
{
        public abstract class  CustomButton : StackPanel
        {
                public TextBlock _block { get; set; }

                public CustomButton(string content, double width)
                {
                        _block = new TextBlock();
                        _block.Text = content;

                        this.Width = width;
                        this.SetColor();
                }

                public abstract void SetColor();


        }//class CustomButton
}//ns
