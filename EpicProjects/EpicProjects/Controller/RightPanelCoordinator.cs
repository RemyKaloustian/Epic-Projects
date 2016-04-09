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
        /// <summary>
        /// Coordinates the layout modifications between the ContentPanel and the RightPanel
        /// </summary>
        public class RightPanelCoordinator
        {
                public ContentPanel _contentPanel { get; set; }

                public RightPanelCoordinator(ContentPanel contentP)
                {
                        _contentPanel = contentP;
                }

                /// <summary>
                /// Displays the Options panel
                /// </summary>
                public void ToOptions()
                {
                        _contentPanel.Children.Remove(_contentPanel._detailsPanel);
                        _contentPanel.Children.Add(_contentPanel._optionsPanel);
                        _contentPanel._isOnOptions = true;
                }

                /// <summary>
                /// Displays the Details panel
                /// </summary>
                /// <param name="dp"></param>
                internal void ToDetails(string name, string details, SingleTaskPanel taskPanel, string priority)
                {
                        //Removing the options panel so that the right panel can become the details panel
                        _contentPanel.Children.Remove(_contentPanel._optionsPanel);

                        //If the details panel has not been instantiated
                        if(_contentPanel._detailsPanel == null)
                        {
                                //We create a new details panel and add it to the content panel
                                DetailsPanel dp = new DetailsPanel(name, details, taskPanel,this, priority);
                                _contentPanel._detailsPanel = dp;
                                _contentPanel._detailsPanel.SetPriorityLayout(priority);
                                _contentPanel.Children.Add(_contentPanel._detailsPanel);  
                        }
                        //If the details panel already exists
                        else
                        {
                              //We set the priority 
                                _contentPanel._detailsPanel.SetPriorityLayout(priority);

                                //If we are not on the options panel
                                if(!_contentPanel._isOnOptions)
                                {
                                        //We just change the content of the details panel
                                        SetUpDetailsContent(name, details, taskPanel, priority);
                                }

                                else
                                {
                                        SetUpDetailsContent(name, details, taskPanel, priority);
                                        //We are not on a details panel, so we add the one created to the layout
                                        _contentPanel.Children.Add(_contentPanel._detailsPanel);
                                }                                
                                
                                if(priority != null)
                                {
                                        //There is a priority to display, so we display it
                                        _contentPanel._detailsPanel.DisplayPriority(priority);
                                }

                        }

                        //We are on the details panel, we are no longer on the options panel
                        _contentPanel._isOnOptions = false;
                }//ToDetails

                private void SetUpDetailsContent(string name, string details, SingleTaskPanel taskPanel, string priority)
                {
                        _contentPanel._detailsPanel._name.Text = name;
                        _contentPanel._detailsPanel._details.Text = details;
                        _contentPanel._detailsPanel._taskPanel = taskPanel;
                        _contentPanel._detailsPanel.SetPriorityLayout(priority);
                }//SetUpDetailsContent()

        }//class RightPanelCoordinator
}//ns
