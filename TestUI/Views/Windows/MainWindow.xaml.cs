using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using TestUI.Services;

namespace TestUI
{
    public class ElememntList
    {
        public Guid Guid { get; set; }

        public List<string> Fields { get; }

        public string SelectedField { get; set; }

        public ElememntList()
        {
            Guid = Guid.NewGuid();

            Fields = new List<string>() { "Цикл", "Статус", "ID", "№ дела", "Истец", "Ответчик", "срок 1", "срок 2", "срок 3", "Судья", "Что требуется" };

            SelectedField = Fields[0];
        }
    }

    public static class ListExtensions
    {
        public static void Swap(this ObservableCollection<ElememntList> list, ElememntList element1, ElememntList element2)
        {
            int index1 = list.IndexOf(element1);

            ElememntList element = list.FirstOrDefault(x=> x.Guid == element2.Guid);

            int index2 = list.IndexOf(element);

            if (index1 < 0 || index2 < 0)
            {
                throw new ArgumentException("Один или оба элемента не найдены в списке.");
            }

            ElememntList temp = list[index1];

            list[index1] = list[index2];

            list[index2] = temp;
        }
    }

    public partial class MainWindow : Window
    {
        public ListViewItem swapItem = new ListViewItem();

        public ObservableCollection<ElememntList> Columns { get; } = new ObservableCollection<ElememntList>();

        public MainWindow()
        {
            InitializeComponent();

            ElememntList elememntList = new ElememntList();

            Columns.Add(elememntList);

            DesignerListBox.ItemsSource = Columns;

            this.DataContext = this;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ElememntList elememnt = new();

            Columns.Add(elememnt);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            IEnumerable<ComboBox> comboBoxes = UIHelper.FindChildrenTree<ComboBox>(testtest);

            List<string> strings = UIHelper.GetSelectedStringsFromComboBoxes(comboBoxes);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject originalSource = e.OriginalSource as DependencyObject;

            ListViewItem clickedItem = UIHelper.FindVisualParent<ListViewItem>(originalSource);

            var element = clickedItem.Content as ElememntList;

            if (element != null)
            {
                Columns.Remove(element);
            }
        }

        private void UIelement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject originalSource = e.OriginalSource as DependencyObject;

            swapItem = UIHelper.FindVisualParent<ListViewItem>(originalSource);
        }

        private void UIelement_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject originalSource = e.OriginalSource as DependencyObject;

            ListViewItem MouseUpItem = UIHelper.FindVisualParent<ListViewItem>(originalSource) ;

            var element1 = MouseUpItem.Content as ElememntList;

            var element2 = swapItem.Content as ElememntList;

            if (MouseUpItem != null)
            {
                ListExtensions.Swap(Columns, element1, element2);
            }
        }
    }
}
