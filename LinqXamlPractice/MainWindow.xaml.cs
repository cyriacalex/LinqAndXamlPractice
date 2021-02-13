using System;
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

        private static IEnumerable<Person> PersonList()
        {
            var personList = new List<Person>();

            personList.Add(new Person() { firstName = "Joseph", lastName = "Stalin", rating = 4, startDate = 1990 });
            personList.Add(new Person() { firstName = "Mark", lastName = "Twain", rating = 4, startDate = 2004 });
            personList.Add(new Person() { firstName = "Elizabeth", lastName = "Twin", rating = 8, startDate = 1560 });
            personList.Add(new Person() { firstName = "Jessica", lastName = "Brown", rating = 2, startDate = 1978 });
            personList.Add(new Person() { firstName = "Gary", lastName = "Dro", rating = 10, startDate = 2010 });
            personList.Add(new Person() { firstName = "Marcus", lastName = "Brutus", rating = 9, startDate = 1900 });
            personList.Add(new Person() { firstName = "Shirley", lastName = "Surely", rating = 2, startDate = 1875 });
            personList.Add(new Person() { firstName = "Kurt", lastName = "Russell", rating = 7, startDate = 2000 });
            personList.Add(new Person() { firstName = "Kurt", lastName = "Bob", rating = 2, startDate = 1941 });
            personList.Add(new Person() { firstName = "Kurt", lastName = "Thomas", rating = 8, startDate = 1980 });

            return personList;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Year1.Text == null || Year2.Text == null)
            {
                MessageBox.Show("Must enter two valid years");
                YearCheckBox.IsChecked = false;
            }
            else if (!int.TryParse(Year1.Text, out int result) || !int.TryParse(Year2.Text, out int result2))
            {
                MessageBox.Show("Must enter two valid years");
                Year1.Clear();
                Year2.Clear();
                YearCheckBox.IsChecked = false;
            }

            else
            {
                IEnumerable<Person> newList = (List<Person>)dataGrid.ItemsSource;
                newList = newList.Where(x => x.startDate >= int.Parse(Year1.Text) && x.startDate <= int.Parse(Year2.Text)).ToList();
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = newList;
                ((CheckBox)sender).IsChecked = false;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SelectedPersonTextBox.Clear();
            IEnumerable<Person> newList = (List<Person>)dataGrid.ItemsSource;
            if (RBFirstName.IsChecked.Value)
                dataGrid.ItemsSource = newList.OrderBy(p => p.firstName).ToList();
            else if (RBLastName.IsChecked.Value)
                dataGrid.ItemsSource = newList.OrderBy(p => p.lastName).ToList();
            else if (RBRating.IsChecked.Value)
                dataGrid.ItemsSource = newList.OrderBy(p => p.rating).ToList();
            else if (RBStartDate.IsChecked.Value)
                dataGrid.ItemsSource = newList.OrderBy(p => p.startDate).ToList();

            //How I did sorting previously
            //newList.Sort((Person x, Person y) => x.startDate.CompareTo(y.startDate));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedPersonTextBox.Clear();
            Year1.Clear();
            Year2.Clear();
            RBFirstName.IsChecked = false;
            RBLastName.IsChecked = false;
            RBRating.IsChecked = false;
            RBStartDate.IsChecked = false;
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = PersonList();
        }

        private void dataGrid_Selected(object sender, SelectionChangedEventArgs e)
        {
            Person selectedPerson = (Person)dataGrid.SelectedItem;
            if (selectedPerson != null)
            {
                SelectedPersonTextBox.Text = $"{selectedPerson.firstName} {selectedPerson.lastName}, rating: {selectedPerson.rating}, start date: {selectedPerson.startDate}";
            }
        }

        private void CBFirstName_Checked(object sender, RoutedEventArgs e)
        {
            if (TBName.Text == "" || TBName.Text == null)
                MessageBox.Show("Enter a valid name");
            else
            {
                IEnumerable<Person> newList = (List<Person>)dataGrid.ItemsSource;
                newList = newList.Where(x => x.firstName == TBName.Text).ToList();
                dataGrid.ItemsSource = newList;
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
