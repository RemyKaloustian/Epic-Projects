using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using EpicProjects.Constants;

namespace EpicProjects.Sketches.Custom
{
        /// <summary>
        /// Interaction logic for CustomHome.xaml
        /// </summary>
        public partial class CustomHome : Window
        {

                public uint _colorCounter { get; set; }

                public uint _colorCounter2;
                public uint _palette { get; set; }
                public CustomHome()
                {
                        InitializeComponent();
                        this.KeyDown += Window_KeyDown;

                        _colorCounter = 0;
                        _colorCounter2 = 0;
                        _palette = 1;
                }

                private void Window_KeyDown(object sender, KeyEventArgs e)
                {
                        if(e.Key == Key.N)
                        {
                                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                                        MessageBox.Show("New project OMG");
                        }

                        if(e.Key == Key.O)
                        {
                                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                                        MessageBox.Show("Open project damn");
                        }

                        if (e.Key == Key.S)
                        {
                                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                                        MessageBox.Show("Settings, mister no happy ?");
                        }
                }

                private void ColorChangerButton_Click(object sender, RoutedEventArgs e)
                {
                        if(_palette == 1)
                        {
                                if (_colorCounter > 1)
                                        _colorCounter--;

                                ChangeColor();
                        }
                        else if(_palette == 2)
                        {
                                if (_colorCounter2 > 1)
                                        _colorCounter2--;

                                ChangeFlatColor();
                        }
                        
                }

