using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace TestUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool IsBool = false;

        private void AddItemToStackPanel()
        {
            Random random = new Random();
            int j = random.Next(200);

            ContentControl contentControl = new ContentControl();

            if (IsBool)
            {
                contentControl.ContentTemplate = (DataTemplate)this.FindResource("MyItemTemplate1");

                IsBool = false;
            }
            else
            {
                contentControl.ContentTemplate = (DataTemplate)this.FindResource("MyItemTemplate2");

                IsBool = true;
            }
            contentControl.DataContext = new { }; 
            myStackPanel.Children.Add(contentControl);

            Dispatcher.Invoke(() =>
            {
                ContentPresenter contentPresenter = FindVisualChild<ContentPresenter>(contentControl);
                if (contentPresenter != null)
                {
                    Button deleteButton = contentControl.ContentTemplate.FindName("Delete_Button", contentPresenter) as Button;
                    if (deleteButton != null)
                    {
                        deleteButton.Name = "MyNewButtonName"; 
                    }
                }
            }, DispatcherPriority.Render);

        }

        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }



        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            StackPanel parentStackPanel = FindParent<StackPanel>(button);

            if (parentStackPanel != null)
            {
                ContentControl contentControl = FindParent<ContentControl>(button);

                if (contentControl != null)
                {
                    parentStackPanel.Children.Clear();
                }
            }
        }

        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null) return null;

            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemToStackPanel();
        }
    }
}
