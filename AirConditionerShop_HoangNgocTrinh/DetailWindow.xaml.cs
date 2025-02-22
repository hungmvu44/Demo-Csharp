using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using AirConditionerShop.BLL.Services;
using AirConditionerShop.DAL.Entities;
using Microsoft.IdentityModel.Tokens;

namespace AirConditionerShop_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private AirConService _Airconservice = new AirConService();
        private SupplierService _supplierserivce = new SupplierService();

        public AirConditioner EditedAirCon { get; set; } = null;
        //Flag variable to check Detail Window whether it is "New Addition" or "Edit"
        public DetailWindow()
        {
            InitializeComponent();
        }
        
        private bool ValidateElement()
        {
             //flag, sai o nao do, false
            if (AirConditionerIdTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The air con name is required","Field require",MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateElement()) {
                return;
            }
            AirConditioner x = new AirConditioner();
            x.AirConditionerId = int.Parse(AirConditionerIdTextBox.Text);
            x.AirConditionerName = AirConditionerNameTextBox.Text;
            x.Warranty = WarrantyTextBox.Text;
            x.SoundPressureLevel = SoundPressureLevelTextBox.Text;
            x.FeatureFunction = FeatureFunctionTextBox.Text;
            x.Quantity = int.Parse(QuantityTextBox.Text);
            x.DollarPrice = float.Parse(DollarPriceTextBox.Text);
            x.SupplierId = SupplierIdComboBox.SelectedValue.ToString();

            //check Detail Window whether it is "New Addition" or "Edit"
            if (EditedAirCon == null)
            {

                _Airconservice.AddAircon(x);
                
            } else
            {
                _Airconservice.UpdateAircon(x);
            }
            
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillElements(EditedAirCon);
            if (EditedAirCon != null) {
                DetailWindowMode.Content = "Update Air Con";
            } else
                DetailWindowMode.Content = "Create Air Con";

        }

        private void FillElements(AirConditioner x)
        {
            if (x == null)
            {
                return;
            }
            AirConditionerIdTextBox.Text = x.AirConditionerId.ToString();
            AirConditionerIdTextBox.IsEnabled = false;
            AirConditionerNameTextBox.Text = x.AirConditionerName;
            WarrantyTextBox.Text = x.Warranty;
            SoundPressureLevelTextBox.Text = x.SoundPressureLevel;
            FeatureFunctionTextBox.Text = x.FeatureFunction;
            QuantityTextBox.Text = x.Quantity.ToString();
            DollarPriceTextBox.Text = x.DollarPrice.ToString();
            SupplierIdComboBox.SelectedValue = x.SupplierId;
        }

        //helper
        private void FillComboBox()
        {
            SupplierIdComboBox.ItemsSource = _supplierserivce.GetAllSuppliers();
            SupplierIdComboBox.DisplayMemberPath = "SupplierName";
            SupplierIdComboBox.SelectedValuePath = "SupplierId";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //if (EditedAirCon != null)
            //    MessageBox.Show("Do you want to save this?", "Attention!", MessageBoxButton.YesNo, MessageBoxImage.Question );
                
            //else
                this.Close();
            
        }
    }
}
