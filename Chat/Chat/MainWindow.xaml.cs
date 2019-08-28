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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        EFContext context = new EFContext();
        User user;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user = new User()
            {
                FirstName=firstN.Text,
                LastName=lastN.Text
            };
            
            context.Users.Add(user);
            context.SaveChanges();

                       


            SomeWindow window = new SomeWindow(user.ID);
            this.Close();
            window.ShowDialog();
            context.Users.Remove(user);
            context.SaveChanges();
          
        }
    }
}
