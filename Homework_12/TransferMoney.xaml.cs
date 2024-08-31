using System;
using System.Security.Policy;
using System.Windows;
using System.Windows.Media;


namespace Homework_12
{
    /// <summary>
    /// Логика взаимодействия для TransferMoney.xaml
    /// </summary>
    public partial class TransferMoney : Window
    {
        Client client;
        Repository repository;
        public TransferMoney(Client client, Repository repository)
        {
            InitializeComponent();
            this.client = client;
            this.repository = repository;
            DataContext = client;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_money.Text) || !IsNumeric(tb_money.Text))
            {
                tb_money.BorderBrush = Brushes.Red;
                return;
            }
            if (string.IsNullOrEmpty(tb_Recipient.Text) || !IsNumeric(tb_Recipient.Text))
            {
                tb_Recipient.BorderBrush = Brushes.Red;
                return;
            }
            decimal money = decimal.Parse(tb_money.Text);

            bool isOk = false;
            Account accountSender = null;
            foreach (var tempClient in repository.Clients)
            {
                accountSender = tempClient.GetAccount(cb_Sender.Text);
                if (accountSender != null) { isOk = true; break; }
            }
            isOk = false;
            Account accountRecipient = null;
            foreach (var tempClient in repository.Clients)
            {
                accountRecipient = tempClient.GetAccount(tb_Recipient.Text);
                if (accountRecipient != null) { isOk = true; break; }
            }
            if (!isOk)
            {
                tb_Recipient.BorderBrush = Brushes.Red;
                return;
            }
            if (money > accountSender.Balance)
            {
                tb_money.BorderBrush = Brushes.Red;
                return;
            }
            accountSender.Balance -= money;
            accountRecipient.Balance += money;
            this.Close();



        }

        private bool IsNumeric(string input)
        {
            return double.TryParse(input, out _);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
