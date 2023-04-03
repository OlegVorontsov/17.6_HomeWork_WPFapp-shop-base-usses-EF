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
    /// <summary>
    /// Логика взаимодействия для ItemAddWindow.xaml
    /// </summary>
    public partial class ItemAddWindow : Window
    {
        public ItemAddWindow()
        { InitializeComponent(); }

        public ItemAddWindow(ItemsInfo addNew) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                addNew.Email = txtClientEmail.Text;
                addNew.Code = int.Parse(txtItemCode.Text);
                addNew.Title = txtItemTitle.Text;
                this.DialogResult = !false;
            };
        }
    }
}
