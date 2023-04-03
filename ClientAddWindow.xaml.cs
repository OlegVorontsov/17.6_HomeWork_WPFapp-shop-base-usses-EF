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

namespace _17._6_HomeWork_WPFapp_shop_base_usses_EF
{
    public partial class ClientAddWindow : Window
    {
        public ClientAddWindow()
        { InitializeComponent(); }
        public ClientAddWindow(ClientsInfo addNew) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                addNew.surname = txtClientSurname.Text;
                addNew.name = txtClientName.Text;
                addNew.patronymic = txtClientPatr.Text;
                addNew.phonenumber = double.Parse(txtClientPhone.Text);
                addNew.email = txtClientEmail.Text;
                this.DialogResult = !false;
            };
        }
    }
}
