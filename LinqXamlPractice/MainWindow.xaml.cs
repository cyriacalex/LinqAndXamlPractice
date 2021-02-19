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
            dataGrid.ItemsSource = Person.PersonList();
        }      
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Year1.Text, out int result) || !int.TryParse(Year2.Text, out int result2))
            {
                MessageBox.Show("Enter two valid years");
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
            dataGrid.ItemsSource = Person.PersonList();
        }

        private void dataGrid_Selected(object sender, SelectionChangedEventArgs e)
        {
            Person person1 = new Person();
            IEnumerable<Person> newList = (List<Person>)dataGrid.ItemsSource;
            person1 = newList.SingleOrDefault(p => dataGrid.SelectedItem == p);
            if (person1 != null)
                SelectedPersonTextBox.Text = $"{person1.firstName} {person1.lastName}, rating: {person1.rating}, start date: {person1.startDate}";

            /* How I did this before, Updating to practice with LINQ
            Person selectedPerson = (Person)dataGrid.SelectedItem;
            if (selectedPerson != null)
            {
                SelectedPersonTextBox.Text = $"{selectedPerson.firstName} {selectedPerson.lastName}, rating: {selectedPerson.rating}, start date: {selectedPerson.startDate}";
            }*/

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
               
        }
    }
    

}
