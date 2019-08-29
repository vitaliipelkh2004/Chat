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
    /// Interaction logic for MiniChat.xaml
    /// </summary>
    public partial class MiniChat : Window
    {
        EFContext context = new EFContext();
        int _id;
        public MiniChat(string name)
        {
            
            InitializeComponent();
            miniName.Text = name;
            foreach(var item in context.Users)
            {
                if (name == item.FirstName)
                    _id = item.ID;
            }

            foreach(var item in context.Mi)

        }
    }
}
