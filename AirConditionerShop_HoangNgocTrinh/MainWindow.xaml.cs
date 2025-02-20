using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AirConditionerShop.BLL.Services;
using AirConditionerShop.DAL.Entities;
using Microsoft.IdentityModel.Tokens;

namespace AirConditionerShop_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AirConService _service = new AirConService();
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow d = new DetailWindow();
            d.ShowDialog();
            FillDataGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            AirConsDataGrid.ItemsSource = null; //remove grid
            AirConsDataGrid.ItemsSource = _service.GetAllAircons();

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            AirConditioner? selected = AirConsDataGrid.SelectedItem as AirConditioner;
            if (selected == null) { 
                //if user click edit without choosing row, show warning
                MessageBox.Show("Please select a row/ an aircon before editing","Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            DetailWindow d = new DetailWindow();
            d.EditedAirCon = selected;
            d.ShowDialog();
            FillDataGrid();
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AirConditioner? selected = AirConsDataGrid.SelectedItem as AirConditioner;
            if (selected == null)
            {
                //if user click edit without choosing row, show warning
                MessageBox.Show("You have to select a row before deleting", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            MessageBoxResult answer = MessageBox.Show("Do you really want to delete?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No) {
                return;
            }
            //call from Services AirCon
            _service.DeleteAircon(selected);

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //show warning if enter string instead of int (Quantity)
            int? quantity = null;
            int tmpQuantity;
            bool quantityStatus = int.TryParse(QuantityTextBox.Text, out tmpQuantity);
            if (!quantityStatus && !QuantityTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Incorrect Datatype, please use Integer for quantity!", "Error",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else if (quantityStatus == true) 
            {
                quantity = tmpQuantity; //If false, quantity is null
            }
            var result = _service.SearchByFeatureAndQuantity(FeatureFunctionTextBox.Text,quantity);
            AirConsDataGrid.ItemsSource = null; //remove grid
            AirConsDataGrid.ItemsSource = result;


        }
    }
}