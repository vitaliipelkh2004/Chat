using Chat.Entities;
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

namespace Chat
{
    /// <summary>
    /// Interaction logic for SomeWindow.xaml
    /// </summary>
    public partial class SomeWindow : Window
    {
        EFContext context = new EFContext();
        int id;
        public SomeWindow()
        {
            InitializeComponent();
            
            foreach (var item in context.Users)
            {
                listUsers.Items.Add($"{item.FirstName} {item.LastName}");
             
            }

            foreach(var item in context.Messesages)
            {
                listbox.Items.Add(item.Text);
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Messesage messesage = new Messesage() {
                Text = text.Text,
            User_ID=id
            };

            context.Messesages.Add(messesage);
        }
    }
}
