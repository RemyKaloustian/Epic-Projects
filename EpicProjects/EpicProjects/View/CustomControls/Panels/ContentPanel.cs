﻿using EpicProjects.Constants;
using EpicProjects.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class ContentPanel : StackPanel
        {
                public TaskPanel _taskPanel { get; set; }
                public DetailsPanel  _detailsPanel { get; set; }
                public OptionsPanel _optionsPanel { get; set; }
                public StackPanel _rightPanel { get; set; }

                public bool _firstLoad { get; set; }
                public bool _isOnOptions { get; set; }

                public ContentPanel(string name)
                {
                        this.Height = Dimensions.GetHeight()*0.75;
                        this.Margin = new System.Windows.Thickness(0, 10, 0, 0);
                        //this.Background = Palette2.GetColor(Palette2.GREEN_SEA);

                        RightPanelCoordinator coord = new RightPanelCoordinator(this);
                       // _detailsPanel = new DetailsPanel(coord);
                        _optionsPanel = new OptionsPanel();
                        
                        _taskPanel = new TaskPanel(_detailsPanel,name,coord);
                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;

                      //  _detailsPanel.Visibility = System.Windows.Visibility.Hidden;

                        _rightPanel = _optionsPanel;

                        _firstLoad = true;
                        _isOnOptions = true;

                        this.Children.Add(_taskPanel);
                        //this.Children.Add(_detailsPanel);
                        this.Children.Add(_rightPanel);
                        //this.Children.Add(_optionsPanel);


                        LoadBrainstorming();
                }

                public void LoadBrainstorming()
                {
                        

                        _taskPanel.FillBrainstormings();
                        if(!_firstLoad && !_isOnOptions)
                        {
                                //this.Children.Remove(_detailsPanel);
                               // this.Children.Add(_optionsPanel);
                                this._rightPanel = _optionsPanel;
                        }

                        else if(_firstLoad)
                        {
                                _firstLoad = false;
                        }
                        

                        //this.Children.Add(block);
                }

                public void LoadTraining()
                {
                        _taskPanel.FillTrainings();
                        if(!_isOnOptions)
                        {
                                //this.Children.Remove(_detailsPanel);
                                //this.Children.Add(_optionsPanel);
                                this._rightPanel = _optionsPanel;

                        }
                        

                }


                public void LoadAssignments()
                {
                        _taskPanel.FillAssignments();
                        if(!_isOnOptions)
                        {
                                //this.Children.Remove(_detailsPanel);
                                //this.Children.Add(_optionsPanel);
                                this._rightPanel = _optionsPanel;

                        }
                        
                }

                public void LoadMaintenance()
                {
                        _taskPanel.FillMaintenances();
                        if(!_isOnOptions)
                        {
                                //this.Children.Remove(_detailsPanel);
                                //this.Children.Add(_optionsPanel);
                                this._rightPanel = _optionsPanel;

                        }
                       
                }

                public  void LoadBrainstormingAddition()
                {
                        this.Children.Clear();
                        TextBlock block = new TextBlock();
                        block.Text = "NU BRAINSTORLING ?";
                        block.FontSize = 50;

                        this.Children.Add(block);

                      
                }

                internal void LoadTrainingAddition()
                {
                        this.Children.Clear();
                        TextBlock block = new TextBlock();
                        block.Text = "NU TRAININg ?";
                        block.FontSize = 50;

                        this.Children.Add(block);
                }

                internal void LoadAssignmentsAddition()
                {
                        this.Children.Clear();
                        TextBlock block = new TextBlock();
                        block.Text = "NU ASSIGNMENT ?";
                        block.FontSize = 50;

                        this.Children.Add(block);
                }

                internal void LoadMaintenanceAddition()  
                {                        
                        this.Children.Clear();
                        TextBlock block = new TextBlock();
                        block.Text = "NU MAINTENANCE ?";
                        block.FontSize = 50;

                        this.Children.Add(block);
                }

                
        }//class ContentPanel
}//ns
