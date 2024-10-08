﻿using System.Windows;
using System.Windows.Media;


namespace Homework_12
{
    /// <summary>
    /// Логика взаимодействия для CreateCard.xaml
    /// </summary>
    public partial class CreateCard : Window
    {
        private Client client;
        Account account;
        //public List<string> CardTypes { get; set; } = new List<string> { "Депозитный", "Недепозитный", "Кредитный" };
        //public string SelectedCardType { get; set; }
        public CreateCard(Client client)
        {
            InitializeComponent();
            this.client = client;
            //DataContext = this;
            //SelectedCardType = CardTypes[0];
            Init();

        }

        public void Init()
        {
            //Account accounts = new Account((Account.AccountType)cb_CardType.SelectedIndex);
            account = new Account();
            DataContext = account;
            cb_CardType.SelectedIndex = 2;

            lb_Name.Content = $"{client.FirstName} {client.LastName}";
            lb_Field1.Content = account.ID.Substring(0, 4);
            lb_Field2.Content = account.ID.Substring(4, 4);
            lb_Field3.Content = account.ID.Substring(8, 4);
            lb_Field4.Content = account.ID.Substring(12, 4);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Balance.Text) || !IsNumeric(tb_Balance.Text))
            {
                tb_Balance.BorderBrush = Brushes.Red;
                return;
            }
            account.Balance = decimal.Parse(tb_Balance.Text);
            account.Type = (Account.AccountType)cb_CardType.SelectedIndex;
            client.Accounts.Add(account);            
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool IsNumeric(string input)
        {
            return double.TryParse(input, out _);
        }


    }
}
