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
using System.Windows.Threading;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MiniChat.xaml
    /// </summary>
    public partial class MiniChat : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        EFContext context = new EFContext();
        UserVid userVid;
        UserReceiver userReceiver; 
        int _id;
        int _VidID;
        int MiniChatID;
        public MiniChat(string name,int VidID)
        {
           
            InitializeComponent();
            _VidID = VidID;
            miniName.Text = name;
            foreach(var item in context.Users)
            {
                if (name == item.FirstName)
                    _id = item.ID;
            }
           foreach(var item in context.MiniChats)
            {
                item.ID = MiniChatID;
            }

            foreach(var item in context.userVids)
            {
                item.UserV_ID = _VidID;
                item.MiniChat_ID = MiniChatID;
                context.SaveChanges();
            }

            foreach (var item in context.userReceivers)
            {
                item.UserR_ID = _id;
                item.MiniChat_ID = MiniChatID;
                context.SaveChanges();
            }

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var item in context.MiniChats)
            {
                minilistbox.Items.Add($"{item.UserVidof.ToList()[0].Userof.FirstName}: {item.Text}");
            }
        }

        private void Minienter_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in context.MiniChats)
            {
                item.Text = minitext.Text;
                context.SaveChanges();
            }





        }
    }
}
