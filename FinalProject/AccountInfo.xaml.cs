using System;
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
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for AccountInfo.xaml
    /// </summary>
    public partial class AccountInfo : Window
    {
        TicketManager ticketManager = new TicketManager();
        Account account;
        ObservableCollection<Ticket> tickets;


        public AccountInfo(Account account)
        {
            InitializeComponent();
            this.account = account;
            initializeAccountInfo();
        }

        private void dgrdTickets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Ticket ticketToBeCanceled = dgrdTickets.SelectedItem as Ticket;

            if (MessageBox.Show($"Are you sure you want to Cancel the ticket : {ticketToBeCanceled} ?\nNo refund is available.", "Ticket Cancellation Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                //for Yes
                ticketManager.Ticket.Remove(ticketToBeCanceled);
                ticketManager.SaveChanges();
                updateTicketsDataGrid();
            }
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Booking win = new Booking(account);
            win.ShowDialog();
        }

        private void btnModifyInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChangeInfo win = new ChangeInfo(account);
            win.ShowDialog();
        }

        private void initializeAccountInfo()
        {
            lblName.Content = account.Name.ToString();
            lblPhone.Content = account.Phone.ToString();
            txtAddress.Text = account.BillingAddress.ToString();

            //data grid
            updateTicketsDataGrid();
        }

        private void updateTicketsDataGrid()
        {
            dgrdTickets.ItemsSource = null;
            tickets = new ObservableCollection<Ticket>
                (ticketManager.Ticket.Where
                (x => x.OwnerID == account.AccountID).ToList());

            dgrdTickets.ItemsSource = tickets;
        }


    }

    partial class Ticket
    {
        public override string ToString() => $"{Show.Title} - {Show.ShowTime} - {TicketID}";
    }
}
