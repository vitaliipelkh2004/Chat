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
        Minichat Minichat;
        UserVid userVid;
        UserReceiver userReceiver;
        int _id;
        int _VidID;
        public MiniChat(string name, int VidID)
        {

            InitializeComponent();
            _VidID = VidID;
            miniName.Text = name;
            foreach (var item in context.Users)
            {
                if (name == item.FirstName)
                    _id = item.ID;
            }

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
           

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            minilistbox.Items.Clear();

            foreach (var item in context.Minichats
                .Where(t => 
                    t.UserVidof
                    .Where(f => f.UserV_ID == _VidID)
                    .Count() != 0
                    ||
                    t.UserVidof
                    .Where(f=>f.UserV_ID==_id)
                    .Count()!=0
                    )
                .ToList())
            {
                  if(userVid?.Userof!=null)
                minilistbox.Items.Add($"{item.Text}");
                  else if(userReceiver?.Userof!=null)
                    minilistbox.Items.Add($"{item.Text}");

            }
           
        }

        private void Minienter_Click(object sender, RoutedEventArgs e)
        {
            Minichat = new Minichat()
            {
                Text = minitext.Text
            };
            minitext.Clear();
            userVid = new UserVid()
            {
                MiniChat_ID = Minichat.ID,
                UserV_ID = _VidID
            };
            context.userVids.Add(userVid);
            userReceiver = new UserReceiver()
            {
                MiniChat_ID = Minichat.ID,
                UserR_ID = _id
            };
            context.userReceivers.Add(userReceiver);
            context.Minichats.Add(Minichat);
            context.SaveChanges();
           
        }

        private void Minitext_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                Minienter_Click(sender, e);
            }
        }
    }
}
