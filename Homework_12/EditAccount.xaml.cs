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

namespace Homework_12
{
    /// <summary>
    /// Логика взаимодействия для EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        private Client client;
        private Repository repository;
        public EditAccount(Client client, Repository repository)
        {
            InitializeComponent();
            this.client = client;

            tb_LastName.Text = client.LastName;
            tb_FirstName.Text = client.FirstName;
            tb_Patronymic.Text = client.Patronymic;
            this.client = client;
            this.repository = repository;
            DataContext = client;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            client.FirstName = tb_FirstName.Text;
            client.LastName = tb_LastName.Text;
            client.Patronymic = tb_Patronymic.Text;
            repository.SaveJson();
            this.Close();
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateCard createCard = new CreateCard(client);
            createCard.Show();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            TransferMoney transferMoney = new TransferMoney(client, repository);
            transferMoney.Show();
        }
        private void DelAccount_Click(object sender, RoutedEventArgs e)
        {
            client.Accounts.RemoveAt(lv_ClientInfo.SelectedIndex);
        }
    }
}
