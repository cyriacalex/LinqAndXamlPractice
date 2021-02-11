﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinqXamlPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = PersonList(); 
        }

        private IEnumerable PersonList()
        {
            var personList = new List<Person>();

            personList.Add(new Person() { firstName = "Joseph", lastName = "Stalin", rating = 4, startDate = 1990 });
            personList.Add(new Person() { firstName = "Mark", lastName = "Twain", rating = 4, startDate = 2004 });
            personList.Add(new Person() { firstName = "Elizabeth", lastName = "Twin",rating = 8, startDate = 1560 });
            personList.Add(new Person() { firstName = "Jessica", lastName = "Brown", rating = 2, startDate = 1978 });
            personList.Add(new Person() { firstName = "Gary", lastName = "Dro", rating = 10, startDate = 2010 });
            personList.Add(new Person() { firstName = "Marcus", lastName = "Brutus", rating = 9, startDate = 1900 });
            personList.Add(new Person() { firstName = "Shirley", lastName = "Surely", rating = 2, startDate = 1875 });
            personList.Add(new Person() { firstName = "Kurt", lastName = "Russell", rating = 7, startDate = 2000 });

            return personList;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Year1.Text == null || Year2.Text == null)
            {
                MessageBox.Show("Must enter two valid years");
                    YearCheckBox.IsChecked = false; 
            }
            if (!int.TryParse(Year1.Text, out int result) || !int.TryParse(Year2.Text, out int result2))
            {
                MessageBox.Show("Must enter two valid years");
                Year1.Clear();
                Year2.Clear();
            YearCheckBox.IsChecked = false;
            }
            
        }
    }
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int rating { get; set; }
        public int startDate { get; set; }
    }

}