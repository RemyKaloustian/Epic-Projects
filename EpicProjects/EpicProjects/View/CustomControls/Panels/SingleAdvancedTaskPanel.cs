using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EpicProjects.Model;
using EpicProjects.Constants;
namespace EpicProjects.View.CustomControls.Panels
{


        public class SingleAdvancedTaskPanel : SingleTaskPanel
        {
                public AdvancedTask _advancedTask { get; set; }

                public SingleAdvancedTaskPanel(AdvancedTask aTask):base()
                { 
                        _advancedTask = aTask;
                        _content.Text = _advancedTask._name;
                 }

             
        }//class SingleAdvancedTaskPanel
}//ns
