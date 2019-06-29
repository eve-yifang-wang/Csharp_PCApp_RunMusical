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
    /// Interaction logic for ChangeInfo.xaml
    /// </summary>
    public partial class ChangeInfo : Window
    {
        TicketManager ticketManager = new TicketManager();
        Account account;
        int oldPhone;

        //modify info
        public ChangeInfo(Account account)
        {
            InitializeComponent();
            this.account = account;
            initAccountInfo();
        }

        //create account
        public ChangeInfo(string email, string password)
        {
            InitializeComponent();

            account = new Account()
            {
                AccountID = ticketManager.Account.Max(x => x.AccountID) + 1,
                Email = email,
                Password = password
            };

            ticketManager.Account.Add(account);
            ticketManager.SaveChanges();


        }

        private void btnSaveInfo_Click(object sender, RoutedEventArgs e)
        {
            int phone;

            if (!isAllFieldFilled())
                MessageBox.Show("Please fill up all information. Thanks!", "Error", MessageBoxButton.OK);

            phone = Convert.ToInt32(txtPhone.Text);
            if(oldPhone != phone && !isPhoneUnique(phone))
                MessageBox.Show("This phone number has been registered. Please try another one.", "Error", MessageBoxButton.OK);

            ticketManager.Account.First(x => x.AccountID == account.AccountID).Name =  txtName.Text.ToString();
            ticketManager.Account.First(x => x.AccountID == account.AccountID).BillingAddress = txtAddress.Text.ToString();
            ticketManager.Account.First(x => x.AccountID == account.AccountID).Phone = phone;

            ticketManager.SaveChanges();
            if (MessageBox.Show("Information has been saved. Back to Account Information?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Hide();
                AccountInfo win = new AccountInfo(account);
                win.Show();
            }
        }

        private Boolean isPhoneUnique(int phone)
        {
            foreach(Account a in ticketManager.Account)
            {
                if (phone == Convert.ToInt32(a.Phone))
                    return false;
            }
            return true;
        }

        private Boolean isAllFieldFilled()
        {
            if (txtAddress.Text.ToString() == "" || txtName.Text.ToString() == "" || txtPhone.Text.ToString() == "")
                return false;
            else
                return true;
        }

        private void initAccountInfo()
        {
            txtName.Text = account.Name.ToString();
            txtPhone.Text = account.Phone.ToString();
            txtAddress.Text = account.BillingAddress.ToString();

            if(txtPhone.Text != "")
            {
                oldPhone = Convert.ToInt32(txtPhone.Text);
            }
        }
    }
}
