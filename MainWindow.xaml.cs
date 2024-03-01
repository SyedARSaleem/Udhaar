using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Sprint3
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

        private void BtnLstItems_Click(object sender, RoutedEventArgs e)
        {
            //BtnLstItems.IsEnabled = false;
            ListItems.Items.Clear();


            // Adding items to list of items
            Store Library = Store.Instance();
            Electronics E1 = new Electronics("Projector", "1920 x 1080 Screen Resolution", 10);
            Library.AddItem(E1);
            SportsOutdoors SO1 = new SportsOutdoors("Camping Tent", "Light weight, two men space", 12);
            Library.AddItem(SO1);
            Household H1 = new Household("Sewing Machine", "Brother Electronic Sewing Machine", 13);
            Library.AddItem(H1);
            SportsOutdoors SO2 = new SportsOutdoors("Tennis Rackets", "Pair of Rackets", 4);
            Library.AddItem(SO2);
            Electronics E2 = new Electronics("Speakers", "150 Hz", 6);
            Library.AddItem(E2);


            var uniqueItems = Library.GetItemList().GroupBy(item => item.getname()).Select(group => group.First());

            // Add unique items to the ListBox
            foreach (ItemBase product in uniqueItems)
            {
                if (product.getavailability() is Available)
                {
                    ListItems.Items.Add(new { displayvalue = product.getname(), value = product.PrintDetails() });
                }
            }    
            ListItems.SelectedValue = "value";
            ListItems.DisplayMemberPath = "displayvalue";

        }
        
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            
            if (ListItems.SelectedItem == null)
            {
                MessageBox.Show(" Please Select an item before clicking on the Select button");
            }
            else
            {
                var selection = ListItems.SelectedItem as dynamic;
                LblItemName.Content = selection.displayvalue;
                LblDesc.Content = selection.value;
                TxtDays.Visibility = Visibility.Visible;
                TxtRent.Visibility = Visibility.Visible;
                TxtAmount.Visibility = Visibility.Visible;

            }
            
        }

        private void BtnBook_Click(object sender, RoutedEventArgs e)
        {
            
            if (ListItems.SelectedItem == null)
            {
                MessageBox.Show("Please Select an item you want to book first");
            }
            else if (TxtDays.Text.Length == 0)
            {
                MessageBox.Show("Please Enter the Days you want to Book the Item");
            }
            else
            {
                var selection = ListItems.SelectedItem as dynamic;
                
                Store Library = Store.Instance();
                ItemBase item = Library.GetItem(selection.displayvalue);
                item.book();
                
                MessageBox.Show("Thank you for using MyRent............" + selection.displayvalue + " booked successfully for " + TxtDays.Text + " days");

                LblItemName.Content = "Item Description";
                LblDesc.Content = null;
                ListItems.Items.Clear();
                TxtDays.Visibility = Visibility.Hidden;
                TxtRent.Visibility = Visibility.Hidden;
                TxtAmount.Visibility = Visibility.Hidden;

            }
            
        }

        private void TxtDays_TextChanged(object sender, TextChangedEventArgs e)
        {

            int input = 0;
            if (TxtDays.Text.Length == 0)
            {
                input = 0;
            }
            else
            {
                input = Convert.ToInt32(TxtDays.Text);
            }

            if (ListItems.SelectedItem == null)
            {
                MessageBox.Show("Please Select an item you want to book first");
                TxtDays.Clear();
                
            }
            else if (input > 0)
            {
                var selection = ListItems.SelectedItem as dynamic;
                
                Store Library = Store.Instance();
                ItemBase item = Library.GetItem(selection.displayvalue);
                int amount = item.getprice();
                TxtAmount.Text = string.Format("Total Amount for Renting = {0}", (amount*input)) ;
            }
            else
            {
                TxtAmount.Text = "Enter a valid number";
                TxtDays.Clear();
            }
        }

        private void NumberValidation_TxtDays(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
