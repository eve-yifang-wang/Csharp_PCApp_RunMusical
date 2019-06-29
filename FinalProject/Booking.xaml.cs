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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        TicketManager ticketManager = new TicketManager();
        Account account;

        public Booking(Account account)
        {
            InitializeComponent();
            this.account = account;

            cboTickets.ItemsSource = ticketManager.Show.ToList();
            cboQuantity.ItemsSource = new List<int> { 1, 2, 3, 4, 5 };
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            Show showSelected = cboTickets.SelectedItem as Show;
            int numberOfTickets = Convert.ToInt32(cboQuantity.SelectedItem);

            for(int i = 0; i < numberOfTickets; i++)
            {
                Ticket ticket = new Ticket()
                {
                    TicketID = ticketManager.Ticket.Max(x => x.TicketID) + 1,
                    OwnerID = account.AccountID,
                    ShowID = showSelected.ShowID
                };

                ticketManager.Ticket.Add(ticket);
                ticketManager.SaveChanges();
            }

            MessageBox.Show("Ticket(s) booked successfully!", "Booking", MessageBoxButton.OK);
        }

        private void btnBackAccountInfo_Click(object sender, RoutedEventArgs e)
        {
            ticketManager.SaveChanges();

            this.Hide();
            AccountInfo win = new AccountInfo(account);
            win.ShowDialog();
        }
    }

    partial class Show
    {
        public override string ToString() => $"{Title} - {ShowTime}";
    }
}


