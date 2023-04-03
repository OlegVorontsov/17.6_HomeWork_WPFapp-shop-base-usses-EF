using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace _17._6_HomeWork_WPFapp_shop_base_usses_EF
{
    public partial class MainWindow : Window
    {
        ClientsDBEntities context;
        static string emailSelected;

        bool clientDeleting = false;

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        //загрузка списка клиентов
        private void Init()
        {
            context = new ClientsDBEntities();

            context.ClientsInfo.Load();
            clientsGridView.ItemsSource = context.ClientsInfo.Local.ToBindingList<ClientsInfo>();
        }
        //выбор клиента
        private void clientsGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!clientDeleting)
            {
                ClientsInfo clientSelected = (ClientsInfo)clientsGridView.SelectedItem;
                emailSelected = clientSelected.email;
                ViewItems();
            }
        }
        //загрузка списка товаров
        private void ViewItems()
        {
            context.ItemsInfo.Load();
            itemsGridView.ItemsSource = context.ItemsInfo.Local.Where(e => e.Email == emailSelected);
        }
        //добавление клиента через контекстное меню
        private void MenuItemAddClientClick(object sender, RoutedEventArgs e)
        {
            ClientsInfo add = new ClientsInfo();
            ClientAddWindow addWind = new ClientAddWindow(add);
            addWind.ShowDialog();
            if (addWind.DialogResult.Value)
            {
                context.ClientsInfo.Add(add);
                context.SaveChanges();
            }
        }
        //удаление клиента через контекстное меню
        private void MenuItemDeleteClientClick(object sender, RoutedEventArgs e)
        {
            ClientsInfo clientSelected = (ClientsInfo)clientsGridView.SelectedItem;
            clientDeleting = true;
            context.ClientsInfo.Remove(clientSelected);
            context.SaveChanges();
            clientDeleting = false;
        }
        //добавление товара через контекстное меню
        private void MenuItemAddItemClick(object sender, RoutedEventArgs e)
        {
            ItemsInfo add = new ItemsInfo();
            ItemAddWindow addWind = new ItemAddWindow(add);
            addWind.ShowDialog();
            if (addWind.DialogResult.Value)
            {
                context.ItemsInfo.Add(add);
                context.SaveChanges();
            }
        }
        //удаление товара через контекстное меню
        private void MenuItemDeleteItemClick(object sender, RoutedEventArgs e)
        {
            ItemsInfo itemSelected = (ItemsInfo)itemsGridView.SelectedItem;
            context.ItemsInfo.Remove(itemSelected);
            context.SaveChanges();
        }
    }
}