                private void ChangeColor()
                {
                        if (_colorCounter == 1)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.AMBER));
                                ColorBlock.Text = "Color : AMBER \n HEX : " + Constants.Brushes.AMBER;
                        }
                        if (_colorCounter == 2){ 
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.BLUE));
                                ColorBlock.Text = "Color : BLUE \n HEX : " + Constants.Brushes.BLUE;
                        }
                        if (_colorCounter == 3) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.BLUE_GREY));
                                ColorBlock.Text = "Color : BLUE_GREY \n HEX : " + Constants.Brushes.BLUE_GREY;
                        }
                        if (_colorCounter == 4) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.BROWN));
                                ColorBlock.Text = "Color : BROWN \n HEX : " + Constants.Brushes.BROWN;
                        }
                        if (_colorCounter == 5){
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.CABARET));
                                ColorBlock.Text = "Color : CABARET \n HEX : " + Constants.Brushes.CABARET;
                        }
                        if (_colorCounter == 6) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.CALIFORNIA));
                                ColorBlock.Text = "Color : CALIFORNIA \n HEX : " + Constants.Brushes.CALIFORNIA;
                        }
                        if (_colorCounter == 7) {
                                //TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.CONFETTI));
                                //ColorBlock.Text = "Color : CONFETTI \n HEX : " + Constants.Brushes.CONFETTI;
                        }
                        if (_colorCounter == 8) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.CYAN));
                                ColorBlock.Text = "Color : CYAN \n HEX : " + Constants.Brushes.CYAN;
                        }
                        if (_colorCounter == 9) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.DEEP_ORANGE));
                                ColorBlock.Text = "Color : DEEP_ORANGE \n HEX : " + Constants.Brushes.DEEP_ORANGE;
                        
                        }
                        if (_colorCounter == 10){ 
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.DEEP_PURPLE));
                                ColorBlock.Text = "Color : DEEP_PURPLE \n HEX : " + Constants.Brushes.DEEP_PURPLE;
                        }
                        if (_colorCounter == 11) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.DODGER_BLUE));
                                ColorBlock.Text = "Color : DODGER_BLUE \n HEX : " + Constants.Brushes.DODGER_BLUE;
                        }
                        if (_colorCounter == 12) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.EBONY_CLAY));
                                ColorBlock.Text = "Color : EBONY_CLAY \n HEX : " + Constants.Brushes.EBONY_CLAY;
                        }
                        if (_colorCounter == 13){
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.ECSTASY));
                                ColorBlock.Text = "Color : ECSTASY \n HEX : " + Constants.Brushes.ECSTASY;
                        }
                        if (_colorCounter == 14){ 
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.EDWARD));
                                ColorBlock.Text = "Color : EDWARD \n HEX : " + Constants.Brushes.EDWARD;
                        }
                        if (_colorCounter == 15) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.EMERALD));
                                ColorBlock.Text = "Color : EMERALD \n HEX : " + Constants.Brushes.EMERALD;
                        }
                        if (_colorCounter == 16) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.EUCALYPTUS));
                                ColorBlock.Text = "Color : EUCALYPTUS \n HEX : " + Constants.Brushes.EUCALYPTUS;
                        }
                        if (_colorCounter == 17){
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.GREEN));
                                ColorBlock.Text = "Color : GREEN \n HEX : " + Constants.Brushes.GREEN;
                        }
                        if (_colorCounter == 18) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.GREY));
                                ColorBlock.Text = "Color : GREY \n HEX : " + Constants.Brushes.GREY;
                        }
                        if (_colorCounter == 19) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.INDIGO));
                                ColorBlock.Text = "Color : INDIGO \n HEX : " + Constants.Brushes.INDIGO;
                        }
                        if (_colorCounter == 20){
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.LIGHT_GREEN));
                                ColorBlock.Text = "Color : LIGHT_GREEN \n HEX : " + Constants.Brushes.LIGHT_GREEN;
                        }
                        if (_colorCounter == 21) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.LIME));
                                ColorBlock.Text = "Color : LIME \n HEX : " + Constants.Brushes.LIME;
                        }
                        if (_colorCounter == 22){ 
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.LYNCH));
                                ColorBlock.Text = "Color : LYNCH \n HEX : " + Constants.Brushes.LYNCH;
                        }
                        if (_colorCounter == 23){ 
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.MEDIUM_PURPLE));
                                ColorBlock.Text = "Color : MEDIUM_PURPLE \n HEX : " + Constants.Brushes.MEDIUM_PURPLE;
                        }
                        if (_colorCounter == 25) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.ORANGE));
                                ColorBlock.Text = "Color : ORANGE \n HEX : " + Constants.Brushes.ORANGE;
                        }
                        if (_colorCounter == 26) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.PICKLED_BLUEWOOD));
                                ColorBlock.Text = "Color : PICKLED_BLUEWOOD \n HEX : " + Constants.Brushes.PICKLED_BLUEWOOD;
                        }
                        if (_colorCounter == 27) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.PINK));
                                ColorBlock.Text = "Color : PINK \n HEX : " + Constants.Brushes.PINK;
                        }
                        if (_colorCounter == 28) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.POMEGRANATE));
                                ColorBlock.Text = "Color : POMEGRANATE \n HEX : " + Constants.Brushes.POMEGRANATE;
                        }
                        if (_colorCounter == 29){ 
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.PURPLE));
                                ColorBlock.Text = "Color : PURPLE \n HEX : " + Constants.Brushes.PURPLE;
                        }
                        if (_colorCounter == 30) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.REBECCA_PURPLE));
                                ColorBlock.Text = "Color : REBECCA_PURPLE \n HEX : " + Constants.Brushes.REBECCA_PURPLE;
                        }
                        if (_colorCounter == 31){
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.RED));
                                ColorBlock.Text = "Color : RED \n HEX : " + Constants.Brushes.RED;
                        }
                        if (_colorCounter == 32){ 
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.SAN_MARINO));
                                ColorBlock.Text = "Color : SAN_MARINO \n HEX : " + Constants.Brushes.SAN_MARINO;
                        }
                        if (_colorCounter == 33){ 
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.SANDSTORM));
                                ColorBlock.Text = "Color : SANDSTORM \n HEX : " + Constants.Brushes.SANDSTORM;
                        }
                        if (_colorCounter == 34) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.SEANCE));
                                ColorBlock.Text = "Color : SEANCE \n HEX : " + Constants.Brushes.SEANCE;
                        }
                        if (_colorCounter == 35){
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.STUDIO));
                                ColorBlock.Text = "Color : STUDIO \n HEX : " + Constants.Brushes.STUDIO;
                        }
                        if (_colorCounter == 36) {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.TEAL));
                                ColorBlock.Text = "Color : TEAL \n HEX : " + Constants.Brushes.TEAL;
                        }
                        if (_colorCounter == 37)
                        {
                                //TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.YELLOW));
                                //ColorBlock.Text = "Color : YELLOW \n HEX : " + Constants.Brushes.YELLOW;
                        }


                }

                private void NextColorButton_Click(object sender, RoutedEventArgs e)
                {
                        if(_palette == 1)
                        {
                                if (_colorCounter < 37)
                                        _colorCounter++;
                                else
                                        _colorCounter = 1;

                                ChangeColor();
                        }

                        else if(_palette == 2)
                        {
                                if (_colorCounter2 < 18)
                                        _colorCounter2++;
                                else
                                        _colorCounter2 = 1;

                                ChangeFlatColor();
                        }
                    
                }

                private void PaletteButton_Click(object sender, RoutedEventArgs e)
                {
                        if (_palette == 1)
                        {
                                _palette = 2;
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.ALIZARIN));
                                ColorBlock.Text = "COLOR : ALIZARIN \n HEX : " + Palette2.ALIZARIN;
                                _colorCounter2 = 0;
                        }
                        else if (_palette == 2)
                        {
                                _palette = 1;
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Constants.Brushes.AMBER));
                                _colorCounter = 0;
                                ColorBlock.Text = "COLOR : AMBER \n HEX : " + Constants.Brushes.AMBER;
                        }

                        PaletteBlock.Text = "PALETTE : " + _palette;
                }

                private void ChangeFlatColor()
                {
                        if(_colorCounter2 == 1)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.AMETHYST));
                                ColorBlock.Text = "Color : AMETHYST \n HEX : " + Palette2.AMETHYST;
                        }
                        if (_colorCounter2 == 2)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.ASBESTOS));
                                ColorBlock.Text = "Color : ASBESTOS \n HEX : " + Palette2.ASBESTOS;
                        }
                        if (_colorCounter2 == 3)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.BELIZE_HOLE));
                                ColorBlock.Text = "Color : BELIZE_HOLE \n HEX : " + Palette2.BELIZE_HOLE;
                        }
                        if (_colorCounter2 == 4)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CARROT));
                                ColorBlock.Text = "Color : CARROT \n HEX : " + Palette2.CARROT;
                        }
                        if (_colorCounter2 == 5)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CONCRETE));
                                ColorBlock.Text = "Color : CONCRETE \n HEX : " + Palette2.CONCRETE;
                        }
                        if (_colorCounter2 == 6)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.EMERALD));
                                ColorBlock.Text = "Color : EMERALD \n HEX : " + Palette2.EMERALD;
                        }
                        if (_colorCounter2 == 7)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.GREEN_SEA));
                                ColorBlock.Text = "Color : GREEN_SEA \n HEX : " + Palette2.GREEN_SEA;
                        }
                        if (_colorCounter2 == 8)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.MIDNIGHT_BLUE));
                                ColorBlock.Text = "Color : MIDNIGHT_BLUE \n HEX : " + Palette2.MIDNIGHT_BLUE;
                        }
                        if (_colorCounter2 == 9)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.NEPHRITIS));
                                ColorBlock.Text = "Color : NEPHRITIS \n HEX : " + Palette2.NEPHRITIS;
                        }
                        if (_colorCounter2 == 10)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.ORANGE));
                                ColorBlock.Text = "Color : ORANGE \n HEX : " + Palette2.ORANGE;
                        }
                        if (_colorCounter2 == 11)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.PETER_RIVER));
                                ColorBlock.Text = "Color : PETER_RIVER \n HEX : " + Palette2.PETER_RIVER;
                        }
                        if (_colorCounter2 == 12)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.POMEGRANATE));
                                ColorBlock.Text = "Color : POMEGRANATE \n HEX : " + Palette2.POMEGRANATE;
                        }
                        if (_colorCounter2 == 13)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.PUMPKIN));
                                ColorBlock.Text = "Color : PUMPKIN \n HEX : " + Palette2.PUMPKIN;
                        }
                        if (_colorCounter2 == 14)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.SILVER));
                                ColorBlock.Text = "Color : SILVER \n HEX : " + Palette2.SILVER;
                        }
                        if (_colorCounter2 == 15)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.SUN_FLOWER));
                                ColorBlock.Text = "Color : SUN_FLOWER \n HEX : " + Palette2.SUN_FLOWER;
                        }
                        if (_colorCounter2 == 16)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.TURQUOISE));
                                ColorBlock.Text = "Color : TURQUOISE \n HEX : " + Palette2.TURQUOISE;
                        }
                        if (_colorCounter2 == 17)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.WET_ASPHALT));
                                ColorBlock.Text = "Color : WET_ASPHALT \n HEX : " + Palette2.WET_ASPHALT;
                        }
                        if (_colorCounter2 == 18)
                        {
                                TheGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.WISTERIA));
                                ColorBlock.Text = "Color : WISTERIA \n HEX : " + Palette2.WISTERIA;
                        }


                }

        }
}
