using EpicProjects.Constants;
using EpicProjects.View.CustomControls.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicProjects.Controller
{
        public class EventCoordinator
        {
                public HeaderPanel _headerPanel  { get; set; }
                public ContentPanel _contentPanel { get; set; }

                public EventCoordinator(HeaderPanel headerPanel, ContentPanel contentPanel)
                {
                        _headerPanel = headerPanel;
                        _contentPanel = contentPanel;

                        AddEvents();

                }


                private void AddEvents()
                {
                        _headerPanel._titlesPanel._brainstormingItem.MouseDown += _brainstormingItem_MouseDown;

                        _headerPanel._titlesPanel._trainingItem.MouseDown += _trainingItem_MouseDown;

                        _headerPanel._titlesPanel._assignmentsItem.MouseDown += _assignmentsItem_MouseDown;

                        _headerPanel._titlesPanel._maintenanceItem.MouseDown += _maintenanceItem_MouseDown;

                        
                }

                void _maintenanceItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if (_headerPanel._titlesPanel._maintenanceItem._addPanel.IsMouseOver)
                                _contentPanel.LoadMaintenanceAddition();
                        else
                        {
                                _headerPanel.HighlightMaintenance();
                                _contentPanel.LoadMaintenance();

                        }
                        
                }

                void _assignmentsItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if (_headerPanel._titlesPanel._assignmentsItem._addPanel.IsMouseOver)
                                _contentPanel.LoadAssignmentsAddition();
                        else
                        {
                                _headerPanel.HighlightAssignments();
                               _contentPanel.LoadAssignments(); 

                        }
                        
                }

                void _trainingItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if (_headerPanel._titlesPanel._trainingItem._addPanel.IsMouseOver)
                                _contentPanel.LoadTrainingAddition();
                        else
                        {
                                _headerPanel.HighlightTraining();
                                _contentPanel.LoadTraining();

                        }
                        
                }

                void _brainstormingItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if(_headerPanel._titlesPanel._brainstormingItem._addPanel.IsMouseOver)
                                _contentPanel.LoadBrainstormingAddition();
                        else
                        {
                                _headerPanel.HighlightBrainstorming();
                                _contentPanel.LoadBrainstorming();

                        }
                                
                }
        }//class EventCoordinator
}//ns
