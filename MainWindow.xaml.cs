using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace EBOL
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Meal> meals;

        public MainWindow()
        {
            InitializeComponent();

            meals = new ObservableCollection<Meal>();
            dataGrid.ItemsSource = meals;
        }

        // ADD MEAL
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBreakfast.Text) ||
                string.IsNullOrWhiteSpace(txtLunch.Text) ||
                string.IsNullOrWhiteSpace(txtDinner.Text) ||
                cmbSnacks.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            Meal meal = new Meal
            {
                Breakfast = txtBreakfast.Text,
                Lunch = txtLunch.Text,
                Dinner = txtDinner.Text,
                Snacks = (cmbSnacks.SelectedItem as ComboBoxItem).Content.ToString()
            };

            meals.Add(meal);

            // Clear inputs
            txtBreakfast.Clear();
            txtLunch.Clear();
            txtDinner.Clear();
            cmbSnacks.SelectedIndex = -1;
        }

        // ENABLE DELETE BUTTON
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = dataGrid.SelectedItem != null;
        }

        // DELETE MEAL
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Meal selectedMeal)
            {
                meals.Remove(selectedMeal);
            }
        }
    }

    // MODEL CLASS
    public class Meal
    {
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        public string Snacks { get; set; }
    }
}