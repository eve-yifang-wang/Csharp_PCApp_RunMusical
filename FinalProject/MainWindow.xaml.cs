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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TicketManager ticketManager = new TicketManager();
        Account accountToBeMatched;
        string email;
        string password;
        List<string> emailsExisted = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            
            //initialize emails in database
            foreach (Account a in ticketManager.Account)
            {
                emailsExisted.Add(a.ToString());
            }
        }

        //Logging in with exist account
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            getEmailAndPassword();

            if (email == "" || password == "")
                errorMessage();
            else
            {
                if (checkAccountExistance())
                {
                    if (accountToBeMatched.Password == password)
                    {
                        this.Hide();
                        AccountInfo win = new AccountInfo(accountToBeMatched);
                        win.ShowDialog();
                    }
                }
                else
                    errorMessage();
            }
        }

        //Signing up for a new account
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            getEmailAndPassword();

            if (email == "" || password == "")
                errorMessage();
            else
            {
                //check if account exist already
                if(!checkAccountExistance())
                {
                    this.Hide();
                    ChangeInfo win = new ChangeInfo(txtEmail.Text, txtPassword.Password);
                    win.Show();
                }
                else
                    MessageBox.Show("Account already exist. Try log in?", "Error", MessageBoxButton.OK);
            }
        }

        private void errorMessage()
        {
            txtPassword.Clear();
            MessageBox.Show("Email or Password invalid. Please try again.", "Error", MessageBoxButton.OK);
        }

        private Boolean checkAccountExistance()
        {
            if (emailsExisted.Contains(email))
            {
                accountToBeMatched = ticketManager.Account.FirstOrDefault(x => x.Email == email);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void getEmailAndPassword()
        {
            email = txtEmail.Text.ToLower().ToString();
            password = txtPassword.Password.ToString();
        }
    }

    partial class Account
    {
        public override string ToString() => $"{Email}";

    }
}
