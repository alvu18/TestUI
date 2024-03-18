using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace TestUI.Services
{
    internal class UIHelper
    {
        public static IEnumerable<T> FindChildren<T>(DependencyObject parent) where T : DependencyObject
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

                    foreach (var grandChild in FindChildren<T>(child))
                    {
                        yield return grandChild;
                    }
                }
            }
        }
    }
}
