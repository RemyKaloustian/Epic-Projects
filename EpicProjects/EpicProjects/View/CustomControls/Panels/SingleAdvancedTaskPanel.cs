﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EpicProjects.Model;
using EpicProjects.Constants;
using System.Windows.Controls;
using EpicProjects.View.Theme;
namespace EpicProjects.View.CustomControls.Panels
{

        /// <summary>
        /// Is used for the trainings, the assignments, and maintenances
        /// Panel where lies the data (name, priority shortcut, state shortcut)
        /// </summary>
        public class SingleAdvancedTaskPanel : SingleTaskPanel
        {
                public AdvancedTask _advancedTask { get; set; }
                public TextBlock _priority { get; set; }
                public TextBlock _state { get; set; }

                public Separator _prioritySeparator { get; set; }
                public Separator _stateSeparator { get; set; }

                public SingleAdvancedTaskPanel(AdvancedTask aTask):base()
                { 
                        _advancedTask = aTask;
                        _content.Text = _advancedTask._name;

                        SetUpPriority();
                        SetUpState();

                       // SetUpSeparators();

                        //this.Children.Add(_prioritySeparator);
                        this.Children.Add(_priority);
                        //this.Children.Add(_stateSeparator);
                        this.Children.Add(_state);

                 }

                private void SetUpPriority()
                {
                        _priority = new TextBlock();
                        _priority.FontFamily = FontProvider._lato;
                        _priority.FontSize = 20;
                        _priority.Foreground = ThemeSelector.GetAccentColor();
                        _priority.Margin = new System.Windows.Thickness(10, 0, 0, 0);
                        _priority.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                       // _priority.Width = Dimensions.GetWidth() * 0.1;

                        //_priority.Margin = new System.Windows.Thickness(Dimensions.GetWidth() * 0.6 * 0.8, 0, 0, 0);
                        if(_advancedTask._priority == Priorities.NOT_IMPORTANT)
                        {
                                _priority.Text = "\u2606";
                        }

                        else if (_advancedTask._priority == Priorities.LESS_IMPORTANT)
                        {
                                _priority.Text = "\u2606 \u2606";
                        }

                        else if (_advancedTask._priority == Priorities.IMPORTANT)
                        {
                                _priority.Text = "\u2606 \u2606 \u2606";
                        }

                        else if (_advancedTask._priority == Priorities.ULTRA_IMPORTANT)
                        {
                                _priority.Text = "\u2606 \u2606 \u2606 \u2606";
                        }

                        else if (_advancedTask._priority == Priorities.MOST_IMPORTANT)
                        {
                                _priority.Text = "\u2606 \u2606 \u2606 \u2606 \u2606";
                        }
                }


                private void SetUpState()
                {
                        _state = new TextBlock();
                        _state.FontFamily = FontProvider._lato;
                        _state.FontSize = 20;
                        _state.Foreground = ThemeSelector.GetAccentColor();
                        _state.Margin = new System.Windows.Thickness(10, 0, 0, 0);
                        _state.VerticalAlignment = System.Windows.VerticalAlignment.Center;

                        if(_advancedTask._state == States.OPEN)
                        {
                                _state.Text = "O";
                        }

                        else if (_advancedTask._state == States.PROGRESS)
                        {
                                _state.Text = "IP";
                               
                        }

                        else if (_advancedTask._state == States.DONE)
                        {
                                _state.Text = "D";
                        }
                }

                private void SetUpSeparators()
                {
                        _prioritySeparator = new Separator();
                        
                        _prioritySeparator.Foreground = ThemeSelector.GetAccentColor();

                        _prioritySeparator.Height = 30;


                        _stateSeparator = new Separator();
                        _stateSeparator.Foreground = ThemeSelector.GetAccentColor();

                        _stateSeparator.Height = 30;
                }

             
        }//class SingleAdvancedTaskPanel
}//ns
