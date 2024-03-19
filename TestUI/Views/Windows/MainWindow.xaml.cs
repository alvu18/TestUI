using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TestUI.Services;

namespace TestUI
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Columns { get; } = new ObservableCollection<string>
            {
                "sss", "ddd", "dddddsffs"
            };


        public MainWindow()
        {
            InitializeComponent();

            DesignerListBox.ItemsSource = Columns;
            
    /*        a1.ItemsSource = Columns;
            a2.ItemsSource = Columns;
            a3.ItemsSource = Columns;
            a4.ItemsSource = Columns;*/

            this.DataContext = this;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string k = "dddddddddd";

            Columns.Add(k);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            IEnumerable<ComboBox> comboBoxes = UIHelper.FindChildrenTree<ComboBox>(testtest);

            List<string> strings  = UIHelper.GetSelectedStringsFromComboBoxes(comboBoxes);
        }


    }
}
