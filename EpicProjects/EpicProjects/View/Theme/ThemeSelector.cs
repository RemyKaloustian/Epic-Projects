using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;

namespace EpicProjects.View.Theme
{
        public class ThemeSelector
        {
                public static SolidColorBrush _lastSavedAccent;
                public static Theme  _theme{ get; set; }
                public static string _accent  { get; set; }


                public static void InitializeTheme()
                {
                        string type = ReadThemeType();
                        _accent = ReadAccent();
                        if(type == Themes.LIGHT)
                        {
                                _theme = new LightTheme(_accent);
                                _lastSavedAccent = _theme.GetAccentColor();
                        }


                        else if(type == Themes.DARK)
                        {
                                _theme = new DarkTheme(_accent);
                                _lastSavedAccent = _theme.GetAccentColor();
                        }

                        else if(type == Themes.CUSTOM)
                        {
                                _theme = new CustomTheme(_accent);
                                _lastSavedAccent = _theme.GetBackground();
                        }

                }//InitializeTheme()

                public static string ReadAccent()
                {
                        string accent = "";

                        XmlDocument doc = new XmlDocument();
                        doc.Load(DatabaseValues.THEME_SAVE);

                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.THEME_ACCENT_PATH);

                        foreach (XmlNode item in nodelist)
                        {

                                accent = item.Attributes[DatabaseValues.VALUE].InnerText;

                        }

                        return accent;
                }//ReadAccent()

                public static string ReadThemeType()
                {
                        string type = ""; 

                        XmlDocument doc = new XmlDocument();
                        doc.Load(DatabaseValues.THEME_SAVE);

                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.THEME_TYPE_PATH);

                        foreach (XmlNode item in nodelist)
                        {

                                type = item.Attributes[DatabaseValues.TYPE].InnerText;

                        }

                        return type;
                }//ReadThemeType()

                public static void ChangeThemeType(string newType)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(DatabaseValues.THEME_SAVE);

                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.THEME_TYPE_PATH);

                        foreach (XmlNode item in nodelist)
                        {

                                 item.Attributes[DatabaseValues.TYPE].InnerText = newType;

                        }

                        doc.Save(DatabaseValues.THEME_SAVE);
                }//ChangeThemeType()

                public static void ChangeAccent(string accent)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(DatabaseValues.THEME_SAVE);

                        XmlNodeList nodelist = doc.SelectNodes(DatabaseValues.THEME_ACCENT_PATH);

                        foreach (XmlNode item in nodelist)
                        {

                                item.Attributes[DatabaseValues.VALUE].InnerText = accent;

                        }

                        doc.Save(DatabaseValues.THEME_SAVE);

                }//ChangeAccent()

                public  static SolidColorBrush  GetBackground()
                {
                        return _theme.GetBackground();
                }

                public static SolidColorBrush GetAccentColor()
                {
                        return _theme.GetAccentColor();
                }

                public static SolidColorBrush GetValidateColor()
                {
                        return _theme.GetValidateColor();
                }

                public static SolidColorBrush GetHoverColor()
                {
                        return _theme.GetHoverColor();
                }

                public static SolidColorBrush GetPopUpBackground()
                {
                        return _theme.GetPopUpBackground();
                }

                public static SolidColorBrush GetHighlightColor()
                {
                        return _theme.GetHighlightColor();
                }

                public static SolidColorBrush GetButtonColor()
                {
                        return _theme.GetButtonColor();
                }

                public static SolidColorBrush GetButtonContentColor()
                {
                        return _theme.GetButtonContentColor();
                }

                public static SolidColorBrush GetAlertColor()
                {
                        return _theme.GetAlertColor();
                }

                internal static Brush GetContentBackground()
                {
                        return _theme.GetContentBackground();
                }

                internal static Brush GetButtonHoverColor()
                {
                        return _theme.GetButtonHoverColor();
                }
        }//class ThemeSelector
}//ns
