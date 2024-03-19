﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TestUI.Services;

namespace TestUI
{
    public class ElememntList
    {
        public Guid Guid { get; set; }

        public List<string> Fields { get; }

        // Add a property to represent the currently selected field
        public string SelectedField { get; set; }

        public ElememntList()
        {
            Guid = Guid.NewGuid();
            Fields = new List<string>() { "Цикл", "Статус", "ID", "№ дела", "Истец", "Ответчик", "срок 1", "срок 2", "срок 3", "Судья", "Что требуется" };
            // Initialize SelectedField to a default value, e.g., the first field
            SelectedField = Fields[0];
        }
    }




    public partial class MainWindow : Window
    {
        public ObservableCollection<ElememntList> Columns { get; } = new ObservableCollection<ElememntList>();

        public MainWindow()
        {
            InitializeComponent();

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
            // Find the parent StackPanel of the button that was clicked
            var button = (Button)sender;
            var stackPanel = (StackPanel)button.Parent;

            // Find the parent container of the StackPanel
            var parentContainer = stackPanel.Parent;

            stackPanel.Children.Clear();
        }




    }
}
