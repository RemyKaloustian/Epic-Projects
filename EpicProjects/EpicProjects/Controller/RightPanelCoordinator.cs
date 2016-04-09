using EpicProjects.Constants;
using EpicProjects.View.CustomControls.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.Controller
{
        public class RightPanelCoordinator
        {
                public ContentPanel _contentPanel { get; set; }

                public RightPanelCoordinator(ContentPanel contentP)
                {
                        _contentPanel = contentP;
                }

                public void ToOptions()
                {
                        //_contentPanel._rightPanel = _contentPanel._optionsPanel;
                        _contentPanel.Children.Remove(_contentPanel._detailsPanel);
                        _contentPanel.Children.Add(_contentPanel._optionsPanel);
                        _contentPanel._isOnOptions = true;
                }

                public void ToDetails(DetailsPanel dp)
                {
                        //_contentPanel._rightPanel = _contentPanel._detailsPanel;
                        //_contentPanel._rightPanel.UpdateLayout();
                        _contentPanel.Children.Remove(_contentPanel._optionsPanel);
                        //_contentPanel.Children.Remove(_contentPanel._detailsPanel);

                        StackPanel map = new StackPanel();
                        map.Width = 500;
                        map.Height = 800;
                        map.Background = Palette2.GetColor(Palette2.EMERALD);

                        _contentPanel.Children.Add(dp);

                }

                internal void ToDetails(string name, string details, SingleTaskPanel taskPanel, string priority)
                {
                        _contentPanel.Children.Remove(_contentPanel._optionsPanel);
                        if(_contentPanel._detailsPanel == null)
                        {
                                DetailsPanel dp = new DetailsPanel(name, details, taskPanel,this, priority);
                                _contentPanel._detailsPanel = dp; 
                                _contentPanel.Children.Add(_contentPanel._detailsPanel);
                               // _contentPanel._rightPanel = _contentPanel._detailsPanel;
                               


                        }
                        else
                        {
                                if(!_contentPanel._isOnOptions)
                                {
                                        _contentPanel._detailsPanel._name.Text = name;
                                        _contentPanel._detailsPanel._details.Text = details;
                                        _contentPanel._detailsPanel._taskPanel = taskPanel;
                                }
                                else
                                {
                                        Debug.CW("IN ELESE");
                                        _contentPanel._detailsPanel._name.Text = name;
                                        _contentPanel._detailsPanel._details.Text = details;
                                        _contentPanel._detailsPanel._taskPanel = taskPanel;
                                        _contentPanel.Children.Add(_contentPanel._detailsPanel);
                                }
                                
                                //_contentPanel._rightPanel = _contentPanel._detailsPanel;


                        }

                        _contentPanel._isOnOptions = false;

                        Debug.CW("In ToDetails : _isOnOptions = " + _contentPanel._isOnOptions);
                        
                }
        }//class RightPanelCoordinator
}//ns
