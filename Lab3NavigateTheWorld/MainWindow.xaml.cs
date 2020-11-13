/* NAME: Nirmal Patel (100767993)
 * Lab 3 | Communication Activity 3
 * Date: Nov 13 2020
 */

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using System.Data.SqlClient;
using System.Data;

namespace Lab3NavigateTheWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creates new list
        List<share> list = new List<share>();

        /// <summary>
        /// Logic of the MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            lsShares.ItemsSource = list;
        }

        /// <summary>
        /// Handles button click event of btnCreateEntry button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateEntry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //VALIDATIONS
                //Checks to see if user has left textbox's empty
                if (txtBuyerName.Text == string.Empty || txtNumOfShares.Text == string.Empty || dpDatePurchased.SelectedDate == null)
                {
                    MessageBox.Show("Must fill in all textfields");

                    // Reset all fields
                    txtBuyerName.Text = string.Empty;
                    txtNumOfShares.Text = string.Empty;
                    dpDatePurchased.SelectedDate = null;
                    rbCommon.IsChecked = false;
                    rbPreferred.IsChecked = false;
                }
                else if (rbCommon.IsChecked == false && rbPreferred.IsChecked == false)
                {
                    MessageBox.Show("Share type has to be selected");

                    rbCommon.IsChecked = false;
                    rbPreferred.IsChecked = false;
                }
                else
                {
                    //grabbing values from form, No Validation here(add it)
                    string name = txtBuyerName.Text;
                    int numShare = int.Parse(txtNumOfShares.Text);
                    string date = dpDatePurchased.SelectedDate.ToString();

                    string share = "";

                    // if common button is checked
                    if(rbCommon.IsChecked == true)
                    {
                        share = "common";
                    }
                    // else preferred button is checked
                    else
                    {
                        share = "preferred";
                    }

                    //connectString form settings
                    string connectString = Properties.Settings.Default.connect_string;

                    SqlConnection cn = new SqlConnection(connectString);

                    cn.Open();

                    string insertQuery = "INSERT INTO buyers (buyerName, numShares, datePurchased, shareType) VALUES ('" + name + "', '" + numShare + "', '" + date + "', '" + share + "')";

                    SqlCommand command = new SqlCommand(insertQuery, cn);

                    command.ExecuteNonQuery();

                    string selectionQuery = "";

                    // if share selected is common
                    if (share == "common")
                    {
                        selectionQuery = "SELECT common FROM shares";
                    }

                    // else share selected is common
                    else
                    {
                        selectionQuery = "SELECT preferred FROM shares";
                    }

                    SqlCommand secondCommand = new SqlCommand(selectionQuery, cn);

                    int availableShares = Convert.ToInt32(secondCommand.ExecuteNonQuery());

                    availableShares = availableShares - numShare;

                    // if available share is less than 0
                    if (availableShares < 0)
                    {
                        MessageBox.Show("Sorry, we don't have that much shares available");
                    }

                    // else available share is greater than 0
                    else
                    {
                        string updateQuery = "";

                        // if share seleceted is common
                        if (share == "common")
                        {
                            CommonShare commonShare = new CommonShare(txtBuyerName.Text, dpDatePurchased.Text, availableShares, share);
                            list.Add(commonShare);

                            updateQuery = "UPDATE shares SET common =  '" + availableShares + "' ";
                            SqlCommand thirdCommand = new SqlCommand(updateQuery, cn);
                            thirdCommand.ExecuteScalar();
                        }

                        // else share selected is preferred
                        else
                        {
                            PreferredShare commonShare = new PreferredShare(txtBuyerName.Text, dpDatePurchased.Text, availableShares, share);
                            list.Add(commonShare);

                            updateQuery = "UPDATE shares SET preferred =  '" + availableShares + "' ";
                            SqlCommand thirdCommand = new SqlCommand(updateQuery, cn);
                            thirdCommand.ExecuteScalar();
                        }

                        MessageBox.Show("Successfully added share purchase");

                        txtBuyerName.Text = string.Empty;
                        txtNumOfShares.Text = string.Empty;
                        dpDatePurchased.SelectedDate = null;

                        cn.Close();
                        lsShares.Items.Refresh();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
        private void FillDataGrid()
        {
            try
            {
                string connectString = Properties.Settings.Default.connect_string;

                SqlConnection cn = new SqlConnection(connectString);

                cn.Open();

                string selectQuery = "SELECT * FROM buyers";

                SqlCommand commandQuery = new SqlCommand(selectQuery, cn);

                SqlDataAdapter sda = new SqlDataAdapter(commandQuery);

                DataTable dt = new DataTable("Buyers");

                sda.Fill(dt);

                viewEntriesGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// Handles Tab Control Selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;

            switch (tabItem)
            {
                case "View Summary":

                    try
                    {
                        string connectString = Properties.Settings.Default.connect_string;

                        SqlConnection cn = new SqlConnection(connectString);

                        cn.Open();

                        string retrieveSharesSoldQuery = "SELECT SUM(numShares) FROM buyers";

                        SqlCommand fourthCommand = new SqlCommand(retrieveSharesSoldQuery, cn);

                        int soldShares = Convert.ToInt32(fourthCommand.ExecuteScalar());

                        txtCommonSharesAvailable.Text = soldShares.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                break;

                case "View Entries":

                    FillDataGrid();

                break;
            }
        }
    }
}
