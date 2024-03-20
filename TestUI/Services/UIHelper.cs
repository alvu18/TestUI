using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestUI.Services
{
    internal static class UIHelper
    {
        public static IEnumerable<T> FindChildrenTree<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);

                    if (child != null && child is T tChild)
                    {
                        yield return tChild;
                    }

                    foreach (var grandChild in FindChildrenTree<T>(child))
                    {
                        yield return grandChild;
                    }
                }
            }
        }


        public static T FindVisualParent<T>(DependencyObject obj) where T : DependencyObject
        {
            while (obj != null)
            {
                if (obj is T parent)
                {
                    return parent;
                }
                obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }

        public static List<string> GetSelectedStringsFromComboBoxes(IEnumerable<ComboBox> comboBoxes)
        {
            var selectedStrings = new List<string>();

            foreach (var comboBox in comboBoxes)
            {
                if (comboBox.SelectedItem != null)
                {
                    selectedStrings.Add(comboBox.SelectedItem.ToString());
                }
                else
                {
                    selectedStrings.Add("");
                }
            }

            return selectedStrings;
        }
    }
}
